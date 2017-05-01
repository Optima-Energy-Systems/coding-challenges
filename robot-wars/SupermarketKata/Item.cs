using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    public class Item
    {
        public string Sku { get; set; }

        public int Count { get; set; }

        public Item(string Sku, int Count)
        {
            this.Sku = Sku;
            this.Count = Count;
        }
    }
}
