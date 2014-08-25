using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    /// <summary>
    /// An Item always has an sku and a price, and may have a 
    /// special offer, in which case it will also have a 
    /// specialOfferMultiple and specialOfferPrice.
    /// </summary>
    public class Item
    {
        private string sku;
        private double price;

        private int    specialOfferMultiple;
        private double specialOfferPrice;

        /**
         * Construct an Item with special offer details.
         */
        public Item(string sku, double price, int specialOfferMultiple, double specialOfferPrice)
        {
            this.sku = sku;
            this.price = price;
            SetSpecialOffer(specialOfferMultiple, specialOfferPrice);
        }

        /**
         * Construct an Item without a special offer.
         */
        public Item(string sku, double price) : this(sku, price, 0, 0)
        {
        }

        public string GetSku()
        {
            return sku;
        }

        public double GetPrice()
        {
            return price;
        }

        public int GetSpecialOfferMultiple()
        {
            return specialOfferMultiple;
        }

        public double GetSpecialOfferPrice()
        {
            return specialOfferPrice;
        }

        public bool HasSpecialOffer()
        {
            return specialOfferMultiple > 0;
        }

        /**
         * Set a special offer on this item, the offer details must be valid.
         * Setting both of the details to 0 removes the special offer on this
         * item (although easier to call removeSpecialOffer).
         */
        public void SetSpecialOffer(int specialOfferMultiple, double specialOfferPrice)
        {
            ValidateSpecialOffer(specialOfferMultiple, specialOfferPrice);
            this.specialOfferMultiple = specialOfferMultiple;
            this.specialOfferPrice = specialOfferPrice;
        }

        /**
         * Remove the special offer on this item.
         */
        public void RemoveSpecialOffer()
        {
            this.specialOfferPrice = this.specialOfferMultiple = 0;
        }

        /**
         * A special offer is valid if both of its components are positive.
         * The offer must also be better value than the item's single price.
         * Both components may also be zero, which means that there is not
         * a special offer on this item.
         */
        private void ValidateSpecialOffer(int offerMultiple, double offerPrice) 
        {
            if ((offerPrice == 0 && offerMultiple != 0) ||
                (offerMultiple == 0 && offerPrice != 0))
            {
                throw new SupermarketException("Invalid Special Offer");
            }

            if (offerPrice / offerMultiple >= price)
            {
                throw new SupermarketException("Bad value special offer");
            }
        }

        /**
         * Get string representation, for demo.
         */
        public override string ToString()
        {
            return "Item - sku:" + GetSku() +
                   " price:" + GetPrice() +
                   " specialOffer:" + HasSpecialOffer() +
                   (HasSpecialOffer() ? " offerMultiple:" + GetSpecialOfferMultiple() +
                                        " offerPrice:" + GetSpecialOfferPrice()
                                        : "");
        }
    }
}