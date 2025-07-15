using System.Collections.Generic;

namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class RefrigerantGasesCreateViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirmName { get; set; }
        public List<RefrigerantGasesRow> Rows { get; set; }
    }
} 