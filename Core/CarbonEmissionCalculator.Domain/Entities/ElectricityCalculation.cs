using CarbonEmissionCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class ElectricityCalculation : BaseEntity
    {
        public string Country { get; set; }
        public double ConsumptionAmount { get; set; }
        public double EmissionFactor { get; set; }
        public double TotalEmission { get; set; }
    }
}
