namespace Navproperties
{
    
        public class Customer
        {
            public int CustomerID { set; get; }
            public string FirstName { get; set; }

            public string LastName { set; get; }

            public string EmailAdress { set; get; }

            public List<Invoice> InvoiceList { set; get; } = new List<Invoice>();
        }
        public class Invoice
        {
            public int InvoiceID { set; get; }
            public int CustomerID { set; get; }

            public DateTime InvoiceDate { set; get; }

            public DateTime DueDate { get; set; }

            public bool? IsPaid { set; get; }

            public Decimal Amount { set; get; }

            public Customer Customer { set; get; }
        }

        public class Repository
        {
            public static List<Invoice> RetriveInvoices(int customerid)
            {
                List<Invoice> inv_list = new List<Invoice>
            {
              new Invoice { InvoiceID = 1, CustomerID =101, InvoiceDate = new DateTime(2013, 6, 20),
                  DueDate = new DateTime(2013, 8, 29), IsPaid = true,Amount=34590 },
              new Invoice { InvoiceID = 2, CustomerID =101, InvoiceDate = new DateTime(2012, 6, 20),
                  DueDate = new DateTime(2012, 8, 29), IsPaid = false,Amount=44000 },
              new Invoice { InvoiceID = 3, CustomerID =102, InvoiceDate = new DateTime(2016, 6, 20),
                  DueDate = new DateTime(2016, 8, 29), IsPaid = true,Amount=34590 },
              new Invoice { InvoiceID = 4, CustomerID =103, InvoiceDate = new DateTime(2013, 6, 20),
                  DueDate = new DateTime(2013, 8, 29), IsPaid = false,Amount=45890 },
              new Invoice { InvoiceID = 5, CustomerID =104, InvoiceDate = new DateTime(2010, 6, 20),
                  DueDate = new DateTime(2010, 8, 29), IsPaid = false,Amount=45678 },
              new Invoice { InvoiceID = 6, CustomerID =105, InvoiceDate = new DateTime(2021, 6, 20),
                  DueDate = new DateTime(2021, 8, 29), IsPaid = true,Amount=36590 },




            };

                List<Invoice> filteredlist = inv_list.Where(i => i.CustomerID == customerid).ToList();
                return filteredlist;
            }
            public static List<Customer> custretrive()
            {
                List<Customer> custlist = new List<Customer>()
            {
                new Customer {CustomerID=101,FirstName="mahesh",LastName="kumar" ,
                 EmailAdress="mahesh@gmail.com",InvoiceList=RetriveInvoices(101)},
                 new Customer {CustomerID=102,FirstName="suresh",LastName="kumar" ,
                 EmailAdress="suresh@gmail.com",InvoiceList=RetriveInvoices(102)},
                 new Customer {CustomerID=103,FirstName="sudha",LastName="kumar" ,
                 EmailAdress="sudha@gmail.com",InvoiceList=RetriveInvoices(103)},
                 new Customer {CustomerID=104,FirstName="suresh",LastName="kumar" ,
                 EmailAdress="suresh@gmaillcom",InvoiceList=RetriveInvoices(104)},
                 new Customer {CustomerID=105,FirstName="rajesh",LastName="kumar" ,
                 EmailAdress="rajesh@gmail.com",InvoiceList=RetriveInvoices(105)}
            };
                foreach (var customer in custlist)
                {
                    customer.InvoiceList = RetriveInvoices(customer.CustomerID);

                    foreach (var invoice in customer.InvoiceList)
                    {
                        invoice.Customer = customer;
                    }
                }
                return custlist;
            }

        }

        internal class Program
        {

            static void Main(string[] args)
            {
                var cust_list = Repository.custretrive();
                var customer = cust_list.FirstOrDefault(c => c.CustomerID == 101);

                Console.WriteLine($"List of invoice of custid 101 is :");

                foreach (var i in customer.InvoiceList)
                {
                    Console.WriteLine($"InvoiceID: {i.InvoiceID}, CustomerID: {i.CustomerID}, " +
                                      $"Name: {customer.FirstName} {customer.LastName}, " +
                                      $"InvoiceDate: {i.InvoiceDate}, DueDate: {i.DueDate}, " +
                                      $"IsPaid: {i.IsPaid}, Amount: {i.Amount}");
                }

                //now how u are going to display a custlist whch in turn has a invoice list for each customer
                List<Customer> custlist = Repository.custretrive();
                Console.WriteLine("\n List of customers with thier invocies ");
                Console.WriteLine("===========================================");
                foreach (Customer cust in custlist)
                {
                    Console.WriteLine($"{cust.FirstName} {cust.LastName}  has raised " +
                        $" {cust.InvoiceList.Count} invoices ");
                    Console.WriteLine("----------------------------------------------");
                    foreach (var invitem in cust.InvoiceList)
                    {
                        Console.WriteLine($"{invitem.InvoiceID} --{invitem.Customer.FirstName}");
                    }
                }
            Console.WriteLine("\n List of customers with thier invocies using selectmany ");
            Console.WriteLine("===========================================");



            var allcustomerinvoices = custlist
    .SelectMany(cust => cust.InvoiceList,
         (cust, inv) => new { Customer = cust, Invoice = inv });

            int? lastCustomerId = null;

            foreach (var item in allcustomerinvoices)
            {
                // Print customer header only once
                if (lastCustomerId != item.Customer.CustomerID)
                {
                    Console.WriteLine($"{item.Customer.FirstName} {item.Customer.LastName} has raised " +
                        $"{item.Customer.InvoiceList.Count} invoices");

                    Console.WriteLine("----------------------------------------------");

                    lastCustomerId = item.Customer.CustomerID;
                }

                Console.WriteLine($"{item.Invoice.InvoiceID} --- {item.Customer.FirstName}");
            }
             

            Console.WriteLine("===unpaid invocies ==========");
                foreach (Customer c in custlist)
                {
                    foreach (Invoice inv in c.InvoiceList)
                    {
                        if (inv.IsPaid == false)
                        {
                            Console.WriteLine($" Invoice with {inv.InvoiceID} is in due " +
                                $"{inv.DueDate} of about " +
                                $"{inv.Amount} from {inv.Customer.FirstName}");
                        }
                    }
                }
            }
        }
    }


