using Microsoft.AspNetCore.Mvc;

namespace WebAspIn.Controllers
{
    public class EmployeeUIController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Employee Data";
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Add New Employee";
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Employee";
            ViewBag.EmployeeId = id;
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewBag.Title = "Employee Details";
            ViewBag.EmployeeId = id;
            return View();
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Title = "Delete Employee";
            ViewBag.EmployeeId = id;
            return View();
        }

        public IActionResult Export()
        {
            ViewBag.Title = "Employee Export";
            return View();
        }
    }
}