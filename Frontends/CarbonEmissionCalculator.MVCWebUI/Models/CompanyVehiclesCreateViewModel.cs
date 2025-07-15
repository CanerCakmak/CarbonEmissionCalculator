using System;
using System.Collections.Generic;

namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class CompanyVehiclesCreateViewModel
    {
        public int Id { get; set; }
        public string FirmName { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CompanyVehiclesRow> Rows { get; set; }
    }
} 