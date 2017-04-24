using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket;

namespace SupermarketTests
{
    [TestClass]
    public class CheckoutTests
    {
        Item itemA = new Item("A", 50, 3, 130);
        Item itemB = new Item("B", 30, 2, 45);
        Item itemC = new Item("C", 20);
        Item itemD = new Item("D", 15);

        ItemRepository itemRepository = new ItemRepository();

        [TestInitialize]
        private void addAllItems()
        {
            itemRepository.SaveItem(itemA);
            itemRepository.SaveItem(itemB);
            itemRepository.SaveItem(itemC);
            itemRepository.SaveItem(itemD);
        }

        [TestMethod]
        public void TestCheckoutRegularItemsAllSame()
        {
            addAllItems();
            Checkout c = new Checkout(itemRepository);
            c.Scan("C");
            Assert.AreEqual(20, c.GetTotalPrice());
            c.Scan("C");
            Assert.AreEqual(40, c.GetTotalPrice());
            c.Scan("C");
            Assert.AreEqual(60, c.GetTotalPrice());
        }

        [TestMethod]
        public void TestCheckoutRegularItemsDifferentOnes()
        {
            addAllItems();
            Checkout c = new Checkout(itemRepository);
            c.Scan("C");
            Assert.AreEqual(20, c.GetTotalPrice());
            c.Scan("D");
            Assert.AreEqual(35, c.GetTotalPrice());
            c.Scan("C");
            Assert.AreEqual(55, c.GetTotalPrice());
            c.Scan("D");
            Assert.AreEqual(70, c.GetTotalPrice());
            c.Scan("C");
            Assert.AreEqual(90, c.GetTotalPrice());
        }

        [TestMethod]
        public void TestCheckoutSpecialOfferItemsAllSame()
        {
            addAllItems();
            Checkout c = new Checkout(itemRepository);
            c.Scan("A");
            Assert.AreEqual(50, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(100, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(130, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(180, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(230, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(260, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(310, c.GetTotalPrice());
        }

        [TestMethod]
        public void TestCheckoutSpecialOfferItemsDifferentOnes()
        {
            addAllItems();
            Checkout c = new Checkout(itemRepository);
            c.Scan("A");
            Assert.AreEqual(50, c.GetTotalPrice());
            c.Scan("B");
            Assert.AreEqual(80, c.GetTotalPrice());
            c.Scan("B");
            Assert.AreEqual(95, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(145, c.GetTotalPrice());
            c.Scan("B");
            Assert.AreEqual(175, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(205, c.GetTotalPrice());
            c.Scan("B");
            Assert.AreEqual(220, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(270, c.GetTotalPrice());
            c.Scan("B");
            Assert.AreEqual(300, c.GetTotalPrice());
        }

        [TestMethod]
        public void TestCheckoutRegularAndSpecialOfferItems()
        {
            addAllItems();
            Checkout c = new Checkout(itemRepository);
            c.Scan("C");
            Assert.AreEqual(20, c.GetTotalPrice());
            c.Scan("B");
            Assert.AreEqual(50, c.GetTotalPrice());
            c.Scan("B");
            Assert.AreEqual(65, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(115, c.GetTotalPrice());
            c.Scan("B");
            Assert.AreEqual(145, c.GetTotalPrice());
            c.Scan("D");
            Assert.AreEqual(160, c.GetTotalPrice());
            c.Scan("D");
            Assert.AreEqual(175, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(225, c.GetTotalPrice());
            c.Scan("A");
            Assert.AreEqual(255, c.GetTotalPrice());
            c.Scan("B");
            Assert.AreEqual(270, c.GetTotalPrice());
            c.Scan("C");
            Assert.AreEqual(290, c.GetTotalPrice());
        }

        [TestMethod]
        public void TestClear()
        {
            addAllItems();
            Checkout c = new Checkout(itemRepository);
            c.Scan("C");
            Assert.AreEqual(20, c.GetTotalPrice());
            c.Scan("B");
            Assert.AreEqual(50, c.GetTotalPrice());
            c.Clear();
            Assert.AreEqual(0, c.GetTotalPrice());
        }
    }
}
