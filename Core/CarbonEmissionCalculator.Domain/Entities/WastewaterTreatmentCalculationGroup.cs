using CarbonEmissionCalculator.Domain.Common;
using System;
using System.Collections.Generic;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class WastewaterTreatmentCalculationGroup : BaseEntity
    {
        public string FirmName { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<WastewaterTreatmentCalculationRow> Rows { get; set; }
        public double GrandTotalKg { get; set; }
        public double GrandTotalTon { get; set; }
    }
} 