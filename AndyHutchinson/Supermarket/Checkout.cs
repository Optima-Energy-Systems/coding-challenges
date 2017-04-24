using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    /// <summary>
    /// A checkout is aware of a set of items, and can scan items
    /// and compute the total price for them, including any offers.
    /// </summary>
    public class Checkout
    {
        Dictionary<string, int> itemCountsBySku = new Dictionary<string, int>();

        ItemRepository itemRepository;

        /**
         * Create a checkout that uses the given item repository.
         */
        public Checkout(ItemRepository r)
        {
            itemRepository = r;
        }

        /**
         * Register the scanning of an item, by sku.
         */
        public void Scan(string sku)
        {
            if (itemCountsBySku.ContainsKey(sku))
            {
                itemCountsBySku[sku] = itemCountsBySku[sku] + 1;
            }
            else if (itemRepository.FindItem(sku) != null)
            {
                itemCountsBySku[sku] = 1;
            }
            else
            {
                throw new SupermarketException("Scanned unknown item");
            }
        }

        /**
         * Clear the recorded scanned items
         */
        public void Clear()
        {
            itemCountsBySku.Clear();
        }

        /**
         * Get the total price for the items that have been scanned
         */
        public double GetTotalPrice()
        {
            double total = 0;

            foreach (var sku in itemCountsBySku.Keys)
            {
                Item item = itemRepository.FindItem(sku);

                if (item == null)
                {
                    throw new SupermarketException("Missing item: " + sku);
                }

                int itemCount = itemCountsBySku[item.GetSku()];
                total += GetSubtotalForItem(item, itemCount);
            }

            return total;
        }

        /**
         * Given an item and a number of units, work out the cost.
         */
        private double GetSubtotalForItem(Item item, int itemCount)
        {
            if (!item.HasSpecialOffer())
            {
                return item.GetPrice() * itemCount;
            }
            else
            {
                int numberOfSpecials = itemCount / item.GetSpecialOfferMultiple();
                int numberOfRegulars = itemCount % item.GetSpecialOfferMultiple();

                return numberOfSpecials * item.GetSpecialOfferPrice() +
                       numberOfRegulars * item.GetPrice(); 
            }
        }

        /**
         * Print out total, for demo
         */
        public override string ToString()
        {
            return "Total: " + GetTotalPrice();
        }
    }
}
