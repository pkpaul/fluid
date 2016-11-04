using MediatR;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.Text;
using Fluid.Domain.Repository;

namespace Fluid.Domain.Deployments
{
    public class DeploymentListHandler:IRequestHandler<DeploymentList, List<Deployment>>
    {
        private IRedisContext Redis;
        public DeploymentListHandler(IRedisContext redis)
        {
            Redis = redis;
        }


        public List<Deployment> Handle(DeploymentList message)
        {
            return Redis.List<Deployment>("deployment",message.Skip,message.Take);
        }
    }

    public class DeploymentList:IRequest<List<Deployment>>
    {
        public DeploymentList(int? skip, int? take)
        {
            Skip = 0;
            Take = 10;
            if(skip.HasValue)
                Skip = skip.Value;
            if(take.HasValue)
                Take = take.Value;
        }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
