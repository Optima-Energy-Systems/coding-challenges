using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout
{
    class listofitems
    {
        LinkedList<product> list = new LinkedList<product>();

        public listofitems()
        {
            //creates a list of items
            list.AddLast(new product("A", 50, 3, 130));
            list.AddLast(new product("B", 30, 2, 45));
            list.AddLast(new product("C", 20));
            list.AddLast(new product("D", 15));
        }

        public void addNewItem(string s, int p)
        {
            //adds extra items
            list.AddLast(new product(s, p));
        }

        public void scanItem(string s)
        {
            //searches for items
            foreach(product item in list)
            {
                if(item.getSKU() == s)
                {
                    //increases quantity by one
                    item.quanity++;
                }
            }
        }

        public void clear()
        {
            foreach(product item in list)
            {
                item.quanity = 0;
            }
        }

        public int getTotal()

        {
            int total = 0;
            //searches through all scanned items and calculates price
            foreach(product item in list)
            {
                
                if (item.quanity > 0)
                {
                    if (item.hasSpecialOffer())
                    {
                        total = total + ((item.getQuantity() / item.specialAmount) * item.specialPrice) + ((item.quanity - ((item.getQuantity() / item.specialAmount) * item.specialAmount)) * item.getPrice());
                    }
                    else
                    {
                        total = total + (item.getQuantity() * item.getPrice());
                    }
                }
            }

            return total;
        }
        
    }
}
