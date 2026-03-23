using Microsoft.AspNetCore.Mvc;
using mvcdemo.Models;
using System.Diagnostics;

namespace mvcdemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public string sampledemo1 ()
        {
          
            return "hello";
        }
        
        public string sampledemo2(string name)
        {
            return "hello ," + name;
        }

        public IActionResult sampledemo3()
        {
            int age = 23;
            string name = "Sam";
            ViewBag.Name = name;
            ViewBag.Age = age;

            ViewData["Message"] = "Welcome to Asp .net Core";

            ViewData["Year"] = DateTime.Now.Year;
            return View();
        }
        Employee obj = new Employee()
        {
            EmployeeId = 1,
            EmpName = "Aman",
            Salary = 34000
        };

        List<Employee> emp = new List<Employee>()
        {
            new Employee{EmployeeId =1 , EmpName = "Steve Rogers" ,Salary = 5000000 ,ImageUrl = "/Image/cap.jpg"},
            new Employee{EmployeeId =2 , EmpName = "Tom Cruise" ,Salary = 7000000 ,ImageUrl = "/Image/tom.jpg"}

        };
        public IActionResult multipleobjectpassing()
        {
            return View(emp);
        }
        public IActionResult singleobjectpassing()
        {
            return View(obj);
        }

        
        public IActionResult display()
        {
            return View();
        }

        public IActionResult Index()
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
