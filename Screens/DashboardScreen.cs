using DynamicBakery.Screens.DashboardUserControls;

namespace DynamicBakery.Screens
{
    public partial class DashboardScreen : Form
    {
        private NavigationControls navigationControls;
        private BakeryManagementSystem bakerySystem;

        public DashboardScreen(BakeryManagementSystem bakerySystem)
        {
            this.bakerySystem = bakerySystem;

            InitializeComponent();
            InitializeNavigationControls();
        }

        //creating and passing user controls in
        private void InitializeNavigationControls()
        {

            ProductManager productManager = bakerySystem.GetProductManager();
            CustomerManager customerManager = bakerySystem.GetCustomerManager();
            TransactionManager transactionManager = bakerySystem.GetTransactionManager();

            List<UserControl> controls = new List<UserControl>(){
                new SalesScreen(productManager, customerManager, transactionManager),
                new ProductsScreen(productManager),
                new CustomersScreen(customerManager),
                new PromotionsScreen(productManager)};

            navigationControls = new NavigationControls(controls, pnlDashContent);
            navigationControls.DisplayControl(0);
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            navigationControls.DisplayControl(0);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            navigationControls.DisplayControl(1);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            navigationControls.DisplayControl(2);
        }

        private void btnLoyalty_Click(object sender, EventArgs e)
        {
            navigationControls.DisplayControl(3);
        }
    }
}
