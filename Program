using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkout
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckOut newCustomerBasket = new CheckOut();

            //simulating a scan manually below;
            newCustomerBasket.Scan("A");
            newCustomerBasket.Scan("B");
            newCustomerBasket.Scan("A");
            newCustomerBasket.Scan("B");
            newCustomerBasket.Scan("A");
            newCustomerBasket.Scan("B");
            newCustomerBasket.Scan("A");

           Console.WriteLine("  Total  " + newCustomerBasket.GetTotalPrice());

           Console.WriteLine(" Press any key to exit ");

            string x = Console.ReadLine();
        }
    }
}
