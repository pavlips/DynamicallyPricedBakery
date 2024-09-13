using DynamicBakery.Data;
using DynamicBakery.Models;
using Timer = System.Threading.Timer;

public class BakeryManagementSystem
{
    private BakeryManagementContext context = new BakeryManagementContext();


    private ProductManager productManager;
    private TransactionManager transactionManager;
    private CustomerManager customerManager;

    private Timer dynamicPricingTimer;
    private TimeSpan updateInterval;
    private TimeSpan startOfDay;
    private TimeSpan endOfDay;

    public BakeryManagementSystem(TimeSpan updateInterval, TimeSpan startOfDay, TimeSpan endOfDay)
    {
        // create managers for screens
        productManager = new ProductManager(context);
        transactionManager = new TransactionManager(context);
        customerManager = new CustomerManager(context);

        // set dynamic pricing timer
        this.updateInterval = updateInterval;
        this.startOfDay = startOfDay;
        this.endOfDay = endOfDay;

        ScheduleDynamicPricingUpdates();
    }


    // MESSAGEBOXES ARE HERE TO HELP FOR PROGRAM TESTING. IN PRODUCT SENT TO CLIENT, THESE ARE REMOVED (BUT COULD BE HELPFUL FOR EXAMINER TESTING).
    private void ScheduleDynamicPricingUpdates()
    {
        TimeSpan now = DateTime.Now.TimeOfDay;

        if (now < startOfDay) // if its before the start of the day, schedule the first dynamic pricing at the start of the day
        {
            int timeUntilStart = Convert.ToInt32((startOfDay - now).TotalMilliseconds);
            dynamicPricingTimer = new Timer(DynamicPrice, null, timeUntilStart, Convert.ToInt32(updateInterval.TotalMilliseconds));
        }

        else if (now >= startOfDay && now <= endOfDay) // if its within the day, schedule the first dynamic pricing at next interval
        {
            TimeSpan timeAtNextExecution = startOfDay;

            while (timeAtNextExecution < now) 
            {
                timeAtNextExecution = timeAtNextExecution.Add(updateInterval);
            }

            MessageBox.Show($"The first dynamic pricing will take place at {timeAtNextExecution}");


            int timeUntilStart = Convert.ToInt32((timeAtNextExecution - now).TotalMilliseconds);
            dynamicPricingTimer = new Timer(DynamicPrice, null, timeUntilStart, Convert.ToInt32(updateInterval.TotalMilliseconds));

        }
        else
        {
            MessageBox.Show("WARNING: It is passed closing time, so no more dynamic pricing will take place.");
        }
    }


    private async void DynamicPrice(object state)
    {
        WeatherService weatherService = new WeatherService();
        
        double weatherMultiplier = await weatherService.GetWeatherBasedPriceMultiplier(); // doesnt change for products

        MessageBox.Show($"The weather multiplier is {weatherMultiplier}");

        List<Product> products = productManager.GetAllProducts();

        foreach (Product product in products)
        {
            DynamicPriceProduct(product,weatherMultiplier);
        }
    }

    //COMPLEX BUSINESS MODEL
    private void DynamicPriceProduct(Product product, double weatherMultiplier)
    {
        double[,] salesData = transactionManager.GetRecentSalesDataByProduct(product.ProductId, product.Quantity, startOfDay, endOfDay);
        double minimumMultiplier = 1.2;
        double regressionMultiplier = 1;
        decimal newPrice;


        if (salesData.GetLength(0) >= 3) // need 3 points for regression
        {
            regressionMultiplier = AdjustProductLinearRegPrice(PerformLinearRegression(salesData));

            MessageBox.Show($"Product {product.Name} has a regression multiplier of {regressionMultiplier}");
        }

        double totalMultiplier = regressionMultiplier * weatherMultiplier * minimumMultiplier; // calculate resulting multiplier

        if (totalMultiplier > minimumMultiplier) // check if making more than minimum profit bakery must make
        {
            newPrice = product.BasePrice * Convert.ToDecimal(totalMultiplier); 
        }
        else
        {
            newPrice = product.BasePrice * Convert.ToDecimal(minimumMultiplier);
        }

        decimal[] promotionDiscounts = productManager.GetProductPromotionDiscounts(product); // apply promotions after as a loss might be acceptable with promotions
        foreach (decimal promotionDiscount in promotionDiscounts)
        {
            MessageBox.Show($"Product {product.Name} has a promotion of {promotionDiscount}%");
            decimal discountMultiplier = (100 - promotionDiscount) / 100;
            newPrice *= discountMultiplier;
        }

        newPrice = Math.Round(newPrice, 2); // ensure price is rounded as currency

        productManager.UpdateProductPrice(product, newPrice); 
    }

    // COMPLEX USER DEFINED ALGORITHM / COMPLEX MATHEMATICAL MODEL
    private double PerformLinearRegression(double[,] salesData) // perform linear regression algorithm
    {
        double sumX = 0, sumY = 0, sumXx = 0, sumXy = 0;
        int n = salesData.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            double x = salesData[i, 0]; // fraction of day
            double y = salesData[i, 1]; // stock

            sumX += x;
            sumY += y;
            sumXx += x * x;
            sumXy += x * y;
        }

        double gradient = (n * sumXy - sumX * sumY) / (n * sumXx - sumX * sumX);
        double yIntercept = (sumY - gradient * sumX) / n;
        double xIntercept = - yIntercept / gradient;

        return xIntercept;
    }

    private double AdjustProductLinearRegPrice(double xIntercept) // use the point in time where the stock hits 0 to adjust price
    {
        if (xIntercept > 1)
        {
            return 0.90;
        }
        else if (xIntercept > 0.75)
        {
            return 1.4;
        }
        else if (xIntercept > 0.50)
        {
            return 1.6;
        }
        else
        {
            return 1;
        }
    }

    // return managers for screens
    public ProductManager GetProductManager() => productManager;
    public CustomerManager GetCustomerManager() => customerManager;
    public TransactionManager GetTransactionManager() => transactionManager;


}
