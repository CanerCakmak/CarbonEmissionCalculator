using CarbonEmissionCalculator.Domain.Common;
using System;
using System.Collections.Generic;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class RefrigerantGasesCalculationGroup : BaseEntity
    {
        public List<RefrigerantGasesCalculation> Rows { get; set; }
        public double TotalCO2e { get; set; }
        public double TotalCO2eTon { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
} 