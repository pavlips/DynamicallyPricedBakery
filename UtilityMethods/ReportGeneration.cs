using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;


namespace DynamicBakery.Managers
{
    // used for feeding data to the report
    public struct ReportCriteria
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string? customerTier { get; set; }
    }

    // COMPLEX USER DEFINED USE OF OOP (CLASSES, INHERITENCE, POLYMORPHISM, INTERFACES) 
    public abstract class Report
    {
        protected ReportCriteria criteria;
        protected BakeryManagementSystem bakerySystem;

        protected Report(ReportCriteria criteria, BakeryManagementSystem bakerySystem)
        {
            this.criteria = criteria;
            this.bakerySystem = bakerySystem;
        }
        public abstract void GenerateReport();

    }

    public class SalesReport : Report
    {
        public SalesReport(ReportCriteria criteria, BakeryManagementSystem bakerySystem)
            : base(criteria, bakerySystem) { }

        public override void GenerateReport()
        {
            string reportDirectory = Path.Combine("Reports", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            Directory.CreateDirectory(reportDirectory);

            TransactionManager transactionManager = bakerySystem.GetTransactionManager();

            // fetch data
            (string[] nameRevenue, decimal[] totalRevenues) = transactionManager.GetBestSellingProductsByRevenue(criteria.startDate, criteria.endDate);
            (string[] nameProduct, decimal[] totalProducts) = transactionManager.GetBestSellingProductsByNumberSold(criteria.startDate, criteria.endDate);
            Dictionary<string, decimal> topCategoriesByRevenue = transactionManager.GetTopProductCategoriesByRevenue(criteria.startDate, criteria.endDate);

            decimal totalRevenue = transactionManager.GetTotalRevenue(criteria.startDate, criteria.endDate);
            int totalProductsSold = transactionManager.GetTotalProductsSold(criteria.startDate, criteria.endDate);
            decimal averageTransactionValue = transactionManager.GetAverageRevenue(criteria.startDate, criteria.endDate);

            // create and save charts
            Plotting.CreateAndSaveBarChart(totalRevenues, nameRevenue, "Best Selling Products by Revenue", Path.Combine(reportDirectory, "BestSellersRevenue.png"));
            Plotting.CreateAndSaveBarChart(totalProducts, nameProduct, "Best Selling Products by Number Sold", Path.Combine(reportDirectory, "BestSellersNumber.png"));
            Plotting.CreateAndSavePieChart(topCategoriesByRevenue, "Revenue By Product Category", Path.Combine(reportDirectory, "topCategoryRevenue.png"));


            // create and save pdf of report
            string pdfFilePath = Path.Combine(reportDirectory, "SalesReport.pdf");
            GeneratePDF(reportDirectory, pdfFilePath, totalRevenue, totalProductsSold, averageTransactionValue);
        }

        // GENERATING A PDF FILE
        private void GeneratePDF(string reportDirectory, string pdfFilePath, decimal totalRevenue, int totalProductsSold, decimal averageTransactionValue)
        {
            PdfWriter writer = new PdfWriter(pdfFilePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // add text to pdf
            document.Add(new Paragraph("Sales Report").SetFontSize(20).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
            document.Add(new Paragraph($"Total Revenue: {totalRevenue:C}"));
            document.Add(new Paragraph($"Total Products Sold: {totalProductsSold}"));
            document.Add(new Paragraph($"Average Transaction Value: {averageTransactionValue:C}"));

            string[] imagePaths = {"topCategoryRevenue.png", "BestSellersRevenue.png", "BestSellersNumber.png"};

            // add images to pdf
            foreach (string imagePath in imagePaths)
            {
                string fullPath = Path.Combine(reportDirectory, imagePath);
                ImageData imageData = ImageDataFactory.Create(fullPath);
                iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData);
                document.Add(image);
            }

            document.Close();
        }
    }


    public class CustomerEngagementReport : Report
    {
        public CustomerEngagementReport(ReportCriteria criteria, BakeryManagementSystem bakerySystem)
            : base(criteria, bakerySystem) { }
        public override void GenerateReport()
        {
            string reportDirectory = Path.Combine("Reports", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            Directory.CreateDirectory(reportDirectory);

            TransactionManager transactionManager = bakerySystem.GetTransactionManager();
            CustomerManager customerManager = bakerySystem.GetCustomerManager();

            // fetch data
            Dictionary<string, decimal> spendingByProduct = transactionManager.GetProductRevenueDistributionByTier(criteria.startDate, criteria.endDate, criteria.customerTier);
            (string[] revenueTiers, decimal[] averageRevenues) = transactionManager.GetAverageRevenueByTier();
            (string[] customerTiers, decimal[] customerCounts) = customerManager.GetCustomerCountsByTier();
            int totalUniqueCustomers = customerManager.GetTotalUniqueCustomers(criteria.startDate, criteria.endDate);
            string highestSpendingCustomer = customerManager.GetHighestSpendingCustomer(criteria.startDate, criteria.endDate);

            // create and save charts
            Plotting.CreateAndSavePieChart(spendingByProduct, $"Revenue Distribution Per Product For {criteria.customerTier} Customers", Path.Combine(reportDirectory, "RevenueDistByTier.png"));
            Plotting.CreateAndSaveBarChart(averageRevenues, revenueTiers, "Average Transaction Value by Loyalty Tier", Path.Combine(reportDirectory, "AverageRevenuesByTier.png"));
            Plotting.CreateAndSaveBarChart(customerCounts, customerTiers, "Customer Counts by Loyalty Tier", Path.Combine(reportDirectory, "CustomerCountsByTier.png"));

            string pdfFilePath = Path.Combine(reportDirectory, "CustomerEngagementReport.pdf");

            // create and save pdf of report
            GeneratePDF(reportDirectory, pdfFilePath, totalUniqueCustomers, highestSpendingCustomer);
        }

        // GENERATING A PDF FILE
        private void GeneratePDF(string reportDirectory, string pdfFilePath, int totalUniqueCustomers, string highestSpendingCustomer)
        {
            PdfWriter writer = new PdfWriter(pdfFilePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // add text to pdf
            document.Add(new Paragraph("Customer Engagement Report").SetFontSize(20).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
            document.Add(new Paragraph($"Total Unique Customers: {totalUniqueCustomers}"));
            document.Add(new Paragraph($"Highest Spending Customer: {highestSpendingCustomer}"));

            // add images to pdf
            string[] imagePaths = {"RevenueDistByTier.png", "AverageRevenuesByTier.png", "CustomerCountsByTier.png"};
            foreach (string imagePath in imagePaths)
            {
                string fullPath = Path.Combine(reportDirectory, imagePath);
                ImageData imageData = ImageDataFactory.Create(fullPath);
                iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData);
                document.Add(image);
            }

            document.Close();
        }
    }

    public class Plotting
    {
        // standard method to create and save bar chart 
        public static void CreateAndSaveBarChart(decimal[] values, string[] labels, string title, string filePath)
        {
            PlotModel plotModel = new PlotModel { Title = title };
            BarSeries barSeries = new BarSeries
            {
                ItemsSource = values.Select(v => new BarItem { Value = Convert.ToDouble(v) }), // convert to double for plotting
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0:.00}", // 2 decimal places
                FillColor = OxyColors.SteelBlue
            };

            plotModel.Series.Add(barSeries);

            CategoryAxis categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "CategoryAxis",
                ItemsSource = labels
            };


            LinearAxis linearAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Key = "LinearAxis",
                MinimumPadding = 0,
                MaximumPadding = 0.1,
                AbsoluteMinimum = 0
            };

            plotModel.Axes.Add(categoryAxis);
            plotModel.Axes.Add(linearAxis);

            PngExporter pngExporter = new PngExporter
            {
                Width = 600,
                Height = 400
            };
            
            pngExporter.ExportToFile(plotModel, filePath);
        }

        // standard method to create and save pie chart
        public static void CreateAndSavePieChart(Dictionary<string, decimal> values, string title, string filePath)
        {
            PlotModel plotModel = new PlotModel { Title = title };
            PieSeries pieSeries = new PieSeries
            {
                Slices = values.Select(item => new PieSlice(item.Key, Convert.ToDouble(item.Value))).ToList() // convert to double for plotting
            };

            plotModel.Series.Add(pieSeries);

            PngExporter pngExporter = new PngExporter
            {
                Width = 600,
                Height = 400
            }; 
            
            pngExporter.ExportToFile(plotModel, filePath);

        }

    }

}

