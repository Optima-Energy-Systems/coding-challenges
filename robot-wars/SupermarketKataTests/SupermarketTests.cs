using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketKata;
using System.Collections.Generic;

namespace SupermarketKataTests
{
    [TestClass]
    public class SupermarketTests
    {
        [TestMethod]
        public void TestAddingItems()
        {
            var checkout = new Checkout();
            checkout.StartScanning();

            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("C");

            Assert.AreEqual(checkout.ItemCount("A"), 3);
            Assert.AreEqual(checkout.ItemCount("B"), 2);
            Assert.AreEqual(checkout.ItemCount("C"), 1);
            Assert.AreEqual(checkout.ItemCount("D"), 0);
        }

        [TestMethod]
        public void TestAddingItemsPrices()
        {
            Price priceA = new Price("A", 50);
            Price priceB = new Price("B", 30);
            Price priceC = new Price("C", 20);
            Price priceD = new Price("D", 15);

            priceA.SetMultiPrice(3, 130);
            priceB.SetMultiPrice(2, 45);

            Assert.AreEqual(priceA.Sku, "A");
            Assert.AreEqual(priceA.SingleItemPrice, 50);
            Assert.AreEqual(priceA.MultiItemCount, 3);
            Assert.AreEqual(priceA.MultiItemPrice, 130);
        }

        [TestMethod]
        public void TestTotal()
        {
            Price priceA = new Price("A", 50);
            Price priceB = new Price("B", 30);
            Price priceC = new Price("C", 20);
            Price priceD = new Price("D", 15);

            priceA.SetMultiPrice(3, 130);
            priceB.SetMultiPrice(2, 45);

            List<Price> prices = new List<Price>();
            prices.Add(priceA);
            prices.Add(priceB);
            prices.Add(priceC);
            prices.Add(priceD);

            var checkout = new Checkout();
            checkout.StartScanning();

            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");

            checkout.SetPrices(prices);

            Assert.AreEqual(checkout.GetTotalPrice(), 95);
        }
    }
}
