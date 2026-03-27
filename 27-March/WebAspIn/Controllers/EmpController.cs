using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAspIn.Models;
using ClosedXML.Excel;
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
        public async Task<ActionResult<Employee>> AddEmp([FromForm] Employee emp, IFormFile ?image)
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
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Update(
        int id, [FromForm] EmployeeUpdateDto employeeDto, IFormFile? image)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // map dto to entity
            var employee = new Employee
            {
                Id = id, 
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Age = employeeDto.Age,
                ImagePath = employeeDto.ImagePath
            };

            var updated = await _employeeService.UpdateEmployeeAsync(employee, image);
            if (updated == null)
                return NotFound("Employee not found to update");

            return Ok(updated);
        }
        [HttpGet("basic")]
        public async Task<ActionResult<List<EmployeeBasicDto>>> GetAllBasicEmployees(
    int pageNumber = 1, int pageSize = 5, string? searchTerm = null)
        {
            var employees = await _employeeService.GetAllEmployeeBasicInfoAsync(pageNumber, pageSize, searchTerm);
            return Ok(employees);
        }
        [HttpGet("basic2")]
        public async Task<ActionResult<List<Employee>>> GetAllBasic(
    int pageNumber = 1, int pageSize = 5, string? searchTerm = null)
        {
            var employees = await _employeeService.GetAllEmpasicInfoAsync(pageNumber, pageSize, searchTerm);
            return Ok(employees);
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
        [HttpGet("export/excel")]
        public async Task<IActionResult> ExportToExcel(string? search = null)
        {
            var employees = await _employeeService.GetAllEmployeeBasicInfoAsync(1, int.MaxValue, search);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Employees");

            worksheet.Cell(1, 1).Value = "First Name";
            worksheet.Cell(1, 2).Value = "Last Name";
            worksheet.Cell(1, 3).Value = "Email";
            worksheet.Cell(1, 4).Value = "Image URL";

            int row = 2;
            foreach (var emp in employees)
            {
                worksheet.Cell(row, 1).Value = emp.FirstName;
                worksheet.Cell(row, 2).Value = emp.LastName;
                worksheet.Cell(row, 3).Value = emp.Email;
                worksheet.Cell(row, 4).Value = emp.ImageUrl;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employees.xlsx");
        }

    }
}