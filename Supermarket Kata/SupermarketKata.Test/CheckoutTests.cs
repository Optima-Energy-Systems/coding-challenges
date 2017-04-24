using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SupermarketKata.Test
{
    [TestClass]
    public class CheckoutTests
    {
        private Checkout _checkout;

        [TestInitialize]
        public void Initialize()
        {
            _checkout = Checkout.LoadProductsFromJson(@"[{
                'SKU': 'A',
                'UnitPrice': 1,
                'SpecialPriceThreshold': 3,
                'SpecialPrice': 2
            }, {
                'SKU': 'B',
                'UnitPrice': 10
            }]");
        }

        [TestMethod]
        public void CheckoutLoadProducts()
        {
            var checkout = Checkout.LoadProductsFromJson(@"[{
                'SKU': 'A',
                'UnitPrice': 50,
                'SpecialPriceThreshold': 3,
                'SpecialPrice': 130
            }]");

            Assert.AreEqual(1, checkout.Products.Length);

            var products = checkout.Products[0];

            Assert.AreEqual("A", products.SKU);
            Assert.AreEqual(50, products.UnitPrice);
            Assert.AreEqual(3, products.SpecialPriceThreshold);
            Assert.AreEqual(130, products.SpecialPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckoutLoadNotUniqueProducts()
        {
            Checkout.LoadProductsFromJson(@"[{
                'SKU': 'A',
                'UnitPrice': 1
            }, {
                'SKU': 'A',
                'UnitPrice': 1
            }]");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckoutScanUnknownItem()
        {
            _checkout.Scan("X");
        }

        [TestMethod]
        public void CheckoutScanAddItem()
        {
            _checkout.Scan("A");
            var total = _checkout.GetTotalPrice();

            Assert.AreEqual(1, total);
        }

        [TestMethod]
        public void CheckoutSpecialPrice()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");

            var total = _checkout.GetTotalPrice();

            Assert.AreEqual(2, total);
        }

        [TestMethod]
        public void CheckoutSpecialPriceAndExtra()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");

            var total = _checkout.GetTotalPrice();

            Assert.AreEqual(3, total);
        }

        [TestMethod]
        public void CheckoutAnyOrder()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("A");
            _checkout.Scan("A");

            var total = _checkout.GetTotalPrice();

            Assert.AreEqual(13, total);
        }
    }
}
