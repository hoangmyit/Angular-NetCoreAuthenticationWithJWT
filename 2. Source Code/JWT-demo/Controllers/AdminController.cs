using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataTransfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_demo.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            try
            {
                TestDTO result = new TestDTO();
                result.Message = "Admin controller work";
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
