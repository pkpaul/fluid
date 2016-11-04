using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluid.Domain
{
    public class Market
    {
        public Market()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
