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
    public class GetHandler : IRequestHandler<GetRequest, Deployment>
    {
        private IRedisContext Redis;
        public GetHandler(IRedisContext redis)
        {
            Redis = redis;
        }

        public Deployment Handle(GetRequest message)
        {
            return Redis.Get<Deployment>("deployment", message.Id);
        }
    }

    public class GetRequest : IRequest<Deployment>
    {
        public Guid Id { get; set; }
    }
}
