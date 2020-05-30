using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OAM.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssetsController : ControllerBase
    {
        // GET: api/<AssetsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { 
                Guid.NewGuid().ToString(), 
                Guid.NewGuid().ToString() 
            };
        }

        // GET api/<AssetsController>/uuid
        [HttpGet("{uuid}")]
        public string Get(string uuid)
        {
            return uuid.ToString();
        }

        // POST api/<AssetsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AssetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
