using CarbonEmissionCalculator.Domain.Common;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class CompanyVehiclesCalculation : BaseEntity
    {
        public double VehicleType { get; set; } // Araç türü
        public double FuelConsumption { get; set; } // Yakıt tüketimi (L)
        public double FuelType { get; set; } // Yakıt türü (Benzin/Dizel/LPG)
        public double EmissionFactor { get; set; } // Emisyon faktörü (kg CO2/L)
        public double TotalCO2 { get; set; } // Toplam CO2 emisyonu (kg)
        public double TotalCO2Ton { get; set; } // Toplam CO2 emisyonu (ton)
    }
} 