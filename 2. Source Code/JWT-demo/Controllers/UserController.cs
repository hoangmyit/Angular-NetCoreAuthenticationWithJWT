using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Business;
using Business.Interface;
using DataTransfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Extensions;
using Common.Helpers;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace JWT_demo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBUS _userBUS;
        private readonly AppSettings _appSettings;
        public UserController(IOptions<AppSettings> appSettings)
        {
            _userBUS = new UserBUS();
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]User userParam)
        {
            string token = Authenticate(userParam.Username, userParam.Password);
            if (token != null)
            {
                return Ok(token);
            }
            return BadRequest(new { message = "Username or Password is wrong!" });
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            try
            {
                List<Role> roles = _userBUS.GetRoles();
                if (roles == null)
                {
                    return BadRequest(new { message = "nothing in database" });
                }
                return Ok(roles);
            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex);
                return result;
            }
        }

        private string Authenticate(string username, string password)
        {
            string result = null;
            User user = _userBUS.Login(username, password);
            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var allClaim = user.Roles.Select(x => new Claim(ClaimTypes.Role, x.RoleName)).ToList();
                allClaim.Add(new Claim(ClaimTypes.Name, user.ID.ToString()));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(allClaim),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                result = tokenHandler.WriteToken(token);
            }
            return result;
        }
    }
}