using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1.Core.Entities
{
    public enum SerialType
    {
        Item = 1,   // Tekil Ürün
        Case = 2,   // Koli
        Pallet = 3  // Palet
    }

    public class SerialNumber : BaseEntity
    {
        public string FullGtinCode { get; set; } // Tam karekod verisi
        public string SerialNo { get; set; } // Sadece (21)
        public string? SSCC { get; set; } // Koli/Palet kodu (Opsiyonel)

        public SerialType Type { get; set; }

        public int WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }

        // AGREGASYON (İç içe yapı)
        // (Anne)
        public int? ParentContainerId { get; set; }
        public SerialNumber ParentContainer { get; set; }

        // (Çocuk)
        public ICollection<SerialNumber> ChildItems { get; set; }
    }
}