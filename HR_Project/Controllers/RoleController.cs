using HR_Project.Constants;
using HR_Project.DTO;
using HR_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private static List<Permissions_HR> permissions = new List<Permissions_HR>

        {
            new Permissions_HR { Id = 1, Name = "Permissions.Attendance.View"},
            new Permissions_HR { Id = 2, Name = "Permissions.Attendance.Create" },
            new Permissions_HR { Id = 3, Name = "Permissions.Attendance.Edit" },
            new Permissions_HR { Id = 4, Name = "Permissions.Attendance.Delete" },
            new Permissions_HR { Id = 5, Name = "Permissions.Employee.View"},
            new Permissions_HR { Id = 6, Name = "Permissions.Employee.Create" },
            new Permissions_HR { Id = 7, Name = "Permissions.Employee.Edit" },
            new Permissions_HR { Id = 8, Name = "Permissions.Employee.Delete" },
            new Permissions_HR { Id = 9, Name = "Permissions.GeneralSettings.View"},
            new Permissions_HR { Id = 10, Name = "Permissions.GeneralSettings.Create" },
            new Permissions_HR { Id = 11, Name = "Permissions.GeneralSettings.Edit" },
            new Permissions_HR { Id = 12, Name = "Permissions.GeneralSettings.Delete" },
            new Permissions_HR { Id = 13, Name = "Permissions.Holidays.View"},
            new Permissions_HR { Id = 14, Name = "Permissions.Holidays.Create" },
            new Permissions_HR { Id = 15, Name = "Permissions.Holidays.Edit" },
            new Permissions_HR { Id = 16, Name = "Permissions.Holidays.Delete" },
            new Permissions_HR { Id = 17, Name = "Permissions.Home.View"},
            new Permissions_HR { Id = 18, Name = "Permissions.Home.Create" },
            new Permissions_HR { Id = 19, Name = "Permissions.Home.Edit" },
            new Permissions_HR { Id = 20, Name = "Permissions.Home.Delete" },
            new Permissions_HR { Id = 21, Name = "Permissions.Roles.View"},
            new Permissions_HR { Id = 22, Name = "Permissions.Roles.Create" },
            new Permissions_HR { Id = 23, Name = "Permissions.Roles.Edit" },
            new Permissions_HR { Id = 24, Name = "Permissions.Roles.Delete" },
            new Permissions_HR { Id = 25, Name = "Permissions.SalaryReport.View"},
            new Permissions_HR { Id = 26, Name = "Permissions.SalaryReport.Create" },
            new Permissions_HR { Id = 27, Name = "Permissions.SalaryReport.Edit" },
            new Permissions_HR { Id = 28, Name = "Permissions.SalaryReport.Delete" },
            new Permissions_HR { Id = 29, Name = "Permissions.Users.View"},
            new Permissions_HR { Id = 30, Name = "Permissions.Users.Create" },
            new Permissions_HR { Id = 31, Name = "Permissions.Users.Edit" },
            new Permissions_HR { Id = 32, Name = "Permissions.Users.Delete" },

        };

        public readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }


        [HttpGet]
        [Route("api/permissions")]
        public ActionResult<IEnumerable<Permissions_HR>> GetPermissions()
        {
            return Ok(permissions);
        }

        #region GetAll Roles
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return Ok(roles);
        }
        
        [HttpPost]

        public async Task<IActionResult> AddRole(RoleDTO roleFormDto)
        {
            if (!ModelState.IsValid)
            {
                var roles = await roleManager.Roles.ToListAsync();
                return Ok(roles);
            }
            var roleExist = await roleManager.RoleExistsAsync(roleFormDto.Name);
            if (roleExist)
            {
                ModelState.AddModelError("Name", "Role Is Exist");
                return Content("Role Is Exist");
            }
            var newRole = await roleManager.CreateAsync(new IdentityRole(roleFormDto.Name.Trim()));
            return Ok(newRole);
        }

        #endregion

        [HttpGet("{roleId}")]
        public async Task<IActionResult> ManagePermissions(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }
            var roleClaims = roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
            var allClaims = Permissions.generateAllPemissions();
            var allPermissions = allClaims.Select(x => new CheckBoxDto { DisplayValue = x }).ToList();
            foreach (var permission in allPermissions)
            {
                if (roleClaims.Any(x => x == permission.DisplayValue))
                {
                    permission.IsSelected = true;
                }

            }
            var permissionRole = new PermissionFormDto
            {
                RoleId = roleId,
                RoleName = role.Name,
                RoleClaims = allPermissions

            };
            return Ok(permissionRole);
        }
    }
}