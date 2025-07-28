using CarbonEmissionCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class Company: BaseEntity
    {
        public string Name { get; set; }
    }
}
