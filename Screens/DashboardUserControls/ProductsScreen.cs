using DynamicBakery.Models;
using System.ComponentModel;

namespace DynamicBakery.Screens.DashboardUserControls
{
    public partial class ProductsScreen : UserControl
    {
        private ProductManager productManager;
        private BindingList<Product> products;
        private List<Product> productsToDelete = new List<Product>();


        public ProductsScreen(ProductManager productManager)
        {
            InitializeComponent();
            this.productManager = productManager;
            LoadData();
        }

        private void LoadData()
        {
            products = new BindingList<Product>(productManager.GetAllProducts());
            dgvProducts.DataSource = products;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure to delete this product?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Product productToDelete = (Product)dgvProducts.CurrentRow.DataBoundItem;

                if (productToDelete.ProductId > 0) //makes sure it product to delete
                {
                    productsToDelete.Add(productToDelete);
                    products.Remove(productToDelete); ;
                }
                else
                {
                    MessageBox.Show("Select a product to delete.");
                }

            }

        }

        //checking fields in another method for the best since have to check its an integer later too
        private void btnSave_Click(object sender, EventArgs e)
        {

            foreach (Product product in productsToDelete)
            {
                productManager.DeleteProduct(product);
            }
            productsToDelete.Clear();


            foreach (Product product in products)
            {
                if (string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.ProductType) || product.BasePrice <= 0 || product.Quantity <= 0) // ERROR HANDLING
                {
                    MessageBox.Show("Please fill in all the data correctly");
                }
                else
                {
                    if (product.ProductId == 0) // check if added to database yet
                    {
                        productManager.AddProduct(product);
                    }
                    else
                    {
                        productManager.UpdateProduct(product);
                    }
                }
            }
        }


        private void dgvProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string property = dgvProducts.Columns[e.ColumnIndex].DataPropertyName;
            List<Product> sortedProductsList = productManager.MergeSort(products.ToList(), property);

            products = new BindingList<Product>(sortedProductsList);
            dgvProducts.DataSource = products;
        }
    }
}
