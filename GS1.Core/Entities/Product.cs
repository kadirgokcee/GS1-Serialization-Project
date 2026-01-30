using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string GTIN { get; set; } // Barkod Numarası (01)

        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

       
        public ICollection<WorkOrder> WorkOrders { get; set; }
    }
}