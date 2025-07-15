using CarbonEmissionCalculator.Domain.Common;
using System;
using System.Collections.Generic;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class RefrigerantGasesCalculationGroup : BaseEntity
    {
        public string FirmName { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<RefrigerantGasesCalculation> Rows { get; set; }
        public double TotalCO2e { get; set; }
        public double TotalCO2eTon { get; set; }
    }
} 