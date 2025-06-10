using CarbonEmissionCalculator.Domain.Common;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class CarbonContainingMaterialCalculation : BaseEntity
    {
        public decimal RawMaterialActivity1 { get; set; }
        public decimal RawMaterialCarbon1 { get; set; }
        public decimal RawMaterialCarbonAmount1 { get; set; }
        public decimal FinalProductActivity1 { get; set; }
        public decimal FinalProductCarbon1 { get; set; }
        public decimal FinalProductCarbonAmount1 { get; set; }
        public decimal TotalCarbon1 { get; set; }
        public decimal ConversionFactor1 { get; set; }
        public decimal TotalEmissionKg1 { get; set; }
        public decimal TotalEmissionTon1 { get; set; }

        public decimal RawMaterialActivity2 { get; set; }
        public decimal RawMaterialCarbon2 { get; set; }
        public decimal RawMaterialCarbonAmount2 { get; set; }
        public decimal FinalProductActivity2 { get; set; }
        public decimal FinalProductCarbon2 { get; set; }
        public decimal FinalProductCarbonAmount2 { get; set; }
        public decimal TotalCarbon2 { get; set; }
        public decimal ConversionFactor2 { get; set; }
        public decimal TotalEmissionKg2 { get; set; }
        public decimal TotalEmissionTon2 { get; set; }

        public decimal GrandTotalKg { get; set; }
        public decimal GrandTotalTon { get; set; }
    }
}
