using System;
using System.ComponentModel.DataAnnotations;

namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TaxNumber { get; set; }
    }
} 