using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAspIn.Models;

namespace WebAspIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly EmpContext _context;
        public EmpController(EmpContext context)
        {
            _context = context;
        }
        [HttpGet]
        //public List<Employee> getemployees()
        //{
        //    return _context.employees.ToList();
        //}
        public async Task<ActionResult<List<Employee>>> getemployees()
        {
            return Ok(await _context.employees.ToListAsync());
        }

        [HttpGet("emp2")]
        public List<Employee> getemployees2()
        {
            return _context.employees.ToList();
        }
        [HttpPost]
        [Route("emp_post2")]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee emp)
        {
            await _context.employees.AddAsync(emp);
            await _context.SaveChangesAsync();

            return Ok(emp);
        }
        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee emp)
        {

            var employee = await _context.employees.FindAsync(emp.Id);
            if (employee == null)
            {
                return BadRequest("Emp is not found");
            }
            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;
            employee.Email = emp.Email;
            employee.Age = emp.Age;

            await _context.SaveChangesAsync();

            return Ok(await _context.employees.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteEmployee(int id)
        {
            var employee = await _context.employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok("Employee deleted successfully");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _context.employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(employee);
        }
    }
}
