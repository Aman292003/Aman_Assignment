using Microsoft.AspNetCore.Mvc;
using mvcefdemo.Models;

namespace mvcefdemo.Controllers
{
    public class NORTHWNDController1 : Controller
    {

        public IActionResult SpainCustomers()

        {
            NORTHWNDContext cnt = new NORTHWNDContext();
            var spain = cnt.Customers
               .Where(c => c.Country == "Spain")
               .Select(x => new SpainCustomer
               {
                   CId = x.CustomerId,
                   CName = x.CompanyName,
                   Contact = x.ContactName
               }).ToList();

            return View(spain);
        }
        public IActionResult searchCustomer()
        {
            NORTHWNDContext cnt = new NORTHWNDContext();
            var searchCustomer = from Customer in cnt.Customers
                                 where Customer.ContactName == "Maria Anders"
                                 select new Customer
                                 {
                                     ContactName = Customer.ContactName,
                                     ContactTitle = Customer.ContactTitle,
                                     CompanyName = Customer.CompanyName,

                                 };
            //var searchcustomer2 = cnt.Customers.Where(x => x.ContactName == contactname)
            // .Select(x => new Customer
            // {
            //     ContactName = x.ContactName,
            //     ContactTitle = x.ContactTitle,
            //     CompanyName = x.CompanyName
            // });
            var query1 = searchCustomer.Single();
            // var query2 = searchcustomer2.Single();
            return View(query1);

        }
        public ActionResult ProductInCategory(string categoryname)
        {
            NORTHWNDContext cnt = new NORTHWNDContext();

            if (string.IsNullOrEmpty(categoryname))
                return View(new List<ProdCat>());

            var prod = cnt.Products
                .Where(x => x.Category.CategoryName == categoryname)
                .Select(c => new ProdCat
                {
                    prodname = c.ProductName,
                    catname = c.Category.CategoryName
                }).ToList();

            return View(prod);
        }
        public ActionResult OrderRange(string range) {

            NORTHWNDContext cnt = new NORTHWNDContext();
            var range1 = Convert.ToInt16(range);
            var custorder = cnt.Customers
                .Where(x => x.Orders.Count > range1)
                .Select(c => new Customer
                {
                    CustomerId = c.CustomerId,
                    ContactName = c.ContactName
                });


            return View(custorder);
        }
        public IActionResult CustomerOrderDetails(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return View(new List<Order>()); // return empty if no customer

            NORTHWNDContext cnt = new NORTHWNDContext();

            // Fetch all orders for the given customer
            var orders = cnt.Orders
                .Where(o => o.CustomerId == customerId)
                .Select(o => new Order
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate,
                    ShipName = o.ShipName,
                    ShipCity = o.ShipCity,
                    Freight = o.Freight
                })
                .ToList();

            ViewBag.CustomerId = customerId;
            ViewBag.OrderCount = orders.Count;

            return View(orders);
        }
    }


}
