using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket.Domain;

namespace Supermarket.Test
{
    [TestClass]
    public class Items
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidSkuException))]
        public void WhenSkuIsNotLetter_AnExceptionIsThrown()
        {
            ShoppingItem item = new ShoppingItem('@', 10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPricingException))]
        public void WhenUnitPriceIsZero_AnExceptionIsThrown()
        {
            ShoppingItem item = new ShoppingItem('A', 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPricingException))]
        public void WhenUnitPriceIsNegative_AnExceptionIsThrown()
        {
            ShoppingItem item = new ShoppingItem('A', -10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPricingException))]
        public void WhenMultiBuyPriceLessThanUnitPrice_AnExceptionIsThrown()
        {
            ShoppingItem item = new ShoppingItem('A', 5, 2 , 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPricingException))]
        public void WhenMultiBuyPriceProvidedButItemCountIsNot_AnExceptionIsThrown()
        {
            ShoppingItem item = new ShoppingItem('A', 5, null, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPricingException))]
        public void WhenMultiBuyItemCountProvidedButMultiBuyPriceIsNot_AnExceptionIsThrown()
        {
            ShoppingItem item = new ShoppingItem('A', 5, 2, null);
        }
    }
}