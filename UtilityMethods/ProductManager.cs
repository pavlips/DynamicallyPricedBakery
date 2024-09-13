using DynamicBakery.Data;
using DynamicBakery.Models;

public class ProductManager
{
    private BakeryManagementContext context;

    public ProductManager(BakeryManagementContext context)
    {
        this.context = context;
    }

    public void AddProduct(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges(); //adds product and saves database changes
    }

    public List<Product> GetAllProducts()
    {
        return context.Products.ToList(); // returns every product from database
    }

    public void UpdateProduct(Product product)
    {
        context.Entry(product).CurrentValues.SetValues(product); 
        context.SaveChanges();
    }

    public void UpdateProductPrice(Product product, decimal newPrice)
    {
        decimal oldPrice = product.CurrentPrice;
        
        if (oldPrice != newPrice) // only update if price changed
        {
            product.CurrentPrice = newPrice;    

            PricingLog pricingLog = new PricingLog // DYNAMIC GENERATION OF OBJECT
            {
                ProductId = product.ProductId,
                OldPrice = oldPrice,
                NewPrice = newPrice,
                ChangeTime = DateTime.Now 
            };
            context.PricingLogs.Add(pricingLog); // add and save to database
            context.SaveChanges();
        }
    }


    public void DeleteProduct(Product product) // delete product, and all salesitems and products associated with it
    {
        try // ERROR HANDLING
        {
            if (product != null)
            {
                var promotions = context.Promotions.Where(p => p.ProductId == product.ProductId);
                context.Promotions.RemoveRange(promotions);

                var salesItems = context.SalesItems.Where(s => s.ProductId == product.ProductId);
                context.SalesItems.RemoveRange(salesItems);

                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
        catch
        {
            MessageBox.Show("Error while deleting product");
        }
    }

    public decimal[] GetProductPromotionDiscounts(Product product)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today); 

        decimal[] discounts = context.Promotions
            .Where(pr => pr.ProductId == product.ProductId && pr.StartDate <= today && pr.EndDate >= today) // makes sure promotion is still ongoing
            .Select(pr => pr.Discount)
            .ToArray();

        return discounts;
    }

    public List<Promotion> GetAllPromotions(Product product)
    {
        return context.Promotions
            .Where(pr => pr.ProductId == product.ProductId) // list of promotions for that product
            .ToList();
    }

    public void AddPromotion(Promotion promotion)
    {
        context.Promotions.Add(promotion); //adds promotion and saves it
        context.SaveChanges();
    }

    public void UpdatePromotion(Promotion promotion)
    {
        context.Entry(promotion).CurrentValues.SetValues(promotion); //updates current values of promotion to new values
        context.SaveChanges();
    }

    public void DeletePromotion(Promotion promotion)
    {
        try // ERROR HANDLING
        {
            if (promotion != null) //to not delete twice and get error (ERROR HANDLING)
            {
                context.Promotions.Remove(promotion);
                context.SaveChanges();
            }
        }
        catch
        {
            MessageBox.Show("Error while deleting promotion");
        }

    }

    public Dictionary<string, List<Product>> GetGroupedProducts()
    {
        return context.Products
            .OrderBy(p => p.Name) 
            .GroupBy(p => p.ProductType) // group products by their type
            .ToDictionary(gp => gp.Key, gp => gp.ToList());  // creates dictionary where key is product type and value is the respective list
    }

    //MERGE SORT ALGORITHM (RECURSIVE VERSION)
    public List<Product> MergeSort(List<Product> products, string property)
    {
        if (products.Count <= 1)
            return products;

        // split list into two and fill in with products
        int midPoint = products.Count / 2;
        List<Product> left = products.Take(midPoint).ToList();
        List<Product> right = products.Skip(midPoint).ToList();

        // RECURSION USED TO SPLIT LIST
        left = MergeSort(left, property);
        right = MergeSort(right, property);

        // merge the lists back together
        return Merge(left, right, property);
    }


    // LIST OPERATIONS CAN BE FOUND HERE. 
    private static List<Product> Merge(List<Product> left, List<Product> right, string property)
    {

        List<Product> result = new List<Product>();
        int indexLeft = 0;
        int indexRight = 0;

        while (indexLeft < left.Count || indexRight < right.Count) // keep merging until both lists are empty
        {
            if (indexLeft < left.Count && indexRight < right.Count) // if both lists have products
            {
                IComparable leftValue = left[indexLeft].GetType().GetProperty(property).GetValue(left[indexLeft], null) as IComparable; // get comparable value of property as strings have to be compared differently
                IComparable rightValue = right[indexRight].GetType().GetProperty(property).GetValue(right[indexRight], null) as IComparable;

                if (leftValue.CompareTo(rightValue) <= 0) // if left value is smaller or equal to right value, add left value to result
                {
                    result.Add(left[indexLeft]);
                    indexLeft++;
                }
                else
                {
                    result.Add(right[indexRight]); // otherwise add right value to result
                    indexRight++;
                }

            }

            // when only left list has elements, add them all to result
            else if (indexLeft < left.Count)
            {
                while (indexLeft < left.Count)
                {
                    result.Add(left[indexLeft]);
                    indexLeft++;
                }
            }

            // when only right list has elements, add them all to result
            else if (indexRight < right.Count)
            {
                while (indexRight < right.Count)
                {
                    result.Add(right[indexRight]);
                    indexRight++;
                }
            }
        }

        return result;
    }

}
