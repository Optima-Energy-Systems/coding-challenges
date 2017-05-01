using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    public class Price
    {
        public string Sku { get; set; }

        public int SingleItemPrice { get; set; } = 0; // would use decimal in real shop

        public int MultiItemCount { get; set; } = 0;

        public int MultiItemPrice { get; set; } = 0;

        public Price(string Sku, int Price)
        {
            this.Sku = Sku;
            this.SingleItemPrice = Price;
        }

        public void SetMultiPrice(int multiItems, int price)
        {
            this.MultiItemCount = multiItems;
            this.MultiItemPrice = price;
        }

        public int CalculateTotal(int count)
        {
            int total = 0;
            if (MultiItemCount != 0 && MultiItemPrice != 0)
            {
                int multiPriceBatches = (int)(count / MultiItemCount);
                int leftOver = count - multiPriceBatches * MultiItemCount;
                total = leftOver * SingleItemPrice + multiPriceBatches * MultiItemPrice;
            }
            else
            {
                total = count * SingleItemPrice;
            }
            return total;
        }
    }
}
