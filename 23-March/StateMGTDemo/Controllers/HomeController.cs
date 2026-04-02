using Microsoft.AspNetCore.Mvc;
using StateMGTDemo.Models;
using System.Diagnostics;

namespace StateMGTDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private int a = 0;
        [HttpPost]
        public IActionResult SetA()
        {
            a = 10;
            ViewBag.Avalue = "A has been set to 10";
            return View("Index");
        }
        [HttpPost]
        public IActionResult GetA()
        {
            
            ViewBag.Avalue = $"A is currently : {a}";
            return View("Index");
        }
        
        public IActionResult Index()
        {
            TempData["mykey"] = "Data from index method";
            return View();
        }
        public IActionResult Index1()
        {
            ViewBag.MyKey = TempData["mykey"];
            TempData.Peek("mykey");
            return View();
        }
        public IActionResult Index2()
        {
            ViewBag.MyKey = TempData["mykey"];
            TempData.Peek("mykey");
            return View();
        }
        public IActionResult Index3()
        {
            ViewBag.MyKey = TempData["mykey"];
            
            return View();
        }
        public IActionResult Index4()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
