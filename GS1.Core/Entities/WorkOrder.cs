using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1.Core.Entities
{
    // Durumları yönetmek için Enum
    public enum OrderStatus
    {
        Created = 0,
        Processing = 1,
        Completed = 2,
        Cancelled = 9
    }

    public class WorkOrder : BaseEntity
    {
        public string OrderCode { get; set; } // Sipariş Kodu
        public int Quantity { get; set; } // Üretim Adedi
        public string LotNo { get; set; } // (10) Batch No
        public DateTime ExpireDate { get; set; } // (17) Son Kullanma Tarihi
        public OrderStatus Status { get; set; } = OrderStatus.Created;

        
        public int ProductId { get; set; }
        public Product Product { get; set; }

        //karekodlar
        public ICollection<SerialNumber> SerialNumbers { get; set; }
    }
}