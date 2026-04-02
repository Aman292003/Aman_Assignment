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
        public IActionResult Details(int id)
        {
            var employee = emp.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult  Search(int id)
        {
            var employee = emp.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
            //Employee emp =(from e1 in emplist where e1.EmployeeId.select
        }
        Employee obj = new Employee()
        {
            EmployeeId = 1,
            EmpName = "Aman",
            Salary = 34000
        };
        

        List<Employee> emp = new List<Employee>()
        {
            new Employee{EmployeeId =1 , EmpName = "Steve Rogers" ,Salary = 5000000 ,ImageUrl = "/images/cap.jpg" , DeptId =20},
            new Employee{EmployeeId =2 , EmpName = "Tom Cruise" ,Salary = 7000000 ,ImageUrl = "/images/tom.jpg",DeptId = 10},
            new Employee{EmployeeId =3 , EmpName = "Captain America" ,Salary = 5600000 ,ImageUrl = "/images/cap.jpg" , DeptId =30},
            new Employee{EmployeeId =4 , EmpName = "Maverick" ,Salary = 7500000 ,ImageUrl = "/images/tom.jpg",DeptId = 10},

        };
        List<Department> deptlist = new List<Department>()
     {
         new Department{DeptId=10,DeptName="Sales"},
         new Department{DeptId=20,DeptName="HR"},
         new Department{DeptId=30,DeptName="Software"}
     };
        public IActionResult collectionofdept()
        {
            return View(deptlist);
        }
        public IActionResult multipleobjectpassing()
        {
            return View(emp);
        }

        public IActionResult singleobjectpassing()
        {
            return View(obj);
        }
        public IActionResult mixedobjpass(int empid)
        {
            var query1 = deptlist.ToList();
            var query2 = emp.Where(x => x.EmployeeId == empid).FirstOrDefault();

            empdeptview obj = new empdeptview()
            {
                deptlist = query1,
                emp = query2,
                date = DateTime.Now
            };

            return View(obj);
        }
        public IActionResult empindept(int deptid)
        {
            return View(emp.Where(e => e.DeptId == deptid).ToList());
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
