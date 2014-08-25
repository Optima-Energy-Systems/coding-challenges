using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class ItemRepository
    {
        private Dictionary<string, Item> itemsBySku = new Dictionary<string, Item>();

        public ItemRepository() { }

        /**
         * Save an item. If an item with the same sku already exists, it will be replaced.
         */
        public void SaveItem(Item item)
        {
            if (itemsBySku.ContainsKey(item.GetSku()))
            {
                itemsBySku.Remove(item.GetSku());
            }

            itemsBySku.Add(item.GetSku(), item);
        }

        /**
         * Remove an item, if it doesn't exist, this method will just return without
         * doing anything.
         */
        public void RemoveItem(Item item)
        {
            itemsBySku.Remove(item.GetSku());
        }

        /**
         * Find an item by sku, returning null if it doesn't exist.
         */
        public Item FindItem(string sku)
        {
            try
            {
                return itemsBySku[sku];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        /**
         * Print the items (for demo)
         */
        public override string ToString()
        {
            string s = "";

            foreach (var item in itemsBySku.Values)
            {
                s += item.ToString() + "\n";
            }

            return s;
        }
    }
}
