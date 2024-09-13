using DynamicBakery.Data;
using DynamicBakery.Models;
using Microsoft.EntityFrameworkCore;

public class TransactionManager
{
    private BakeryManagementContext context;

    public TransactionManager(BakeryManagementContext context)
    {
        this.context = context;
    }

    public int CreateTransaction(int? customerId)
    {
        SalesTransaction transaction = new SalesTransaction //DYNAMIC GENERATION OF OBJECTS
        {
            CustomerId = customerId,
            TransactionTime = DateTime.Now
        };

        context.SalesTransactions.Add(transaction);

        if (customerId != null) // if customer is connected, check their purchase count to upgrade loyalty tier (ERROR HANDLING)
        {
            Customer customer = context.Customers.Find(customerId);

            int purchaseCount = GetPurchaseCount(customer);

            if (purchaseCount >= 5)
            {
                if (purchaseCount >= 20)
                {
                    customer.LoyaltyTier = "Gold";
                }
                else if (purchaseCount >= 5)
                {
                    customer.LoyaltyTier = "Silver";
                }
            }

        }

        context.SaveChanges(); //save changes

        return transaction.TransactionId; //return newly created transaction id by database to use for adding sold items
    }

    public int GetPurchaseCount(Customer customer) 
    {
        return context.SalesTransactions
            .Count(st => st.Customer == customer);
    }


    public void AddSaleItem(int transactionId, int productId, int quantity, decimal priceAtSale)
    {
        SalesItem saleItem = new SalesItem  // DYNAMIC GENERATION OF OBJECTS
        {
            TransactionId = transactionId,
            ProductId = productId,
            Quantity = quantity,
            PriceAtSale = priceAtSale
        };

        context.SalesItems.Add(saleItem); 
        context.SaveChanges();
    }


    //BELOW HERE CONTAINS MANY EXAMPLES OF CROSS PARAMETERISED LINQ QUERIES AND AGGREGATE FUNCTIONS
    public double[,] GetRecentSalesDataByProduct(int productId, int stock, TimeSpan startOfDay, TimeSpan endOfDay) // for dynamic pricing.
    {
        DateTime timeMinutesAgo = DateTime.Now.AddMinutes(-60);

        double dayLength = (endOfDay - startOfDay).TotalHours;

        var recentSales = context.SalesItems
            .Where(si => si.ProductId == productId && si.Transaction.TransactionTime >= timeMinutesAgo) // get all sales items for product in last hour
            .OrderByDescending(si => si.Transaction.TransactionTime) // order by descending to get most recent first
            .Select(si => new
            {
                TimeFraction = (si.Transaction.TransactionTime.TimeOfDay - startOfDay).TotalHours / dayLength, // time of day as fraction of day (for x axis)
                QuantitySold = si.Quantity // to get stock later
            })
            .ToList();

        double[,] salesData = new double[recentSales.Count, 2]; // create 2d array to store x and y axis data
            
        for (int i = 0; i < recentSales.Count; i++) 
        {
            salesData[i, 0] = recentSales[i].TimeFraction; // x axis
            salesData[i, 1] = stock; // y axis stock at that point in time

            stock += recentSales[i].QuantitySold; // reverse engineer stock by adding quantity sold to get stock before sale
        }

        return salesData;
    }

    public decimal GetTotalRevenue(DateTime startDate, DateTime endDate)
    {
        return context.SalesItems
            .Where(si => si.Transaction.TransactionTime >= startDate && si.Transaction.TransactionTime <= endDate)
            .Sum(si => si.PriceAtSale * si.Quantity); // sum of all sales items between dates
    }

    public int GetTotalProductsSold(DateTime startDate, DateTime endDate)
    {
        return context.SalesItems
            .Where(si => si.Transaction.TransactionTime >= startDate && si.Transaction.TransactionTime <= endDate)
            .Sum(si => si.Quantity); // sum of all products sold between dates
    }



    public decimal GetAverageRevenue(DateTime startDate, DateTime endDate)
    {
        return context.SalesItems
            .Where(si => si.Transaction.TransactionTime >= startDate && si.Transaction.TransactionTime <= endDate)
            .GroupBy(si => si.TransactionId) // group products by transaction id to get total revenue for each transaction
            .Select(tg => tg.Sum(si => si.PriceAtSale * si.Quantity)) // total revenue for each transaction
            .Average(); // average of all transactions
    }



    public Dictionary<string, decimal> GetTopProductCategoriesByRevenue(DateTime startDate, DateTime endDate)
    {
        return context.SalesItems
            .Where(si => si.Transaction.TransactionTime >= startDate && si.Transaction.TransactionTime <= endDate) // get all sales items between dates
            .GroupBy(si => si.Product.ProductType) // group sales items by product type
            .Select(cg => new  // create new object with category and total revenue
            { 
                Category = cg.Key, 
                TotalRevenue = cg.Sum(si => si.Quantity * si.PriceAtSale) 
            })
            .OrderByDescending(cg => cg.TotalRevenue) // order by descending to get highest revenue first and take top 8
            .Take(8)
            .ToDictionary(cg => cg.Category, cg => cg.TotalRevenue); // turn the object into a dictionary
    }



    public (string[] productNames, decimal[] totalRevenues) GetBestSellingProductsByRevenue(DateTime startDate, DateTime endDate)
    {
        var bestSellingProductsByRev = context.SalesItems
            .Where(si => si.Transaction.TransactionTime >= startDate && si.Transaction.TransactionTime <= endDate) // get all sales items between dates
            .GroupBy(si => si.Product.Name) // group by product name
            .Select(rg => new // create new object with product name and total revenue
            {
                ProductName = rg.Key,
                TotalRevenue = rg.Sum(si => si.PriceAtSale * si.Quantity) // total revenue for each product
            })
            .OrderByDescending(cg => cg.TotalRevenue)
            .Take(10)
            .ToList(); // to reduce database queries

        string[] productNames = bestSellingProductsByRev.Select(ps => ps.ProductName).ToArray();
        decimal[] totalRevenues = bestSellingProductsByRev.Select(ps => ps.TotalRevenue).ToArray();

        return (productNames, totalRevenues);
    }

    public (string[] productNames, decimal[] totalUnitsSold) GetBestSellingProductsByNumberSold(DateTime startDate, DateTime endDate) //convert to decimal just to feed into bar chart function
    {
        var bestSellingProductsByRevByUnit = context.SalesItems
            .Where(si => si.Transaction.TransactionTime >= startDate && si.Transaction.TransactionTime <= endDate)
            .GroupBy(si => si.Product.Name)
            .Select(bg => new // create new object with product name and total units sold
            {
                ProductName = bg.Key,
                TotalUnitsSold = bg.Sum(si => si.Quantity) // total units sold for each product
            })
            .OrderByDescending(bg => bg.TotalUnitsSold) // order by descending to get highest units sold first and take top 10
            .Take(10)
            .ToList();


        string[] productNames = bestSellingProductsByRevByUnit.Select(ps => ps.ProductName).ToArray();
        decimal[] totalUnitsSold = bestSellingProductsByRevByUnit.Select(ps => Convert.ToDecimal(ps.TotalUnitsSold)).ToArray(); //convert to decimal just to feed into bar chart function

        return (productNames, totalUnitsSold);
    }



    public Dictionary<string, decimal> GetProductRevenueDistributionByTier(DateTime startDate, DateTime endDate, string tier)
    {
        return context.SalesItems
            .Include(si => si.Product) // include product to get product name
            .Where(si => si.Transaction.TransactionTime >= startDate && si.Transaction.TransactionTime <= endDate && si.Transaction.Customer.LoyaltyTier == tier)
            .GroupBy(si => si.Product.Name) // group by product name
            .Select(tg => new // create new object with product name and total spent
            { 
                ProductName = tg.Key,
                TotalSpent = tg.Sum(si => si.Quantity * si.PriceAtSale) 
            })
            .ToDictionary(st => st.ProductName, st => st.TotalSpent); // turn the object into a dictionary
    }

    public (string[] loyaltyTiers, decimal[] averageSpends) GetAverageRevenueByTier()
    {
        var averageRevenueByTier = context.SalesItems
            .Where(si => si.Transaction.Customer != null) // non registered customers have a null customer
            .GroupBy(si => si.Transaction.Customer.LoyaltyTier)
            .Select(lg => new // create new object with loyalty tier and average revenue
            {
                LoyaltyTier = lg.Key,
                AverageRevenue = lg.Average(si => si.PriceAtSale * si.Quantity) // average revenue for each loyalty tier
            }) 
            .ToList(); // to reduce database queries

        string[] loyaltyTiers = averageRevenueByTier.Select(lt => lt.LoyaltyTier).ToArray();
        decimal[] averageRevenues = averageRevenueByTier.Select(lt => lt.AverageRevenue).ToArray();

        return (loyaltyTiers, averageRevenues);
    }



}
