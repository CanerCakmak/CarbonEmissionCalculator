using CarbonEmissionCalculator.Domain.Common;

namespace CarbonEmissionCalculator.Domain.Entities
{
    public class CarbonContainingMaterialCalculation : BaseEntity
    {
        public double RawMaterialActivity1 { get; set; }
        public double RawMaterialCarbon1 { get; set; }
        public double RawMaterialCarbonAmount1 { get; set; }
        public double FinalProductActivity1 { get; set; }
        public double FinalProductCarbon1 { get; set; }
        public double FinalProductCarbonAmount1 { get; set; }
        public double TotalCarbon1 { get; set; }
        public double ConversionFactor1 { get; set; }
        public double TotalEmissionKg1 { get; set; }
        public double TotalEmissionTon1 { get; set; }

        public double RawMaterialActivity2 { get; set; }
        public double RawMaterialCarbon2 { get; set; }
        public double RawMaterialCarbonAmount2 { get; set; }
        public double FinalProductActivity2 { get; set; }
        public double FinalProductCarbon2 { get; set; }
        public double FinalProductCarbonAmount2 { get; set; }
        public double TotalCarbon2 { get; set; }
        public double ConversionFactor2 { get; set; }
        public double TotalEmissionKg2 { get; set; }
        public double TotalEmissionTon2 { get; set; }

        public double GrandTotalKg { get; set; }
        public double GrandTotalTon { get; set; }
    }
}
