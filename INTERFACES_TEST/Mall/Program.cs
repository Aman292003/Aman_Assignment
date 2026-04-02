using System;
using System.Collections.Generic;
using System.Linq;

#region Exceptions
public class MallException : Exception
{
    public MallException(string message) : base(message) { }
}
#endregion

#region Entities

public interface IShop
{
    string ShopId { get; }
    string ShopName { get; }
    string Category { get; }
    double Revenue { get; set; }
}

public interface ICustomer
{
    string CustomerId { get; }
    string Name { get; }
    bool IsPremium { get; set; }
    double TotalSpent { get; set; }
}

public interface IMallService
{
    void AddShop(IShop shop);
    void RegisterCustomer(ICustomer customer);
    void MakePurchase(string customerId, string shopId, double amount);
    List<IShop> GetTopRevenueShops(int n);
    Dictionary<string, double> CategoryWiseRevenue();
    List<ICustomer> GetPremiumCustomers();
    double GetTotalMallRevenue();
    void RemoveShop(string shopId);
}

#endregion

#region Concrete Classes (YOU IMPLEMENT INTERFACE)

public class Shop  :IShop  // IMPLEMENT IShop
{
    public string ShopId { get; set; }
    public string ShopName { get; set; }
    public string Category { get; set; }
    public double Revenue { get; set; }
}

public class Customer  :ICustomer// IMPLEMENT ICustomer
{
    public string CustomerId { get; set; }
    public string Name { get; set; }
    public bool IsPremium { get; set; }
    public double TotalSpent { get; set; }
}

#endregion

#region Mall Class (YOU IMPLEMENT IMallService)

public class Mall :IMallService   // IMPLEMENT IMallService
{
    private Dictionary<string, IShop> shops = new();
    private Dictionary<string, ICustomer> customers = new();

    // Delegate & Event
    public delegate void MallNotification(string message);
    public event MallNotification Notify;

    public void AddShop(IShop shop)
    {
        if (shops.ContainsKey(shop.ShopId))
        {
            throw new MallException("Shop Already exists");
        }
        shops.Add(shop.ShopId, shop);
    }
    public void RegisterCustomer(ICustomer customer)
    {
        if (customers.ContainsKey(customer.CustomerId))
        {
            throw new MallException("Shop Already exists");
        }
        customers.Add(customer.CustomerId, customer);
    }
    public void MakePurchase(string customerId, string shopId, double amount)
    {
        if (!customers.ContainsKey(customerId) || !shops.ContainsKey(shopId)||amount<0)
        {
            throw new MallException("shop or custumes  does not exists or amount is less than 0");
        }
        double a = customers[customerId].TotalSpent + amount;
        if (a > 40000)
        {
            customers[customerId].IsPremium = true;
        }
        customers[customerId].TotalSpent += customers[customerId].IsPremium ? 0.90 * amount : amount;
        shops[shopId].Revenue += a > 40000 ? 0.90 * amount : amount;
    }
    public List<IShop> GetTopRevenueShops(int n)
    {
        return shops.Values.OrderByDescending(x => x.Revenue).Take(n).ToList();
    }
    public Dictionary<string, double> CategoryWiseRevenue()
    {

        return shops.Values.GroupBy(c => c.Category).ToDictionary(x => x.Key, x => x.Sum(s=>s.Revenue));
     }
    public List<ICustomer> GetPremiumCustomers()
    {
        return customers.Values.Where(x => x.IsPremium).ToList();
    }
    public double GetTotalMallRevenue()
    {
        return shops.Values.Sum(x => x.Revenue);
    }

    public void RemoveShop(string shopId)
    {
        if (!shops.ContainsKey(shopId))
        {
            throw new MallException("Shop Donot exists");
        }
        shops.Remove(shopId);
    }
}

#endregion

#region MAIN METHOD (15 DIFFICULT TEST CASES)

class Program
{
    static void Main()
    {
        Mall mall = new Mall();

        mall.Notify += msg => Console.WriteLine("EVENT: " + msg);

        try
        {
            // 1
            mall.AddShop(new Shop { ShopId = "S1", ShopName = "Zara", Category = "Clothing" });

            // 2
            mall.AddShop(new Shop { ShopId = "S2", ShopName = "Nike", Category = "Sports" });

            // 3
            mall.AddShop(new Shop { ShopId = "S3", ShopName = "Apple", Category = "Electronics" });

            // 4
            mall.RegisterCustomer(new Customer { CustomerId = "C1", Name = "Aman" });

            // 5
            mall.RegisterCustomer(new Customer { CustomerId = "C2", Name = "Rahul" });

            // 6
            mall.MakePurchase("C1", "S1", 2000);

            // 7
            mall.MakePurchase("C1", "S3", 50000);

            // 8
            mall.MakePurchase("C2", "S2", 15000);

            // 9 (Edge case – negative purchase)
            mall.MakePurchase("C2", "S2", -100);

            // 10 (Duplicate shop)
            mall.AddShop(new Shop { ShopId = "S1", ShopName = "Duplicate", Category = "Test" });

            // 11 (Invalid customer)
            mall.MakePurchase("C99", "S1", 1000);

            // 12 Remove Shop
            mall.RemoveShop("S2");

            // 13 Remove non-existing shop
            mall.RemoveShop("S9");

            // 14 Get Top Revenue Shops
            var top = mall.GetTopRevenueShops(2);
            foreach (var s in top)
                Console.WriteLine(s.ShopName + " Revenue: " + s.Revenue);

            // 15 Category Wise Revenue
            var cat = mall.CategoryWiseRevenue();
            foreach (var c in cat)
                Console.WriteLine(c.Key + " : " + c.Value);

            Console.WriteLine("Premium Customers:");
            foreach (var c in mall.GetPremiumCustomers())
                Console.WriteLine(c.Name);

            Console.WriteLine("Total Mall Revenue: " + mall.GetTotalMallRevenue());
        }
        catch (MallException ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }
    }
}

#endregion