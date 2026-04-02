using System.Collections;
namespace generic
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public static List<Customer> Retrieve()
        {
            List<Customer> clist = new List<Customer>()
            {
            new Customer {CustomerID=101,CustomerName="ravi"},
            new Customer {CustomerID=102,CustomerName="Sita"},
            new Customer {CustomerID=103,CustomerName="sohan"},
            };
            return clist;
        }
        public static void PrintCustomers(List<Customer> customers)
        {
            foreach (Customer c in customers)
            {
                Console.WriteLine($"ID:{c.CustomerID}, Name:{c.CustomerName}");
            }
        } 
        public static void insertCustomer(List<Customer> customers, Customer customer)
        {
            customers.Add(customer);
        } 
        public static bool findCustomer(List<Customer> customers, int customerID)
        {
            foreach (Customer c in customers)
            {
                if (c.CustomerID == customerID)
                {
                    Console.WriteLine($"{c.CustomerName} is found with {customerID}");
                    return true;
                }
            }
            Console.WriteLine($"{customerID} is not found");
            return false;
        }
        public static void deleteCustomer(List<Customer> customers, int customerID)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].CustomerID == customerID)
                {
                    customers.RemoveAt(i);
                    break;
                }
            }
        }
        public static void updateCustomer(List<Customer> customers, Customer customer)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].CustomerID == customer.CustomerID)
                {
                    customers[i].CustomerName = customer.CustomerName;
                    break;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);

            List<string> words = new List<string>()
            {
                "ravi",
                "ram",
                "shyam"
            };
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
            var array = new int[] { 1, 2, 3, 4, 5, 2, 4, 2, 8 };
            var result = new List<int>();
            foreach (int n in array)
            {
                bool found = false;
                foreach (int r in result)
                {
                    if (n == r)
                    {
                        found = true;

                    }
                    if (!found)
                    {
                        result.Add(n);
                    }
                }
            }
            List<Customer> customers = Customer.Retrieve();
            Customer.PrintCustomers(customers);
            Customer newCustomer = new Customer { CustomerID = 104, CustomerName = "rahul" };
            Customer.findCustomer(customers, 102);
            Customer.updateCustomer(customers, new Customer { CustomerID = 103, CustomerName = "sonu" });
            Customer.deleteCustomer(customers, 101);
            Customer.PrintCustomers(customers);
            var duplicates = new List<int>() { 1, 2, 3, 4, 5, 2, 4, 2, 8 };
        }
    }
}
