using CarbonEmissionCalculator.Domain.Common;
using System;
using System.Collections.Generic;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class WastewaterTreatmentCalculationGroup : BaseEntity
    {
        public List<WastewaterTreatmentCalculationRow> Rows { get; set; }
        public double GrandTotalKg { get; set; }
        public double GrandTotalTon { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
} 