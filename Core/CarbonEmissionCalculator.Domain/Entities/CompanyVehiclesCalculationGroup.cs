using CarbonEmissionCalculator.Domain.Common;
using System;
using System.Collections.Generic;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class CompanyVehiclesCalculationGroup : BaseEntity
    {
        public string FirmName { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CompanyVehiclesCalculation> Rows { get; set; }
        public double TotalCO2e { get; set; }
        public double TotalCO2eTon { get; set; }
    }
} 