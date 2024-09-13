using DynamicBakery.Screens;

namespace DynamicBakery
{
    public partial class HomeScreen : Form
    {

        private BakeryManagementSystem bakerySystem;


        public HomeScreen()
        {
            InitializeComponent();

            TimeSpan updateInterval = TimeSpan.FromMinutes(20);
            TimeSpan startOfDay = new TimeSpan(08, 0, 0);
            TimeSpan endOfDay = new TimeSpan(16, 0, 0);
            bakerySystem = new BakeryManagementSystem(updateInterval, startOfDay, endOfDay);

        }

        private void dashboardDirect_Click(object sender, EventArgs e)
        {
            DashboardScreen dashboardForm = new DashboardScreen(bakerySystem);
            dashboardForm.Show();

        }

        private void btnReportGen_Click(object sender, EventArgs e)
        {
            ReportScreen reportForm = new ReportScreen(bakerySystem);
            reportForm.Show();
        }

        private void btnProductsDisplay_Click(object sender, EventArgs e)
        {
            DisplayScreen displayForm = new DisplayScreen(bakerySystem);
            displayForm.Show();
        }
    }
}
