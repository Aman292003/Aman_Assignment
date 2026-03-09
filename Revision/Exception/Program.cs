using System;
using System.Collections.Generic;

/* ---------- CUSTOM EXCEPTION ---------- */
class InvalidOrderException : Exception
{
    public InvalidOrderException(string message) : base(message) { }
}


/* ---------- ORDER CLASS ---------- */
class Order
{
    public int OrderId;
    public string CustomerName;
    public double ProductPrice;
    public int Quantity;

    public Order(int id, string name, double price, int qty)
    {
        OrderId = id;
        CustomerName = name;
        ProductPrice = price;
        Quantity = qty;
    }
}


/* ---------- ORDER PROCESSOR ---------- */
class OrderProcessor
{
    public static double ProcessOrder(Order o)
    {
        if(o.ProductPrice<0|| o.Quantity < 0)
        {
            throw new InvalidOrderException(o.OrderId +" is InValid Order");
        }
        
        double total = o.ProductPrice * o.Quantity;
        if (total > 5000)
        {
            return total * 0.80;
        }
        else if (total > 2000)
        {
            return total * 0.90;
        }
        return total;
    }
}


/* ---------- MAIN ---------- */
class Program
{
    static void Main()
    {
        List<Order> orders = new List<Order>()
        {
            new Order(101,"Aman",600,3),
            new Order(102,"Riya",1200,4),
            new Order(103,"Karan",-500,2), // invalid
            new Order(104,"Simran",2000,4)
        };

        double totalRevenue = 0;
        double highestOrder = 0;
        int invalidCount = 0;
        Program P = new Program();

        foreach (Order o in orders)
        {
            try
            {

                double amount = OrderProcessor.ProcessOrder(o);
                Console.WriteLine(o.OrderId + "is Processed");
                totalRevenue += amount;
                highestOrder = Math.Max(amount, highestOrder);
               
            }
            catch (InvalidOrderException e)
            {
                invalidCount++;
                Console.WriteLine(e.Message);

            }
        }

        Console.WriteLine("\nTotal Revenue = " + totalRevenue);
        Console.WriteLine("Invalid Orders = " + invalidCount);
        Console.WriteLine("Highest Order Value = " + highestOrder);
    }
}