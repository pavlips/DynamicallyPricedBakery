using DynamicBakery.Managers;

namespace DynamicBakery.Screens
{
    public partial class ReportScreen : Form
    {
        private BakeryManagementSystem bakerySystem;

        public ReportScreen(BakeryManagementSystem bakerySystem)
        {
            this.bakerySystem = bakerySystem;

            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // DYNAMIC OBJECT GENERATION OF OBJECTS BASED ON USER INPUT
            ReportCriteria criteria = new ReportCriteria
            {
                startDate = dtpStart.Value,
                endDate = dtpEnd.Value,
                customerTier = cboCustomerTier.SelectedItem?.ToString(), // MAKING SURE EXCEPTION ISN'T THROWN IF SELECTED ITEM IS NULL
            };

            Report selectedReport;  
            switch (cboReportType.SelectedItem?.ToString())
            {
                case "Sales":
                    selectedReport = new SalesReport(criteria, bakerySystem);
                    break;

                case "Customer Engagement":
                    selectedReport = new CustomerEngagementReport(criteria, bakerySystem);
                    break;

                default:
                    MessageBox.Show("Please select a valid report type.");
                    return;
            }

            selectedReport.GenerateReport();
            MessageBox.Show("Report generated");
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboReportType.SelectedItem?.ToString())
            {
                case "Sales":
                    cboCustomerTier.Visible = false;
                    break;

                case "Customer Engagement":
                    cboCustomerTier.Visible = true;
                    break;

                default:
                    cboCustomerTier.Visible = false;
                    break;
            }
        }


    }

}
