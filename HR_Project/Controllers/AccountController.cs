using HR_Project.DTO;
using HR_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HR_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> usermanger;
        private readonly IConfiguration config;

        public AccountController(UserManager<ApplicationUser> usermanger, IConfiguration config)
        {
            this.usermanger = usermanger;
            this.config = config;
        }
         // create a new account
        [HttpPost("register")]
        public async Task<IActionResult> Registration(RegisterUserDTO userDto)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser()
                {

                    UserName = userDto.UserName,
                    Email = userDto.Email,

                    //Role = userDto.Role

                };

                IdentityResult result = await usermanger.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return BadRequest(result.Errors.FirstOrDefault());
            }
            return BadRequest(ModelState);


            //            if (ModelState.IsValid)
            //            {

            //                ApplicationUser user = new ApplicationUser();

            //        user.UserName = userDto.UserName;
            //                user.Email = userDto.Email;

            //                IdentityResult result = await usermanger.CreateAsync(user, userDto.Password);
            //                if (result.Succeeded)
            //                {
            //                    return Ok("Account Add Success");
            //    }
            //                return BadRequest(result.Errors.FirstOrDefault());
            //}
            //return BadRequest(ModelState);
                 }






            // check account is valid
            [HttpPost("login")]
        public async Task<IActionResult> Login(loginUserDTO userDto)
        {
            if (ModelState.IsValid == true)
            {
                //check and create token
                ApplicationUser user = await usermanger.FindByEmailAsync(userDto.Email);
                if (user != null)
                {
                    bool found = await usermanger.CheckPasswordAsync(user, userDto.Password);
                    if (found)
                    {
                        //create token
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };


                        var roles = await usermanger.GetRolesAsync(user);
                        foreach (var itemRole in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, itemRole));
                        }
                        SecurityKey securityKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));

                        SigningCredentials signincred =
                            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        JwtSecurityToken mytoken = new JwtSecurityToken(
                            issuer: config["JWT:ValidIssuer"],// url providor swager web api
                            audience: config["JWT:ValidAudiance"],// url consumers angular
                            claims: claims,//custom claims
                            expires: DateTime.UtcNow.AddDays(1),//expire date
                            signingCredentials: signincred//signiture
                            );
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                            expiration = mytoken.ValidTo
                        });
                    }
                }
                return Unauthorized();

            }
            return Unauthorized();


        }

        








    }
}
