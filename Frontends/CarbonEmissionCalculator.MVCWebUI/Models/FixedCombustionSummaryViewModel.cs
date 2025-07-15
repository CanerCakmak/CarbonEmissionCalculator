using System;

namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class FixedCombustionSummaryViewModel
    {
        public string FuelType { get; set; }
        public double ConsumptionAmount { get; set; }
        public double CO2Emission { get; set; }
        public double CH4Emission { get; set; }
        public double N2OEmission { get; set; }
        public double TotalCO2e { get; set; }
        public DateTime CalculationDate { get; set; }
    }
} 