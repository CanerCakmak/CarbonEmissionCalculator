using CarbonEmissionCalculator.Domain.Common;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class WastewaterTreatmentCalculation : BaseEntity
    {
        public double WastewaterVolume { get; set; } // Atık su hacmi (m³)
        public double CODConcentration { get; set; } // Kimyasal Oksijen İhtiyacı (mg/L)
        public double BODConcentration { get; set; } // Biyokimyasal Oksijen İhtiyacı (mg/L)
        public double TotalCOD { get; set; } // Toplam COD (kg)
        public double TotalBOD { get; set; } // Toplam BOD (kg)
        public double CH4EmissionFactor { get; set; } // CH4 Emisyon Faktörü (kg CH4/kg BOD)
        public double CH4GWP { get; set; } // CH4 Küresel Isınma Potansiyeli
        public double TotalCH4 { get; set; } // Toplam CH4 Emisyonu (kg)
        public double TotalCH4CO2e { get; set; } // Toplam CH4 CO2e (kg)
        public double TotalCH4CO2eTon { get; set; } // Toplam CH4 CO2e (ton)
    }
} 