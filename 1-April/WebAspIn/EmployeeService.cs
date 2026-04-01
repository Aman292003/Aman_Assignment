using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebAspIn.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebAspIn
{
    public class EmployeeService : IEmployee
    {
        private readonly EmpContext _context;
        private readonly IWebHostEnvironment _env;
        public EmployeeService(EmpContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var imagepath = Path.Combine(_env.WebRootPath, "uploads", imageName);
                Directory.CreateDirectory(Path.GetDirectoryName(imagepath));
                using var stream = new FileStream(imagepath, FileMode.Create);
                await image.CopyToAsync(stream);
                employee.ImagePath = "/uploads/" + imageName;
            }
            await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;

        }

        public async Task<Employee?> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;

        }
        public async Task<List<Employee>> GetAllEmpasicInfoAsync(int pageNumber, int pageSize, string? searchTerm)
        {
            var query = _context.employees.AsQueryable();

            // 🔍 Optional search
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(e =>
                    e.FirstName!.ToLower().Contains(searchTerm) ||
                    e.LastName!.ToLower().Contains(searchTerm) ||
                    e.Email!.ToLower().Contains(searchTerm));

            }

            // 🧾 Pagination
            var employees = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new Employee
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Age = e.Age,
                    ImagePath = string.IsNullOrEmpty(e.ImagePath)
                               ? "/uploads/default.png"  // default image if none
                               : e.ImagePath
                })
                .ToListAsync();

            return employees;
        }

        public async Task<List<EmployeeBasicDto>> GetAllEmployeeBasicInfoAsync(int pageNumber, int pageSize, string? searchTerm)
        {
            var query = _context.employees.AsQueryable();

            // 🔍 Optional search
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(e =>
                    e.FirstName!.ToLower().Contains(searchTerm) ||
                    e.LastName!.ToLower().Contains(searchTerm) ||
                    e.Email!.ToLower().Contains(searchTerm));
            }

            // 🧾 Pagination
            var employees = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new EmployeeBasicDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    ImageUrl = string.IsNullOrEmpty(e.ImagePath)
                               ? "/uploads/default.png"  // default image if none
                               : e.ImagePath
                })
                .ToListAsync();

            return employees;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(int pageNumber, int pageSize)
        {

            return await _context.employees.
                Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.employees.FindAsync(id);
        }

        public async Task<Employee?> UpdateEmployeeAsync(Employee employee, IFormFile? image)
        {
            var existing = await _context.employees.FindAsync(employee.Id);

            if (existing == null)
                return null;

            // Update basic fields
            existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.Email = employee.Email;
            existing.Age = employee.Age;

            // ✅ Handle image replacement
            if (image != null && image.Length > 0)
            {
                // 🔴 Delete old image
                if (!string.IsNullOrEmpty(existing.ImagePath))
                {
                    var oldImagePath = Path.Combine(_env.WebRootPath, existing.ImagePath.TrimStart('/'));

                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                // 🟢 Save new image
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var newImagePath = Path.Combine(_env.WebRootPath, "uploads", imageName);

                Directory.CreateDirectory(Path.GetDirectoryName(newImagePath)!);

                using var stream = new FileStream(newImagePath, FileMode.Create);
                await image.CopyToAsync(stream);

                // ✅ Update DB path
                existing.ImagePath = "/uploads/" + imageName;
            }

            await _context.SaveChangesAsync();

            return existing;
        }
    }
}
