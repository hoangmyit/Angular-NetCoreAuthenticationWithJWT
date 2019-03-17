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
    public class BothController : ControllerBase
    {
        // GET: api/Both
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Role: Admin", "Role: Manager" };
        }

        // GET: api/Both/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Both";
        }

        // POST: api/Both
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Both/5
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
