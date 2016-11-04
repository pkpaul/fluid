using Fluid.Domain.Repository;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluid.Domain.Deployments
{
    public class Deployment: DatabaseItem
    {
        
        public Deployment()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DeploymentStatus Status { get; set; }
        public List<Market> Markets { get; set; }

    }

    public enum DeploymentStatus
    {
        Created,
        Provisioning,
        Complete
    }
}
