using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    public class Checkout : ICheckout
    {
        List<Item> items = new List<Item>();
        List<Price> prices = new List<Price>();

        public void StartScanning()
        {
            items.Clear();
        }

        public void Scan(string item)
        {
            var itemScannedAlready = items.Count(x => x.Sku == item);
            if (itemScannedAlready > 0)
            {
                items.First(x => x.Sku == item).Count++;
            }
            else
            {
                Item newItem = new Item(item, 1);
                items.Add(newItem);
            }
        }

        public int GetTotalPrice()
        {
            int total = 0;
            foreach(var item in items)
            {
                var price = prices.FirstOrDefault(x => x.Sku == item.Sku);
                if (price == null)
                {
                    throw new Exception("Price not found");
                }
                var itemPrice = price.CalculateTotal(item.Count);
                total = total + itemPrice;
            }
            return total;
        }

        public int ItemCount(string item)
        {
            var itemScanned = items.FirstOrDefault(x => x.Sku == item);
            if (itemScanned == null)
            {
                return 0;
            }
            else
            {
                return itemScanned.Count;
            }
        }

        public void SetPrices(List<Price> prices)
        {
            this.prices = prices;
        }
    }
}
