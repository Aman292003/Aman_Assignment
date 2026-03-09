using System;
using System.Collections.Generic;

/* =====================================================
                    CUSTOMER SECTION
===================================================== */

abstract class Customer
{
    public string CustomerName { get; set; }
    public string CustomerID { get; set; }

    public abstract double CalculateDiscount(double amount);

    public virtual void DisplayCustomerDetails()
    {
        Console.WriteLine($"Customer: {CustomerName}, ID: {CustomerID}");
    }
}

interface IServiceEligible
{
    void RequestService();
    bool IsEligibleForFreeDelivery(double orderValue);
}

/* ---------- Regular Customer ---------- */
class RegularCustomer : Customer, IServiceEligible
{
    public int LoyaltyPoints { get; set; }

    public override double CalculateDiscount(double amount)
    {
        return LoyaltyPoints > 100 ? amount * 0.05 : amount * 0.02;
    }

    public void RequestService()
    {
        Console.WriteLine("Standard Delivery");
    }

    public bool IsEligibleForFreeDelivery(double orderValue)
    {
        return orderValue > 500;
    }
}

/* ---------- VIP Customer ---------- */
class VIPCustomer : Customer, IServiceEligible
{
    public string MembershipTier { get; set; }
    public double AnnualSpend { get; set; }

    public override double CalculateDiscount(double amount)
    {
        if (MembershipTier.Equals("Gold", StringComparison.OrdinalIgnoreCase))
            return amount * 0.15;

        if (MembershipTier.Equals("Platinum", StringComparison.OrdinalIgnoreCase))
            return amount * 0.20;

        return 0;
    }

    public void RequestService()
    {
        Console.WriteLine($"{MembershipTier} Tier Priority Delivery");
    }

    public bool IsEligibleForFreeDelivery(double orderValue)
    {
        return true;
    }
}

/* =====================================================
                    ORDER SECTION
===================================================== */

abstract class Order
{
    public string OrderID { get; set; }
    public string CustomerName { get; set; }
    public double TotalAmount { get; set; }

    public abstract double ProcessOrder();

    public virtual void DisplayOrderSummary()
    {
        Console.WriteLine($"OrderID: {OrderID}, Customer: {CustomerName}, Amount: {TotalAmount}");
    }
}

interface IDeliverable
{
    double CalculateShippingCost(double distance);
    int EstimateDeliveryDays();
}

/* ---------- Standard Order ---------- */
class StandardOrder : Order, IDeliverable
{
    public int ItemsCount { get; set; }

    public override double ProcessOrder()
    {
        return ItemsCount * 2;
    }

    public double CalculateShippingCost(double distance)
    {
        return distance * 0.5;
    }

    public int EstimateDeliveryDays()
    {
        return 4;
    }
}

/* ---------- Express Order ---------- */
class ExpressOrder : Order, IDeliverable
{
    public int PriorityLevel { get; set; }

    public override double ProcessOrder()
    {
        return PriorityLevel;
    }

    public double CalculateShippingCost(double distance)
    {
        return distance * 1.2;
    }

    public int EstimateDeliveryDays()
    {
        return 2;
    }
}

/* =====================================================
                        MAIN
===================================================== */

class Solution
{
    static void Main()
    {
        List<Customer> customers = new List<Customer>();
        List<Order> orders = new List<Order>();

        /* -------- CUSTOMER INPUT -------- */
        int customerCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < customerCount; i++)
        {
            string type = Console.ReadLine(); // REGULAR or VIP
            string name = Console.ReadLine();
            string id = Console.ReadLine();

            if (type.Equals("REGULAR", StringComparison.OrdinalIgnoreCase))
            {
                int points = int.Parse(Console.ReadLine());

                customers.Add(new RegularCustomer
                {
                    CustomerName = name,
                    CustomerID = id,
                    LoyaltyPoints = points
                });
            }
            else
            {
                string tier = Console.ReadLine();
                double spend = double.Parse(Console.ReadLine());

                customers.Add(new VIPCustomer
                {
                    CustomerName = name,
                    CustomerID = id,
                    MembershipTier = tier,
                    AnnualSpend = spend
                });
            }
        }

        double orderAmount = double.Parse(Console.ReadLine());

        Console.WriteLine("===== CUSTOMER DETAILS =====");

        foreach (Customer c in customers)
        {
            c.DisplayCustomerDetails();

            double discount = c.CalculateDiscount(orderAmount);
            Console.WriteLine($"Discount: {discount}");

            IServiceEligible service = (IServiceEligible)c;
            service.RequestService();

            Console.WriteLine($"Free Delivery: {service.IsEligibleForFreeDelivery(orderAmount)}");
            Console.WriteLine("-----");
        }

        /* -------- ORDER INPUT -------- */
        int orderCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < orderCount; i++)
        {
            string type = Console.ReadLine(); // STANDARD or EXPRESS
            string orderId = Console.ReadLine();
            string customerName = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            if (type.Equals("STANDARD", StringComparison.OrdinalIgnoreCase))
            {
                int items = int.Parse(Console.ReadLine());

                orders.Add(new StandardOrder
                {
                    OrderID = orderId,
                    CustomerName = customerName,
                    TotalAmount = amount,
                    ItemsCount = items
                });
            }
            else
            {
                int priority = int.Parse(Console.ReadLine());

                orders.Add(new ExpressOrder
                {
                    OrderID = orderId,
                    CustomerName = customerName,
                    TotalAmount = amount,
                    PriorityLevel = priority
                });
            }
        }

        double distance = double.Parse(Console.ReadLine());

        Console.WriteLine("===== ORDER PROCESSING =====");

        double totalProcessingTime = 0;

        foreach (Order o in orders)
        {
            o.DisplayOrderSummary();

            double time = o.ProcessOrder();
            totalProcessingTime += time;

            IDeliverable delivery = (IDeliverable)o;

            Console.WriteLine($"Processing Time: {time}");
            Console.WriteLine($"Shipping Cost: {delivery.CalculateShippingCost(distance)}");
            Console.WriteLine($"Delivery Days: {delivery.EstimateDeliveryDays()}");

            Console.WriteLine("-----");
        }

        Console.WriteLine($"Total Processing Time: {totalProcessingTime}");
    }
}