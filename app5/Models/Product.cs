using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app5.Models
{
    
    public class Product : Item
    {
        public int ShelfLife { get; set; } // Термін придатності в днях
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }

}
