using System;
using Supermarket.Interfaces;

namespace Supermarket.Domain
{
    public class ShoppingItem : IItem
    {
        public char SKU { get; set; }
        public int UnitPrice { get; set; }
        public int? MultiBuyItemsRequired { get; set; }

        public int? MultiBuyPrice { get; set; }

        public ShoppingItem(char sku, int unitPrice, int? multiBuyItemsRequired, int? multiBuyPrice)
        {
            if (!Char.IsLetter(sku))
                throw new InvalidSkuException("Item SKU code must be a letter between A and Z");

            if (unitPrice <= 0)
                throw new InvalidPricingException("Unit price must be greater than zero");

            if (multiBuyPrice.HasValue && multiBuyPrice < unitPrice)
                throw new InvalidPricingException("Multi buy price must be equal to or greater than unit price");

            if (multiBuyItemsRequired.HasValue != multiBuyPrice.HasValue)
                throw new InvalidPricingException("Multi buy discounts require both number of items and total price");

            SKU = sku;
            UnitPrice = unitPrice;
            MultiBuyItemsRequired = multiBuyItemsRequired;
            MultiBuyPrice = multiBuyPrice;
        }

        public ShoppingItem(char sku, int unitPrice)
        {
            if (!Char.IsLetter(sku))
                throw new InvalidSkuException("Item SKU code must be a letter between A and Z");

            if (unitPrice <= 0)
                throw new InvalidPricingException("Unit price must be greater than zero");

            SKU = sku;
            UnitPrice = unitPrice;
        }
    }
}