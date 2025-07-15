namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class CompanyVehiclesRow
    {
        public string VehicleType { get; set; }
        public string FuelType { get; set; }
        public double Distance { get; set; }
        public double EmissionFactorCO2 { get; set; }
        public double EmissionFactorCH4 { get; set; }
        public double EmissionFactorN2O { get; set; }
        public double EmissionCO2 { get; set; }
        public double EmissionCH4 { get; set; }
        public double EmissionN2O { get; set; }
        public double TotalCO2e { get; set; }
        public double TotalCO2eTon { get; set; }
    }
} 