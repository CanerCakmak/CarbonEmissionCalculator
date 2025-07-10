using CarbonEmissionCalculator.Domain.Common;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class RefrigerantGasesCalculation : BaseEntity
    {
        public double RefrigerantType { get; set; } // Soğutucu gaz türü
        public double RefrigerantAmount { get; set; } // Soğutucu gaz miktarı (kg)
        public double GWPFactor { get; set; } // Küresel Isınma Potansiyeli Faktörü
        public double LeakageRate { get; set; } // Sızıntı oranı (%)
        public double TotalLeakage { get; set; } // Toplam sızıntı (kg)
        public double TotalCO2e { get; set; } // Toplam CO2e (kg)
        public double TotalCO2eTon { get; set; } // Toplam CO2e (ton)
    }
} 