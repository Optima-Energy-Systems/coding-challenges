using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var checkout = Checkout.LoadDefaultProducts();

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("C");
            checkout.Scan("A");
            checkout.Scan("D");
            checkout.Scan("D");

            var total = checkout.GetTotalPrice();
        }
    }
}
