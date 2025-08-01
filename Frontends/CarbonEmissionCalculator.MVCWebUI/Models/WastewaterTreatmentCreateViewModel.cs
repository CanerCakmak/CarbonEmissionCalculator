using System;
using System.Collections.Generic;

namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class WastewaterTreatmentCreateViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirmName { get; set; }
        public int CompanyId { get; set; }
        public List<WastewaterTreatmentRow> Rows { get; set; }
    }
} 