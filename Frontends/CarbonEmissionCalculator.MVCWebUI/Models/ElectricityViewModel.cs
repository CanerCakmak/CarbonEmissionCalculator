using System.ComponentModel.DataAnnotations;

namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class ElectricityViewModel
    {
        [Display(Name = "Ülke")]
        [Required(ErrorMessage = "Ülke seçimi zorunludur.")]
        public string Country { get; set; }

        [Display(Name = "Tüketilen Elektrik Miktarı")]
        [Required(ErrorMessage = "Elektrik tüketim miktarı zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "Lütfen geçerli bir miktar giriniz.")]
        public double ConsumptionAmount { get; set; }

        [Display(Name = "Birimi")]
        public string Unit { get; set; } = "mWh";

        [Display(Name = "Emisyon Faktörü (ton CO2/mWh)")]
        [Required(ErrorMessage = "Emisyon faktörü zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "Lütfen geçerli bir emisyon faktörü giriniz.")]
        public double EmissionFactor { get; set; } = 0.442;

        [Display(Name = "Toplam Emisyon (ton CO2e)")]
        public double TotalEmission { get; set; }

        public int CompanyId { get; set; }
    }
} 