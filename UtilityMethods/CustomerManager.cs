using DynamicBakery.Data;
using DynamicBakery.Models;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using ZXing;
using ZXing.QrCode;
using ZXing.Windows.Compatibility;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

public class CustomerManager
{
    private BakeryManagementContext context;

    public CustomerManager(BakeryManagementContext context)
    {
        this.context = context;
    }

    public void AddCustomer(Customer customer)
    {
        context.Customers.Add(customer);
        context.SaveChanges();
    }

    public double GetDiscountRateForCustomer(Customer customer) // return discount for tier
    {
        switch (customer.LoyaltyTier)
        {
            case "Gold":
                return 0.1; 
            case "Silver":
                return 0.05; 
            default:
                return 0; 
        }
    }


    public Customer GetCustomerByQRCode(string qrCodeId)
    {
        return context.Customers.Single(c => c.QrcodeId == qrCodeId); // get customer by qr code
    }

    public bool DoesCustomerExistByQRCode(string qrCodeId)
    {
        return context.Customers.Any(c => c.QrcodeId == qrCodeId); // check if customer exists by qr code
    }

    public Customer GetCustomerByEmail(string email)
    {
        return context.Customers.Single(c => c.Email == email); // get customer by email
    }

    public void UpdateCustomer(Customer customer)
    {
        context.Entry(customer).CurrentValues.SetValues(customer);
        context.SaveChanges();

    }

    // ERROR HANDLING
    public void DeleteCustomerByEmail(string email)
    {
        try
        {
            Customer customerToDelete = GetCustomerByEmail(email);
            var transactions = context.SalesTransactions.Where(t => t.CustomerId == customerToDelete.CustomerId).ToList();

            foreach (var transaction in transactions)
            {
                var salesItems = context.SalesItems.Where(si => si.TransactionId == transaction.TransactionId).ToList();
                context.SalesItems.RemoveRange(salesItems);
                context.SalesTransactions.Remove(transaction);
            }

            context.Customers.Remove(customerToDelete);
            context.SaveChanges();
        }
        catch
        {
            MessageBox.Show("Error when deleting");
        }

    }

    // ERROR HANDLING
    public void SendQRCodeByEmail(string email)
    {
        try // try to send qr code, if it fails, show message box
        {
            Customer customer = GetCustomerByEmail(email);
            string qrCodeData = customer.QrcodeId;
            SendQRCode(email, qrCodeData);
        }
        catch
        {
        }
    }

    //SENDING EMAIL
    public void SendQRCode(string recieverEmail, string qrCodeID)
    {
        Bitmap qrCodeImage = GenerateQRCode(qrCodeID);
        string password = Environment.GetEnvironmentVariable("BAKERYPASS", EnvironmentVariableTarget.Machine); // gets password as environmental variable. Should be replaced with a more robust system.
        string clientEmail = "{EMAIL}";

        using (MemoryStream memoryStream = new MemoryStream()) 
        {
            qrCodeImage.Save(memoryStream, ImageFormat.Png);
            memoryStream.Position = 0; // must set stream pos to 0 so its read from start when sending

            MailMessage mail = new MailMessage
            {
                From = new MailAddress(clientEmail),
                Subject = "Your QR Code",
                Body = "Attached is your QR Code.",
            };

            mail.To.Add(recieverEmail);
            mail.Attachments.Add(new Attachment(memoryStream, "qrCode.png", "image/png"));

            SmtpClient smtpServer = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                Credentials = new System.Net.NetworkCredential(clientEmail, password),
                EnableSsl = true
            };

            smtpServer.Send(mail);
        }
    }

    //GENERATING QR CODE IMAGE
    public Bitmap GenerateQRCode(string qrCodeID)
    {
        QrCodeEncodingOptions options = new QrCodeEncodingOptions
        {
            DisableECI = true,
            CharacterSet = "UTF-8",
            Width = 500,
            Height = 500
        };

        BarcodeWriter barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = options
        };
            
        return barcodeWriter.Write(qrCodeID);
    }

    //CREATING A SECURE QR CODE WITH HASHING
    public static string GenerateQRCodeID(string feed)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(feed));
            string hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash.Substring(0, 16);
        }
    }


    // COMPLEX CROSS TABLE PARAMETERISED LINQ QUERIES BELOW
    public (string[] loyaltyTiers, decimal[] customerCounts) GetCustomerCountsByTier() 
    {
        var customerCountsByTier = context.Customers
            .GroupBy(c => c.LoyaltyTier) //group by loyalty tier
            .Select(lg => new // create new object with loyalty tier and count
            {
                LoyaltyTier = lg.Key,
                Count = lg.Count()
            })
            .ToList(); // to reduce database queries 

        string[] loyaltyTiers = customerCountsByTier.Select(lg => lg.LoyaltyTier).ToArray();
        decimal[] customerCounts = customerCountsByTier.Select(lg => Convert.ToDecimal(lg.Count)).ToArray(); //convert to decimal just to feed into bar chart function

        return (loyaltyTiers, customerCounts);
    }


    public int GetTotalUniqueCustomers(DateTime startDate, DateTime endDate)
    {
        return context.SalesTransactions
            .Where(st => st.TransactionTime >= startDate && st.TransactionTime <= endDate)
            .Distinct() // customers have to be unique
            .Count();
    }

    public string GetHighestSpendingCustomer(DateTime startDate, DateTime endDate)
    {
        return context.SalesItems
            .Where(si => si.Transaction.TransactionTime >= startDate && si.Transaction.TransactionTime <= endDate)
            .GroupBy(si => si.Transaction.Customer)
            .Select(ct => new // create new object with customer and total spend
            {
                Customer = ct.Key,
                TotalSpend = ct.Sum(si => si.PriceAtSale * si.Quantity) // sum of all sales items for customer
            })
            .OrderByDescending(ct => ct.TotalSpend) // first customer in list will be highest spending
            .Select(ct => $"{ct.Customer.FName} {ct.Customer.LName}") // return full name
            .First(); //returns first customer
    }
    public bool IsValidEmail(string email) // CHECK IF EMAIL IS VALID BY TRYING TO CREATE MAIL ADDRESS
    {
        try
        {
            MailAddress address = new MailAddress(email);
            return address.Address == email;
        }
        catch
        {
            return false;
        }
    }

}



