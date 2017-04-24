using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    public class Product
    {
        public string SKU { get; set; }

        public int UnitPrice { get; set; }

        public int? SpecialPriceThreshold { get; set; }

        public int? SpecialPrice { get; set; }
    }
}
