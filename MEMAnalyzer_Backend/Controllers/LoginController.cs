using MEMAnalyzer_Backend.Attributes;
using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.Business.BusinessModels;
using MEMAnalyzer_Backend.Business.Constants;
using MEMAnalyzer_Backend.DBModels;
using MEMAnalyzer_Backend.Helpers;
using MEMAnalyzer_Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public LoginController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IUserService userService) : base()
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _userService = userService;
        }

        /// <summary>
        /// Login in the system
        /// </summary>
        /// <returns></returns>
        [Swagger200(typeof(ApplicationUserEnterViewModel))]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var user = _userService.GetUserByNameAsync(model.UserName);
            if (user == null || await userManager.CheckPasswordAsync(user, model.Password) == false)
            {
                HttpContext.Response.StatusCode = 401;
                return new JsonResult(new Response
                {
                    Status = "Unauthorized",
                    Message = "You have entred incorrect data"
                });
            }
            if (user.LockoutEnd != null || user.LockoutEnd >= DateTime.Today)
            {
                HttpContext.Response.StatusCode = 409;
                return new JsonResult(new Response
                {
                    Status = "Unauthorized",
                    Message = @$"Your account has been locked: {((TimeSpan)(user.LockoutEnd - DateTime.Today)).TotalDays } days left"
                });
            }
            var userRoles = await userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenAuthentication:SecretKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["TokenAuthentication:Issuer"],
                audience: _configuration["TokenAuthentication:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var result = user.MapTo<ApplicationUserEnterViewModel>();
            result.Expiration = token.ValidTo;
            result.Token = new JwtSecurityTokenHandler().WriteToken(token);
            result.Role = userRoles.First();

            return Ok(result);
        }

        /// <summary>
        /// Register in the system
        /// </summary>
        /// <returns></returns>
        [Swagger200(typeof(ApplicationUserEnterViewModel))]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.UserName);
            if (userExists != null) 
            {
                HttpContext.Response.StatusCode = 409;
                return new JsonResult(new Response
                {
                    Status = "Conflict",
                    Message = "Such UserName has been already taken!"
                });
            }
            userExists = await userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                HttpContext.Response.StatusCode = 409;
                return new JsonResult(new Response
                {
                    Status = "Conflict",
                    Message = "Such Email has been already taken!"
                });
            }
   
            if (!await roleManager.RoleExistsAsync(Roles.USER)) 
                await roleManager.CreateAsync(new IdentityRole(Roles.USER));

            var role = await roleManager.FindByNameAsync(Roles.USER);
            
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                FullName = model.FullName,
                Gender = model.Gender,
                BirthDate = model.DateOfBirth.DateTime,
                CreatedDate = GetCurrentDate(),
                RoleId = role.Id
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult(new Response
                {
                    Status = "BadReques",
                    Message = "User creation failed! Please check input data"
                });
            }
            
            if (await roleManager.RoleExistsAsync(Roles.USER))
            {
                await userManager.AddToRoleAsync(user, Roles.USER);
            }

            return await Login(new LoginModel
            { 
                UserName = user.UserName,
                Password = model.Password
            });
        }

        /// <summary>
        /// Register as admin in the system
        /// </summary>
        /// <returns></returns>
        [Swagger200(typeof(ApplicationUserEnterViewModel))]
        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
            {
                HttpContext.Response.StatusCode = 409;
                return new JsonResult(new Response
                {
                    Status = "Conflict",
                    Message = "Such UserName has been already taken!"
                });
            }
            userExists = await userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                HttpContext.Response.StatusCode = 409;
                return new JsonResult(new Response
                {
                    Status = "Conflict",
                    Message = "Such Email has been already taken!"
                });
            }

            if (!await roleManager.RoleExistsAsync(Roles.ADMINISTRATOR))
                await roleManager.CreateAsync(new IdentityRole(Roles.ADMINISTRATOR));

            var role = await roleManager.FindByNameAsync(Roles.ADMINISTRATOR);

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                FullName = model.FullName,
                Gender = model.Gender,
                BirthDate = model.DateOfBirth.DateTime,
                CreatedDate = GetCurrentDate(),
                RoleId = role.Id
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult(new Response
                {
                    Status = "BadReques",
                    Message = "User creation failed! Please check input data"
                });
            }

            if (await roleManager.RoleExistsAsync(Roles.ADMINISTRATOR))
            {
                await userManager.AddToRoleAsync(user, Roles.ADMINISTRATOR);
            }

            return await Login(new LoginModel
            {
                UserName = user.UserName,
                Password = model.Password
            });
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [Swagger200(typeof(ApplicationUserViewModel))]
        [Authorize(Roles = Roles.ADMINISTRATOR)]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(string search, bool? gender, int? startAge, int? endAge)
        {
            DateTime currentDate = GetCurrentDate();
            return await GetResultAsync(() => _userService.GetAllUsersAsync(search, gender, startAge, endAge, currentDate));
        }

        /// <summary>
        /// Block user by id
        /// </summary>
        /// <param name="userId">id of the user. Example: 20076730-5739-4d98-962a-c4f5253c0893</param>/>
        /// <returns></returns>
        [Authorize(Roles = Roles.ADMINISTRATOR)]
        [Swagger200(typeof(Response))]
        [HttpPut("Block/{userId}")]
        public async Task<IActionResult> BlockUser(string userId)
        {
            BlockingStatus result = await _userService.BlockUserByIdAsync(userId);

            switch (result) 
            {
                case BlockingStatus.Success:
                    HttpContext.Response.StatusCode = 200;
                    return new JsonResult(new Response 
                    { 
                        Status = "Success", 
                        Message = "User has been blocked successfully" 
                    });
                case BlockingStatus.Admin:
                    HttpContext.Response.StatusCode = 409;
                    return new JsonResult(new Response
                    {
                        Status = "Conflict",
                        Message = "Blocking of Administrator is prohibited"
                    });
                case BlockingStatus.NotFound:
                    HttpContext.Response.StatusCode = 404;
                    return new JsonResult(new Response
                    {
                        Status = "NotFound",
                        Message = "User does not exist"
                    });
               case BlockingStatus.AlreadyBanned:
                    HttpContext.Response.StatusCode = 409;
                    return new JsonResult(new Response
                    {
                        Status = "Conflict",
                        Message = "User has been already blocked"
                    });
               default:
                    HttpContext.Response.StatusCode = 404;
                    return new JsonResult(new Response
                    {
                        Status = "Error",
                        Message = "Unknown error"
                    });
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId">id of the user. Example: 20076730-5739-4d98-962a-c4f5253c0893</param>/>
        /// <returns></returns>
        [Swagger200(typeof(ApplicationUserWithResultViewModel))]
        [Authorize(Roles = Roles.ADMINISTRATOR)]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            return await GetResultAsync(() => _userService.GetUserByIdAsync(userId));
        }

        /// <summary>
        /// Update profile info
        /// </summary>
        /// <returns></returns>
        [Swagger200(typeof(ApplicationUserWithResultViewModel))]
        [Authorize(Roles = Roles.USER + ", " + Roles.ADMINISTRATOR)]
        [HttpPut("Profile")]
        public async Task<IActionResult> UpdateUser([FromBody]ApplicationUserDtoModel model)
        {
            var emailExists = await userManager.FindByEmailAsync(model.Email);
            if (emailExists != null)
            {
                HttpContext.Response.StatusCode = 409;
                return new JsonResult(new Response
                {
                    Status = "Conflict",
                    Message = "Such email has been already taken"
                });
            }
            string userId = GetCurrentUserId();
            return await GetResultAsync(() => _userService.UpdateUserAsync(userId, model));
        }


        /// <summary>
        /// Get profile info
        /// </summary>
        /// <returns></returns>
        [Swagger200(typeof(ApplicationUserWithResultViewModel))]
        [Authorize(Roles = Roles.USER + ", " + Roles.ADMINISTRATOR)]
        [HttpGet("Profile")]
        public async Task<IActionResult> GetProfile()
        {
            string userId = GetCurrentUserId();
            return await GetResultAsync(() => _userService.GetUserByIdAsync(userId));
        }
    }
}
