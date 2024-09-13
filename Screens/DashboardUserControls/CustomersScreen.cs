using DynamicBakery.Models;

namespace DynamicBakery.Screens.DashboardUserControls
{
    public partial class CustomersScreen : UserControl
    {
        private CustomerManager customerManager;
        private Customer? currentCustomer;

        public CustomersScreen(CustomerManager customerManager)
        {
            InitializeComponent();
            this.customerManager = customerManager;
        }


        private void btnQRCodeConnect_Click(object sender, EventArgs e)
        {
            BarcodeReaderScreen barcodeReaderScreen = new BarcodeReaderScreen(customerManager);

            barcodeReaderScreen.SuccessfulQRConnectionEvent += BarcodeReaderScanSuccessSet; // if qr code is scanned, it will call BarcodeReaderScanSuccessSet
            barcodeReaderScreen.Show();
        }
        private void BarcodeReaderScanSuccessSet(string qrCodeId) 
        {
            // load customer from qr code and set as connected
            lblStatus.Text = "Connected";
            currentCustomer = customerManager.GetCustomerByQRCode(qrCodeId);

            txtFirstName.Text = currentCustomer.FName;
            txtLastName.Text = currentCustomer.LName;  
            txtEmailInfo.Text = currentCustomer.Email;
            cboLoyalty.SelectedItem = currentCustomer.LoyaltyTier;

        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmailInfo.Text;
            string loyaltyTier = cboLoyalty.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(loyaltyTier)) // check if all fields are filled (ERROR HANDLING)
            {
                MessageBox.Show("Please fill in all data");
            }

            else if (!customerManager.IsValidEmail(email)) // ENSURING EMAIL IS VALID
            {
                MessageBox.Show("Please enter a valid email");
            }
            else
            {
                if (currentCustomer == null) // if no customer connected, create new customer and send them a qr code (ERROR HANDLING)
                {
                    string feedForQR = $"{email}-{DateTime.UtcNow.Ticks}";
                    string qrCodeId = CustomerManager.GenerateQRCodeID(feedForQR);

                    Customer newCustomer = new Customer
                    {
                        FName = firstName,
                        LName = lastName,
                        Email = email,
                        LoyaltyTier = loyaltyTier,
                        QrcodeId = qrCodeId
                    };

                    customerManager.AddCustomer(newCustomer);
                    customerManager.SendQRCode(email, qrCodeId);
                }
                else // if customer is connected, update their details
                {
                    currentCustomer.FName = firstName;
                    currentCustomer.LName = lastName;
                    currentCustomer.Email = email;
                    currentCustomer.LoyaltyTier = loyaltyTier;

                    customerManager.UpdateCustomer(currentCustomer);
                    currentCustomer = null;
                }

                // clear form after updating
                ClearCustomerForm();

                MessageBox.Show("Customer updated successfully");

            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            // delete customer by email
            string email = txtEmailResetUpdate.Text;
            customerManager.DeleteCustomerByEmail(email);

            ClearCustomerForm();
        }

        private void ClearCustomerForm()
        {
            lblStatus.Text = "Disconnected";
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmailInfo.Clear();
            txtEmailResetUpdate.Clear();
            cboLoyalty.SelectedIndex = -1;
        }

        private void btnQRCodeReset_Click(object sender, EventArgs e)
        {
            // send qr code to customer by email again
            string email = txtEmailResetUpdate.Text;
            customerManager.SendQRCodeByEmail(email);

        }


    }

}
