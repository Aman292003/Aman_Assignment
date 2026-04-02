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
        private readonly IEmployee _employeeService;

        public EmpController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll(int pageNumber = 1, int pageSize = 5)
        {
            var employees = await _employeeService.GetAllEmployeesAsync(pageNumber, pageSize);
            return Ok(employees);
        }

        // ✅ GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
                return NotFound("Employee not found");

            return Ok(employee);
        }

        // ✅ ADD EMPLOYEE (with image)
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmp([FromForm] Employee emp, IFormFile image)
        {
            var result = await _employeeService.AddEmployeeAsync(emp, image);
            return Ok(result);
        }

        // ✅ UPDATE EMPLOYEE (with optional image)
        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmp([FromForm] Employee emp, IFormFile? image)
        {
            var employee = await _employeeService.UpdateEmployeeAsync(emp, image);

            if (employee == null)
                return NotFound("Employee not found");

            return Ok(employee);
        }

        // ✅ DELETE EMPLOYEE
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);

            if (result == null)
                return NotFound("Employee not found");

            return Ok("Employee deleted successfully");
        }
    }
}