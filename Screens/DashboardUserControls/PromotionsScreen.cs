using DynamicBakery.Models;
using System.ComponentModel;

namespace DynamicBakery.Screens.DashboardUserControls
{
    public partial class PromotionsScreen : UserControl
    {
        private ProductManager productManager;
        private BindingList<Promotion> promotionList;
        private List<Promotion> promotionsToDelete = new List<Promotion>();
        private Product selectedProduct;

        public PromotionsScreen(ProductManager productManager)
        {
            InitializeComponent();
            this.productManager = productManager;
            InitialiseProductComboBox();
        }

        private void InitialiseProductComboBox()
        {
            List<Product> products = productManager.GetAllProducts();
            cboProductSelect.DataSource = products;
            cboProductSelect.DisplayMember = "Name";
            cboProductSelect.ValueMember = "ProductId";
        }

        private void cboProductSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            selectedProduct = (Product)cboProductSelect.SelectedItem;

            List<Promotion> promotions = productManager.GetAllPromotions(selectedProduct);
            promotionList = new BindingList<Promotion>(promotions);
            dgvPromotions.DataSource = promotionList;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPromotions.CurrentRow != null) // ERROR HANDLING
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this promotion?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Promotion promotionToDelete = (Promotion)dgvPromotions.CurrentRow.DataBoundItem;
                    promotionsToDelete.Add(promotionToDelete);
                    promotionList.Remove(promotionToDelete);
                }
            }
            else
            {
                MessageBox.Show("Please select a promotion to delete.");
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Promotion promotion in promotionsToDelete)
            {
                productManager.DeletePromotion(promotion);
            }
            promotionsToDelete.Clear();

            foreach (Promotion promotion in promotionList)
            {

                if (string.IsNullOrWhiteSpace(promotion.Description) || promotion.Discount <= 0) // ERROR HANDLING
                {
                    MessageBox.Show("Please fill in all the data correctly");
                }

                promotion.ProductId = selectedProduct.ProductId;

                if (promotion.PromotionId == 0) // if new promotion
                {
                    productManager.AddPromotion(promotion);
                }
                else
                {
                    productManager.UpdatePromotion(promotion);
                }
            }

            LoadData();
        }

        private void PromotionsScreen_Enter(object sender, EventArgs e) // refreshes the product combo box when entering the screen (in case deleted or created products)
        {
            InitialiseProductComboBox();
            cboProductSelect.Refresh();
        }
    }

}

