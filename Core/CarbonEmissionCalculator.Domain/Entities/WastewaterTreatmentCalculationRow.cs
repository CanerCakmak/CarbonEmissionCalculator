using CarbonEmissionCalculator.Domain.Common;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class WastewaterTreatmentCalculationRow : BaseEntity
    {
        public string WastewaterType { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public double EmissionFactor { get; set; }
        public double KgCO2e { get; set; }
        public double TonCO2e { get; set; }
        public int GroupId { get; set; }
        public WastewaterTreatmentCalculationGroup Group { get; set; }
        public string FirmName { get; set; }
    }
} 