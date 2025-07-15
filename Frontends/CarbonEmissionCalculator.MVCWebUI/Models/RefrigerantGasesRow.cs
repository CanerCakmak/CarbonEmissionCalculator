namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class RefrigerantGasesRow
    {
        public string EquipmentType { get; set; }
        public string GasType { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public double TotalAmount { get; set; }
        public double LeakPercentage { get; set; }
        public double LeakAmount { get; set; }
        public double EmissionFactor { get; set; }
        public double KgCO2e { get; set; }
        public double TonCO2e { get; set; }
        public int Id { get; set; }
        public int GroupId { get; set; }
    }
} 