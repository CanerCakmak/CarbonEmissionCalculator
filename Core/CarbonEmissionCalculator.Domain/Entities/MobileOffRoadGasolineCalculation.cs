using CarbonEmissionCalculator.Domain.Common;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class MobileOffRoadGasolineCalculation : BaseEntity
    {
        public double ConsumptionAmount { get; set; }
        public double Density { get; set; }
        public double ConsumptionKg { get; set; }
        public double ConsumptionGg { get; set; }
        public double NetCaloricValue { get; set; }
        public double ConsumptionTJ { get; set; }
        public double CarbonOxidationFactor { get; set; }
        public double Co2Factor { get; set; }
        public double Ch4Factor { get; set; }
        public double N2oFactor { get; set; }
        public double Co2GWP { get; set; }
        public double Ch4GWP { get; set; }
        public double N2oGWP { get; set; }
        public double TotalCO2 { get; set; }
        public double TotalCH4 { get; set; }
        public double TotalN2O { get; set; }
        public double TotalCO2e { get; set; }
        public double TotalCO2eTon { get; set; }
    }
}
