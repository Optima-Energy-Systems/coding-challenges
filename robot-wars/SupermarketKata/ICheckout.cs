using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketKata
{
    interface ICheckout
    {
        void Scan(string item);

        int GetTotalPrice();

        void StartScanning();

        int ItemCount(string item);

        void SetPrices(List<Price> prices);
    }
}
