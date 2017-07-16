using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout
{

    public class product
    {
        public string sku;
        public int price;
        public int specialAmount = 0;
        public int specialPrice;
        public int quanity;

        public product(string s, int p)
        {
            //an item that is not on sale
            sku = s;
            price = p;
        }

        public product(string s, int p, int a, int sp)
        {
            //an item with a special offer
            sku = s;
            price = p;
            specialAmount = a;
            specialPrice = sp;
        }

        public bool hasSpecialOffer()
        {
            //check to see if item qualifies for special offer (ex. 3 for 130)
            if (specialAmount > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public void makeSpecialOffer(int q, int p)
        {
            //allows offers to be created
            specialAmount = q;
            specialPrice = p;
        }

        public void removeOffer()
        {
            //removes offer
            specialAmount = 0;
        }

        public int getPrice()
        {
            return price;
        }

        public string getSKU()
        {
            return sku;
        }

        public int getQuantity()
        {
            return quanity;
        }
    }
}
