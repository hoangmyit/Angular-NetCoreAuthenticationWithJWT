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
        private IRoleBUS _roleBUS;
        private readonly AppSettings _appSettings;
        public UserController(IOptions<AppSettings> appSettings, IUserBUS userBUS, IRoleBUS _roleBUS)
        {
            this._userBUS = userBUS;
            this._roleBUS = _roleBUS;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]UserDTO userParam)
        {
            UserDTO user = Authenticate(userParam.Username, userParam.Password);
            if (user != null)
            {
                var result = Ok(user);
                return result;
            }
            return BadRequest(new { message = "Username or Password is wrong!" });
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            try
            {
                List<RoleDTO> roles = _roleBUS.GetRoles();
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

        private UserDTO Authenticate(string username, string password)
        {
            UserDTO result = null;
            UserDTO user = _userBUS.Login(username, password);
            if (user != null)
            {
                result = new UserDTO();
                result.Username = user.Username;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var allClaim = user.Roles.Select(x => new Claim(ClaimTypes.Role, x.RoleName)).ToList();
                allClaim.Add(new Claim(ClaimTypes.Name, user.Username));
                var a = new SymmetricSecurityKey(key);
                var ac = Encoding.ASCII.GetString(a.Key);
                var sign = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(allClaim),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = sign
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                result.Token = tokenHandler.WriteToken(token);
            }
            return result;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            try
            {
                TestDTO result = new TestDTO();
                result.Message = "User(Normal) controller work";
                result.Roles = ((ClaimsIdentity)User.Identity).Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                var reponse = StatusCode(StatusCodes.Status500InternalServerError, ex);
                return reponse;
            }
        }
    }
}