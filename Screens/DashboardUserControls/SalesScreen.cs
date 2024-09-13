using DynamicBakery.Models;
using System.ComponentModel;

namespace DynamicBakery.Screens.DashboardUserControls
{
    public partial class SalesScreen : UserControl
    {
        private ProductManager productManager;
        private CustomerManager customerManager;
        private TransactionManager transactionManager;
        private Customer? currentCustomer;

        private BindingList<Product> cartList = new BindingList<Product>();
        private BindingList<Product> productList;

        public SalesScreen(ProductManager productManager, CustomerManager customerManager, TransactionManager transactionManager)
        {
            this.productManager = productManager;
            this.customerManager = customerManager;
            this.transactionManager = transactionManager;


            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            productList = new BindingList<Product>(productManager.GetAllProducts());
            dgvProducts.DataSource = productList;
            dgvCart.DataSource = cartList;

        }
        private void btnQRCodeConnect_Click(object sender, EventArgs e)
        {
            BarcodeReaderScreen barcodeReaderScreen = new BarcodeReaderScreen(customerManager);

            barcodeReaderScreen.SuccessfulQRConnectionEvent += BarcodeReaderScanSuccessSet; //if qr code successfully scanned, it will call BarcodeReaderScanSuccessSet
            barcodeReaderScreen.Show();
        }

        private void BarcodeReaderScanSuccessSet(string qrCodeId)
        {
            if (lblStatus.Text == "Disconnected") //we only want to apply discount once
            {
                lblStatus.Text = "Connected";
                currentCustomer = customerManager.GetCustomerByQRCode(qrCodeId);

                ApplyDiscountToCart();
            }

        }

        private void ApplyDiscountToCart()
        {

            decimal discountRate = Convert.ToDecimal(customerManager.GetDiscountRateForCustomer(currentCustomer));


            foreach (Product product in cartList)
            {
                product.CurrentPrice = Math.Round(product.CurrentPrice * (1 - discountRate), 2); // round to fit currency
            }

            dgvProducts.Refresh();
            dgvCart.Refresh();
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Product selectedProduct = (Product)dgvProducts.Rows[e.RowIndex].DataBoundItem;
            if (selectedProduct.Quantity > 0)
            {
                AddToCart(selectedProduct);
                selectedProduct.Quantity--;
                dgvProducts.Refresh();
                dgvCart.Refresh();
            }
        }
        private void AddToCart(Product product)
        {
            Product? productInCart = cartList.SingleOrDefault(p => p.ProductId == product.ProductId); // have to check if there is a product in cart already
            if (productInCart != null)
            {
                productInCart.Quantity++;
            }
            else
            {
                Product productCopy = new Product
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    CurrentPrice = product.CurrentPrice,
                    BasePrice = product.BasePrice,
                    Quantity = 1,
                    ProductType = product.ProductType
                };
                cartList.Add(productCopy);
            }


        }

        private void RemoveFromCart(Product product)
        {
            Product originalProduct = productList.Single(p => p.ProductId == product.ProductId);
            if (originalProduct != null)
            {
                originalProduct.Quantity++;
            }

            product.Quantity--;
            if (product.Quantity <= 0)
            {
                cartList.Remove(product);
            }

        }



        private void dgvCart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Product selectedProduct = (Product)dgvCart.Rows[e.RowIndex].DataBoundItem;
            RemoveFromCart(selectedProduct);
            dgvProducts.Refresh();
            dgvCart.Refresh();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cartList.Count > 0)
            {
                int? customerId = currentCustomer?.CustomerId;
                int transactionId = transactionManager.CreateTransaction(customerId);

                foreach (Product product in cartList)
                {
                    transactionManager.AddSaleItem(transactionId, product.ProductId, product.Quantity, product.CurrentPrice);
                }

                MessageBox.Show("Sale transaction completed successfully.");
                cartList.Clear();

                lblStatus.Text = "Transaction Completed";
            }

            currentCustomer = null;
            lblStatus.Text = "Disconnected";
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetSaleScreen();
        }

        private void ResetSaleScreen()
        {
            foreach (Product cartProduct in cartList)
            {
                Product originalProduct = productList.First(p => p.ProductId == cartProduct.ProductId);
                {
                    originalProduct.Quantity += cartProduct.Quantity;
                }
            }

            cartList.Clear();

            currentCustomer = null;
            lblStatus.Text = "Disconnected";

            dgvProducts.Refresh();
            dgvCart.Refresh();
        }

        private void SalesScreen_Enter(object sender, EventArgs e) // refreshes changes if product was deleted / added
        {
            LoadData();
            dgvProducts.Refresh();
        }
    }
}
