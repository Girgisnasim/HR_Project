using HR_Project.DTO;
using HR_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HRContext context;

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, HRContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ApplicationUser> users = context.Users.ToList();
            List<UserDto> userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                UserDto userDto = new UserDto
                {
                    ID = user.Id,
                    UserName = user.UserName,
                    //FullName = user.FullName,
                    Email = user.Email,
                    Password = user.PasswordHash,

                    //Role = (List<string>)_userManager.GetRolesAsync(user).Result

                    Role = (List<string>)_userManager.GetRolesAsync(user).Result

                };
                userDtos.Add(userDto);
            }


            return Ok(userDtos);
        }
    }
}