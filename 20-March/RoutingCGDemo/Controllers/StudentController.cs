using Microsoft.AspNetCore.Mvc;
using RoutingCGDemo.Models;

namespace RoutingCGDemo.Controllers
{
    public class StudentController : Controller
    {
        List<Student> stulist = new List<Student>() {
            new Student {Id = 101 ,Name = "Kiran" ,Class = "class4"},
            new Student {Id = 102 ,Name = "Mohan" ,Class = "class7"},
            new Student {Id = 103 ,Name = "Suhana" ,Class = "class8"},
            };
        [Route("studs")]
        public IActionResult GetAllStudent()
        {
            return View(stulist);
        }
        [Route("studs/{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = stulist.FirstOrDefault(x => x.Id == id);
            return View(student);  
        }
        public IActionResult getfewcolumns()
        {
            var fewrow = stulist.Select(s => new Student
            {
                Class = s.Class,
                Name = s.Name
            }).ToList();
            return View(fewrow);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
