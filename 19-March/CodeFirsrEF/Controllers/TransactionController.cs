using CodeFirsrEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeFirsrEF.Controllers
{
    public class TransactionController : Controller
    {
        private readonly EventContext _context;

        public TransactionController(EventContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult CreateCustomer()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult CreateCustomer(Customer cust)
        {
            if (ModelState.IsValid)
            {
                _context.customers.Add(cust);   
                _context.SaveChanges();

                return Content("Customer Added Successfully");
            }
            return View(cust);
        }
        public IActionResult CreateProduct(int? customerId = null)
        {
            var cid = customerId ?? 0;
            ViewBag.CustomerId = cid;
            ViewBag.CustomerList = new SelectList(_context.customers,
                "CustomerID", "CustomerName", cid);
            return View();

        }


        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            ModelState.Clear();
            ModelState.Remove(nameof(product.ProductId));
            if (ModelState.IsValid)
            {
                _context.products.Add(product);
                _context.SaveChanges();
                return RedirectToAction
                    ("CreateProduct", new { customerId = product.CustomerId });
            }
            // preserving values 
            ViewBag.customerId = product.CustomerId;
            ViewBag.CustomerList = new SelectList(_context.customers,
               "CustomerID", "CustomerName", product.CustomerId);
            return View(product);
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}