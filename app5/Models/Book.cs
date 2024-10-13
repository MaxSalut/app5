using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app5.Models
{
    public class Book : Item
    {
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public List<string> Authors { get; set; } = new();
    }

}
