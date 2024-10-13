using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app5.Models
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CountryOfOrigin { get; set; }
        public DateTime PackagingDate { get; set; }
        public string Description { get; set; }
    }

}
