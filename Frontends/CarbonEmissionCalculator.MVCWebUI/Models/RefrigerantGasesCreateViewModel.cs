using System.Collections.Generic;

namespace CarbonEmissionCalculator.MVCWebUI.Models
{
    public class RefrigerantGasesCreateViewModel
    {
        
        public int CompanyId { get; set; }
        public List<RefrigerantGasesRow> Rows { get; set; }
    }
} 