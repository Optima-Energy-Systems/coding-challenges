using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket.Domain;

namespace Supermarket.Test
{
    [TestClass]
    public class Checkouts
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenScannedItemIsNull_AnExceptionIsThrown()
        {
            Checkout checkout = new Checkout();
            checkout.Scan(null);
        }

        [TestMethod]
        public void WhenItemScanned_CorrectBasketCountReturned()
        {
            ShoppingItem item = new ShoppingItem('A', 10);

            Checkout checkout = new Checkout();
            checkout.Scan(item);

            Assert.AreEqual(checkout.BasketItemCount, 1);
        }

        [TestMethod]
        public void WhenSingleItems_CorrectTotalReturned()
        {
            ShoppingItem item = new ShoppingItem('A', 10);
            ShoppingItem item2 = new ShoppingItem('B', 100);

            Checkout checkout = new Checkout();
            checkout.Scan(item);
            checkout.Scan(item2);

            Assert.AreEqual(checkout.GetTotalPrice(), 110);
        }

        [TestMethod]
        public void WhenExactNumberOfMultiBuyItemsScanned_CorrectTotalReturned()
        {
            ShoppingItem item = new ShoppingItem('A', 10, 2, 15);
            ShoppingItem item2 = new ShoppingItem('A', 10, 2, 15);

            Checkout checkout = new Checkout();
            checkout.Scan(item);
            checkout.Scan(item2);

            Assert.AreEqual(checkout.GetTotalPrice(), 15);
        }

        [TestMethod]
        public void WhenScannedItemsLessThanMultiBuyItemTotal_CorrectTotalReturned()
        {
            ShoppingItem item = new ShoppingItem('A', 10, 2, 15);

            Checkout checkout = new Checkout();
            checkout.Scan(item);

            Assert.AreEqual(checkout.GetTotalPrice(), 10);
        }

        [TestMethod]
        public void WhenMoreThanNumberOfMultiBuyItemsScanned_CorrectTotalReturned()
        {
            ShoppingItem item = new ShoppingItem('A', 10, 2, 15);
            ShoppingItem item2 = new ShoppingItem('A', 10, 2, 15);
            ShoppingItem item3 = new ShoppingItem('A', 10, 2, 15);

            Checkout checkout = new Checkout();
            checkout.Scan(item);
            checkout.Scan(item2);
            checkout.Scan(item3);

            Assert.AreEqual(checkout.GetTotalPrice(), 25);
        }

        [TestMethod]
        public void WhenDoubleNumberOfMultiBuyItemsScanned_CorrectTotalReturned()
        {
            ShoppingItem item = new ShoppingItem('A', 10, 2, 15);
            ShoppingItem item2 = new ShoppingItem('A', 10, 2, 15);
            ShoppingItem item3 = new ShoppingItem('A', 10, 2, 15);
            ShoppingItem item4 = new ShoppingItem('A', 10, 2, 15);

            Checkout checkout = new Checkout();
            checkout.Scan(item);
            checkout.Scan(item2);
            checkout.Scan(item3);
            checkout.Scan(item4);

            Assert.AreEqual(checkout.GetTotalPrice(), 30);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPricingException))]
        public void WhenSameSkuScannedWithDifferentPricingInfo_AnExceptionIsThrown()
        {
            ShoppingItem item = new ShoppingItem('A', 10, 2, 15);
            ShoppingItem item2 = new ShoppingItem('A', 3, 2, 15);

            Checkout checkout = new Checkout();
            checkout.Scan(item);
            checkout.Scan(item2);
        }
    }
}