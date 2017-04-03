using System;
using System.Collections.Generic;
using System.Linq;
using Supermarket.Interfaces;

namespace Supermarket.Domain
{
    public class Checkout : ICheckout
    {
        private IList<ShoppingItem> _Basket { get; set; }
        public int BasketItemCount { get { return _Basket.Count; } }

        public Checkout()
        {
            _Basket = new List<ShoppingItem>();
        }

        public int GetTotalPrice()
        {
            //get subtotal of items with multi buy discount
            var saleItemsTotal = _Basket.Where(item => item.MultiBuyItemsRequired > 0) //only deal with items which have multi buy discounts
                                        .GroupBy(item => item.SKU) //group by sku code
                                        .Select(grp => grp.Select(g => ((grp.Count() / g.MultiBuyItemsRequired) * g.MultiBuyPrice) + (grp.Count() % g.MultiBuyItemsRequired * g.UnitPrice)).First()) //calc sum total for this specific item
                                        .Sum(itemCost => itemCost); //subtotal of multi buy items

            //subtotal of items without multi buy discounts
            int nonSaleItemsTotal = _Basket.Where(item => item.MultiBuyItemsRequired == null).Sum(item => item.UnitPrice);

            return saleItemsTotal.Value + nonSaleItemsTotal;
        }

        public void Scan(IItem newItem)
        {
            if (newItem == null)
                throw new ArgumentNullException(nameof(newItem), "Scanned item can not be null");

            //check we haven't scanned the same item and it has different pricing information
            var existingItem = _Basket.Where(item => item.SKU == newItem.SKU 
                                            && (item.UnitPrice != newItem.UnitPrice 
                                            || item.MultiBuyPrice != newItem.MultiBuyPrice
                                            || item.MultiBuyItemsRequired != newItem.MultiBuyItemsRequired)).FirstOrDefault();

            if (existingItem != null)
                throw new InvalidPricingException("Item has been scanned with different pricing information");

            ShoppingItem scannedItem = newItem as ShoppingItem;
            _Basket.Add(scannedItem);
        }
    }
}