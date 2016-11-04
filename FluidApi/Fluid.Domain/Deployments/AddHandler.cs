using Fluid.Domain.Repository;
using MediatR;
using ServiceStack.Text;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluid.Domain.Deployments
{
    public class AddHandler : IRequestHandler<NewDeployment, Deployment>
    {
        private IRedisContext Redis;
        public AddHandler(IRedisContext redis)
        {
            Redis = redis;
        }

        public Deployment Handle(NewDeployment message)
        {
            message.Id = Guid.NewGuid();
            Redis.Add<Deployment>("deployment", message);
            return message;
        }
    }

    public class NewDeployment: Deployment,IRequest<Deployment>
    {
        
    }
}
