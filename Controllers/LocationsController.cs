using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAM.Service.Contexts;
using OAM.Service.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OAM.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationsController : ControllerBase
    {
        // GET: api/<LocationsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<AssetLocation> list;
            using (var ctx = new AssetContext(new DbContextOptionsBuilder<AssetContext>().Options))
            {
                list = ctx.AssetLocations.Where(o => o.ClientId == User.Identity.GetSubjectId()).ToList();
            }
            return new JsonResult(list);
        }

        // POST api/<LocationsController>
        [HttpPost]
        public void Post([FromBody] AssetLocation value)
        {

        }

        // PUT api/<LocationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
