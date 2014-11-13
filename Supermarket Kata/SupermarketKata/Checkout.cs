using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    public class Checkout : ICheckout
    {
        #region Fields

        private List<string> _items = new List<string>();

        #endregion

        #region Properties

        public Product[] Products { get; private set; }

        #endregion

        #region Methods

        public static Checkout LoadDefaultProducts()
        {
            var filename = Path.Combine(Environment.CurrentDirectory, "Products.json");
            var json = File.ReadAllText(filename);

            return LoadProductsFromJson(json);
        }

        public static Checkout LoadProductsFromJson(string json)
        {
            var checkout = new Checkout();
            checkout.Products = JsonConvert.DeserializeObject<Product[]>(json);

            // Check that each SKU is unique,
            if (checkout.Products.GroupBy(x => x.SKU).Any(x => x.Count() > 1))
            {
                throw new ArgumentException("The Json has SKUs that are not unique", "json");
            }

            return checkout;
        }

        public void Scan(string item)
        {
            if (!Products.Any(x => x.SKU == item))
            {
                throw new ArgumentException("The item is not in the list of products", "item");
            }

            _items.Add(item);
        }

        public int GetTotalPrice()
        {
            int runningTotal = 0;

            foreach (var currentGroup in _items.GroupBy(x => x))
            {
                var sku = currentGroup.First();
                var count = currentGroup.Count();
                var product = Products.Single(x => x.SKU == sku);

                if (product.SpecialPriceThreshold.HasValue && product.SpecialPrice.HasValue)
                {
                    int quotient = count / product.SpecialPriceThreshold.Value;
                    int remainder = count % product.SpecialPriceThreshold.Value;

                    runningTotal += quotient * product.SpecialPrice.Value;
                    runningTotal += remainder * product.UnitPrice;
                }
                else
                {
                    runningTotal += count * product.UnitPrice;
                }
            }

            return runningTotal;
        }

        #endregion
    }
}
