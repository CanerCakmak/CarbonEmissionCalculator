using CarbonEmissionCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class FixedCombustionNaturalGasCalculation : BaseEntity
    {
        public decimal ConsumptionAmount { get; set; }
        public decimal Density { get; set; }
        public decimal ConsumptionKg { get; set; }
        public decimal consumptionGg { get; set; }
        public decimal netCaloricValue { get; set; }
        public decimal consumptionTJ { get; set; }
        public decimal carbonOxidationFactor { get; set; }
        public decimal co2Factor { get; set; }
        public decimal ch4Factor { get; set; }
        public decimal n2oFactor { get; set; }
        public decimal co2GWP { get; set; }
        public decimal ch4GWP { get; set; }
        public decimal n2oGWP { get; set; }
        public decimal totalCO2 { get; set; }
        public decimal totalCH4 { get; set; }
        public decimal totalN2O { get; set; }
        public decimal totalCO2e { get; set; }
        public decimal totalCO2eTon { get; set; }
        
    }
}
