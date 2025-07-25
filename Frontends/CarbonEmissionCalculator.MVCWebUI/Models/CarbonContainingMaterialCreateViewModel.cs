using System;
using System.Collections.Generic;

namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class CarbonContainingMaterialCreateViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirmName { get; set; }
        public List<CarbonContainingMaterialRow> Rows { get; set; }
    }
} 