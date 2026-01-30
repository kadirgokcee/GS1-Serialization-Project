using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1.Core.DTOs
{
    public class WorkOrderDetailDto
    {
        public string OrderCode { get; set; }
        public string ProductName { get; set; }
        public int PlannedQuantity { get; set; }
        public string Status { get; set; }

        // Üretilen karekodların listesi
        public List<string> ProducedSerials { get; set; }
    }
}