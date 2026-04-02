using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAspIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new
            {
                message = "Admin test API is working",
                time = DateTime.UtcNow
            });
        }

        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            var roles = User.Claims
                .Where(claim => claim.Type == ClaimTypes.Role)
                .Select(claim => claim.Value)
                .ToList();

            return Ok(new
            {
                isAuthenticated = User.Identity?.IsAuthenticated ?? false,
                userName = User.Identity?.Name,
                roles
            });
        }

        [Authorize(Roles = "Admin,HR")]
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return Ok(new
            {
                message = "Welcome to the admin dashboard",
                features = new[]
                {
                    "Role-based authorization check",
                    "JWT token validation",
                    "Protected admin endpoint"
                }
            });
        }

       

        [Authorize(Roles = "Admin")]
        [HttpPost("assign-hr/{userName}")]
        public async Task<IActionResult> AssignHrRole(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            if (!await _roleManager.RoleExistsAsync("HR"))
            {
                await _roleManager.CreateAsync(new IdentityRole("HR"));
            }

            if (await _userManager.IsInRoleAsync(user, "HR"))
            {
                return Ok(new { message = "User already has HR role" });
            }

            var result = await _userManager.AddToRoleAsync(user, "HR");
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(error => error.Description));
            }

            return Ok(new { message = $"HR role assigned to {userName}" });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("remove-hr/{userName}")]
        public async Task<IActionResult> RemoveHrRole(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            if (!await _userManager.IsInRoleAsync(user, "HR"))
            {
                return Ok(new { message = "User does not have HR role" });
            }

            var result = await _userManager.RemoveFromRoleAsync(user, "HR");
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(error => error.Description));
            }

            return Ok(new { message = $"HR role removed from {userName}" });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = new List<object>();

            foreach (var user in _userManager.Users.ToList())
            {
                var roles = await _userManager.GetRolesAsync(user);
                users.Add(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    
                    roles
                });
            }

            return Ok(users);
        }
    }
}
