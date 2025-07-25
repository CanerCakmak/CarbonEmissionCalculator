namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class CarbonContainingMaterialRow
    {
        public double RawMaterialActivity { get; set; }
        public double RawMaterialCarbon { get; set; }
        public double RawMaterialCarbonAmount { get; set; }
        public double FinalProductActivity { get; set; }
        public double FinalProductCarbon { get; set; }
        public double FinalProductCarbonAmount { get; set; }
        public double TotalCarbon { get; set; }
        public double ConversionFactor { get; set; }
        public double TotalEmissionKg { get; set; }
        public double TotalEmissionTon { get; set; }
        public int Id { get; set; }
        public int GroupId { get; set; }
    }
} 