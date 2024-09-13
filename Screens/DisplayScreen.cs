using DynamicBakery.Models;

namespace DynamicBakery.Screens
{
    public partial class DisplayScreen : Form
    {
        private BakeryManagementSystem bakerySystem;
        private Queue<FlowLayoutPanel> pagesQueue = new Queue<FlowLayoutPanel>(); // QUEUE USED TO STORE PAGS

        public DisplayScreen(BakeryManagementSystem bakerySystem)
        {
            InitializeComponent();
            this.bakerySystem = bakerySystem;
            FetchPages();
            ShowNextPage();
        }

        private void tmrDisplay_Tick(object sender, EventArgs e)
        {
            ShowNextPage();
        }

        private void ShowNextPage()
        {
            // DEQUE THE FIRST PAGE AND ADD IT TO THE END OF THE QUEUE (TO RECYCLE PAGES)
            FlowLayoutPanel nextPage = pagesQueue.Dequeue();
            Controls.Clear();
            Controls.Add(nextPage);
            pagesQueue.Enqueue(nextPage);

        }

        // CREATES PAGES AND ADDS THEM ONTO THE QUEUE
        private void FetchPages()
        {
            Dictionary<string, List<Product>> groupedProducts = bakerySystem.GetProductManager().GetGroupedProducts();

            FlowLayoutPanel currentPage = CreateNewPage();
            int currentPageTypes = 0;
            int maxTypesPerPage = 3;

            foreach (KeyValuePair<string, List<Product>> types in groupedProducts)
            {
                if (currentPageTypes == maxTypesPerPage)
                {
                    pagesQueue.Enqueue(currentPage);
                    currentPage = CreateNewPage();
                    currentPageTypes = 0;
                }

                AddCategoryToPage(currentPage, types.Key, types.Value);
                currentPageTypes++;

                if (types.Equals(groupedProducts.Last()) && currentPageTypes <= maxTypesPerPage) // so we still add a page if it isnt full
                {
                    pagesQueue.Enqueue(currentPage);
                }
            }
        }

        private FlowLayoutPanel CreateNewPage()
        {
            return new FlowLayoutPanel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10),
            };
        }

        private void AddCategoryToPage(FlowLayoutPanel page, string typeName, List<Product> products)
        {
            Label typeHeader = new Label
            {
                Text = typeName,
                Font = new Font("Arial Black", 14, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(5),
                Margin = new Padding(5)
            };
            page.Controls.Add(typeHeader);

            foreach (Product product in products)
            {
                Label productLabel = new Label
                {
                    Text = $"{product.Name} - £{product.CurrentPrice}",
                    Font = new Font("Arial", 10),
                    AutoSize = true,
                    Padding = new Padding(5),
                    Margin = new Padding(5)
                };
                page.Controls.Add(productLabel);
            }
        }

    }
}
