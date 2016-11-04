using Fluid.Domain;
using Fluid.Domain.Deployments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluid.Api.Controllers
{
    [Route("api/[controller]")]
    public class DeploymentsController:Controller
    {
        IMediator Mediator { get; set; }
        public DeploymentsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<Deployment> Get()
        {
            var skipHeader = Request.Headers.FirstOrDefault(q => string.Compare(q.Key, "skip", true) == 0).Value;
            int skip = 0;
            if (skipHeader.Count > 0)
                int.TryParse(skipHeader, out skip);

            var takeHeader = Request.Headers.FirstOrDefault(q => string.Compare(q.Key, "take", true) == 0).Value;
            int take = 10;
            if(takeHeader.Count > 0)
                int.TryParse(takeHeader, out take);
            return Mediator.Send(new DeploymentList(skip,take));
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Deployment Get(Guid id)
        {
            return Mediator.Send(new GetRequest { Id = id });
        }

        // POST api/values
        [HttpPost]
        public Deployment Post([FromBody]NewDeployment value)
        {
            return Mediator.Send(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Deployment value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
