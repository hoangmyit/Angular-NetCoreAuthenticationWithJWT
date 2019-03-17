using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_demo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        // GET: api/Manager
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Manager1", "Manager2" };
        }

        // GET: api/Manager/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Manager1";
        }

        // POST: api/Manager
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Manager/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
