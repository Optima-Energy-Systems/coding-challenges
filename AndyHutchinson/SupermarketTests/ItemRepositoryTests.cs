using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket;

namespace SupermarketTests
{
    [TestClass]
    public class ItemRepositoryTests
    {
        [TestMethod]
        public void TestSaveAndFindItem()
        {
            Item i = new Item("A", 2, 3, 5);
            ItemRepository r = new ItemRepository();
            r.SaveItem(i);
            Assert.AreSame(i, r.FindItem("A"));
        }

        [TestMethod]
        public void TestSaveItemWithSkuThatExistsFunctionsAsReplace()
        {
            Item i1 = new Item("B", 2, 2, 3);
            Item i2 = new Item("B", 4, 3, 10);
            ItemRepository r = new ItemRepository();

            r.SaveItem(i1);
            r.SaveItem(i2);
            Assert.AreSame(i2, r.FindItem("B"));
        }

        [TestMethod]
        public void TestRemoveItem()
        {
            Item i = new Item("C", 1, 3, 2);
            ItemRepository r = new ItemRepository();
            r.SaveItem(i);
            Assert.AreSame(i, r.FindItem("C"));
            r.RemoveItem(i);
            Assert.IsNull(r.FindItem("C"));
        }
    }
}
