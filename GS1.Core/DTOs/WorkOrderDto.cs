using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1.Core.DTOs
{
    public class WorkOrderDto
    {
        public int ProductId { get; set; } 
        public int Quantity { get; set; }  
        public string LotNo { get; set; }  
        public DateTime ExpireDate { get; set; } 
    }
}