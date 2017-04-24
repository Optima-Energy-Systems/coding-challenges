using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket;

namespace SupermarketTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void TestConstructorWithSpecialOffer()
        {
            Supermarket.Item item = new Supermarket.Item("Bob", 123, 2, 210);

            Assert.AreEqual(item.GetSku(), "Bob");
            Assert.AreEqual(item.GetPrice(), 123);
            Assert.IsTrue(item.HasSpecialOffer());
            Assert.AreEqual(item.GetSpecialOfferMultiple(), 2);
            Assert.AreEqual(item.GetSpecialOfferPrice(), 210);
        }

        [TestMethod]
        public void TestConstructorWithoutSpecialOffer()
        {
            Supermarket.Item item = new Supermarket.Item("Rob", 456);

            Assert.AreEqual(item.GetSku(), "Rob");
            Assert.AreEqual(item.GetPrice(), 456);
            Assert.IsFalse(item.HasSpecialOffer());
            Assert.AreEqual(item.GetSpecialOfferMultiple(), 0);
            Assert.AreEqual(item.GetSpecialOfferPrice(), 0);
        }

        [TestMethod]
        public void TestSetValidSpecialOffer()
        {
            Supermarket.Item item = new Supermarket.Item("Andy", 789);
            Assert.IsFalse(item.HasSpecialOffer());

            item.SetSpecialOffer(4, 2800);

            Assert.IsTrue(item.HasSpecialOffer());
            Assert.AreEqual(item.GetSpecialOfferMultiple(), 4);
            Assert.AreEqual(item.GetSpecialOfferPrice(), 2800);
        }

        [TestMethod]
        [ExpectedException(typeof(SupermarketException))]
        public void TestSetInvalidSpecialOffer()
        {
            Supermarket.Item item = new Supermarket.Item("Andy", 789);
            Assert.IsFalse(item.HasSpecialOffer());
            item.SetSpecialOffer(5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(SupermarketException))]
        public void TestSetWorseValueThanStandardPriceSpecialOffer()
        {
            Supermarket.Item item = new Supermarket.Item("Xyz", 5);
            item.SetSpecialOffer(2, 11); // Worse value than standard price.
        }

        [TestMethod]
        public void TestRemoveSpecialOffer()
        {
            Supermarket.Item item = new Supermarket.Item("Cheese", 5, 4, 18);
            Assert.IsTrue(item.HasSpecialOffer());
            item.RemoveSpecialOffer();
            Assert.IsFalse(item.HasSpecialOffer());
            Assert.AreEqual(0, item.GetSpecialOfferMultiple());
            Assert.AreEqual(0, item.GetSpecialOfferPrice());
        }

    }
}
