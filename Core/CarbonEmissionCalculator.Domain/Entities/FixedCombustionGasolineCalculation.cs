using CarbonEmissionCalculator.Domain.Common;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class FixedCombustionGasolineCalculation : BaseEntity
    {
        public decimal ConsumptionAmount { get; set; }
        public decimal Density { get; set; }
        public decimal ConsumptionKg { get; set; }
        public decimal ConsumptionGg { get; set; }
        public decimal NetCaloricValue { get; set; }
        public decimal ConsumptionTJ { get; set; }
        public decimal CarbonOxidationFactor { get; set; }
        public decimal Co2Factor { get; set; }
        public decimal Ch4Factor { get; set; }
        public decimal N2oFactor { get; set; }
        public decimal Co2GWP { get; set; }
        public decimal Ch4GWP { get; set; }
        public decimal N2oGWP { get; set; }
        public decimal TotalCO2 { get; set; }
        public decimal TotalCH4 { get; set; }
        public decimal TotalN2O { get; set; }
        public decimal TotalCO2e { get; set; }
        public decimal TotalCO2eTon { get; set; }
    }
}
