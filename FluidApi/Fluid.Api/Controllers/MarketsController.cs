using Fluid.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluid.Api.Controllers
{
    [Route("api/[controller]")]
    public class MarketsController : Controller
    {
        [HttpGet]
        public IEnumerable<Market> Get()
        {
            return new Market[] { new Market { Id = Guid.Parse("dccddc22-9101-4ff9-81f3-db31af8d59ec"), Name="WebSite" } };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Market Get(Guid id)
        {
            return new Market { Id = Guid.Parse("dccddc22-9101-4ff9-81f3-db31af8d59ec"), Name = "WebSite" };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Market value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Market value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
