namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class WastewaterTreatmentRow
    {
        public string WastewaterType { get; set; } // Arıtılan Atık Su Türü
        public double Amount { get; set; } // Arıtılan Atık Su Miktarı
        public string Unit { get; set; } // Birimi (m³)
        public double EmissionFactor { get; set; } // Emisyon Faktörü (kg CO2e/m³)
        public double KgCO2e { get; set; }
        public double TonCO2e { get; set; }
        public int Id { get; set; }
        public int GroupId { get; set; }
    }
} 