using EFDBDEMO.Models;

namespace EFDBDEMO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var northwindentities = new NorthWindContext();
            var custfrmspain = from Customer in northwindentities
                               .Customers
                               where Customer.Country == "Spain"
                               select new
                               {
                                   Customer.CompanyName,
                                   Customer.Country
                               };
            var custfrmspain2 = northwindentities.Customers
                                .Where(x => x.Country == "Spain")
                                .Select(x => new { x.CompanyName, x.Country });

            foreach( var cust in custfrmspain2)
            {
                Console.WriteLine($"{cust.CompanyName} is in {cust.Country}");
            }
            var categoryAbbreviations = northwindentities
            .Categories
            .Select(x => x.CategoryName.Substring(0, 3).ToUpper())
            .ToList();

            foreach (var categoryAbbreviation in categoryAbbreviations)
            {
                Console.WriteLine($"{categoryAbbreviation}");
            }

            var carlosnemes = northwindentities.Customers
                .Where(x => x.ContactName.Contains("Carlos"))
                .Select(x => new
                {
                    contactname = x.ContactName,
                    companyname = x.CompanyName
                });
            foreach (var calname in carlosnemes)
            {
                Console.WriteLine($"{calname}");
            }

            var productincat = northwindentities.Products
                .Where(c => c.Category.CategoryName == "Beverages")
                .Select(x => new
                {
                    products = x.ProductName
                });
            foreach (var item in productincat)
            {
                Console.WriteLine($"{item}");
            }

            var custwith10order = northwindentities.Customers
                .Where(x => x.Orders.Count > 10)
                .Select(x => new
                {
                    custid = x.CustomerId,
                    order = x.Orders
                });
            foreach(var cust in custwith10order)
            {
                Console.WriteLine($"Cust wit id {cust.custid} has {cust.order.Count} orders");
                foreach(var or in cust.order)
                {
                    Console.WriteLine($"{or.OrderId}--{or.OrderDate}");

                }
            }

        }
    }
}
