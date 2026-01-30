using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS1.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string GLN { get; set; } 
        public string Description { get; set; }



        public ICollection<Product> Products { get; set; }
    }
}