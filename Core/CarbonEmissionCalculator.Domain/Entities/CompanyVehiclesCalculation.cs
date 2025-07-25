using CarbonEmissionCalculator.Domain.Common;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class CompanyVehiclesCalculation : BaseEntity
    {
        public string VehicleType { get; set; } // Araç türü
        public string FuelType { get; set; } // Yakıt türü (Benzin/Dizel/LPG)
        public double Distance { get; set; }
        public double EmissionFactorCO2 { get; set; }
        public double EmissionFactorCH4 { get; set; }
        public double EmissionFactorN2O { get; set; }
        public double EmissionCO2 { get; set; }
        public double EmissionCH4 { get; set; }
        public double EmissionN2O { get; set; }
        public double TotalCO2e { get; set; }
        public double TotalCO2eTon { get; set; }
        public int GroupId { get; set; }
        public CompanyVehiclesCalculationGroup Group { get; set; }
    }
} 