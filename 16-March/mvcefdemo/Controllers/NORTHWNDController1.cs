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
    }


}
