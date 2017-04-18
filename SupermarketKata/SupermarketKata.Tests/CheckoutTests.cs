using Xunit;

namespace SupermarketKata.Tests {

    public class CheckoutTests
    {
        // done: if nothing has been added to the checkout the total price is zero
        // done: total price is correct if a single item has been added
        // done: total price is correct if multiple different items have been added
        // done: total price is correct for multiple items not covered by a multi item special price
        // done: total price is correct for multi item special prices
        // done: total price is correct when an item exceedes the multi item quantity
        // done: items that are not in the price list are ignored

        [Fact]
        public void if_nothing_has_been_added_to_the_checkout_the_total_price_is_zero() {

            var context = createContext();

            Assert.Equal( 0, context.Checkout.GetTotalPrice() );

        }

        [Fact]
        public void total_price_is_correct_if_a_single_item_has_been_added() {

            var context = createContext();

            context.Checkout.Scan( context.ItemA.Code );

            Assert.Equal( context.ItemA.UnitPrice, context.Checkout.GetTotalPrice() );
        }

        [Fact]
        public void total_price_is_correct_if_multiple_different_items_have_been_added() {

            var context = createContext();

            context.Checkout.Scan( context.ItemA.Code );
            context.Checkout.Scan( context.ItemB.Code );

            Assert.Equal(
                context.ItemA.UnitPrice + context.ItemB.UnitPrice,
                context.Checkout.GetTotalPrice()
            );

        }

        [Fact]
        public void total_price_is_correct_for_multiple_items_not_covered_by_a_multi_item_special_price() {

            var context = createContext();

            context.Checkout.Scan( context.ItemA.Code );
            context.Checkout.Scan( context.ItemA.Code );

            Assert.Equal(
                context.ItemA.UnitPrice * 2,
                context.Checkout.GetTotalPrice()
            );
        }

        [Fact]
        public void total_price_is_correct_for_multi_item_special_prices() {

            var context = createContext();

            context.Checkout.Scan( context.ItemB.Code );
            context.Checkout.Scan( context.ItemB.Code );

            Assert.Equal( context.ItemBMultiItemPrice.Price, context.Checkout.GetTotalPrice() );

        }

        [Fact]
        public void total_price_is_correct_when_an_item_exceedes_the_multi_item_quantity() {

            var context = createContext();

            context.Checkout.Scan( context.ItemB.Code );
            context.Checkout.Scan( context.ItemB.Code );
            context.Checkout.Scan( context.ItemB.Code );

            Assert.Equal( context.ItemBMultiItemPrice.Price + context.ItemB.UnitPrice, context.Checkout.GetTotalPrice() );

        }

        [Fact]
        public void items_that_are_not_in_the_price_list_are_ignored() {

            var context = createContext();

            context.Checkout.Scan( "This is not an item code" );

            Assert.Equal( 0, context.Checkout.GetTotalPrice() );

        }

        private TestContext createContext() {

            var itemAPrice = new PriceRecord {
                Code = "A",
                UnitPrice = 2
            };
            var itemA = new StockKeepingUnitPrice( itemAPrice.Code, new Price( itemAPrice.UnitPrice ) );

            var itemBPrice = new PriceRecord {
                Code = "B",
                UnitPrice = 3
            };
            var itemBMultiItemPrice = new MultiItemPrice( 2, 4 );
            var itemB = new StockKeepingUnitPrice( itemBPrice.Code, new Price ( itemBPrice.UnitPrice, itemBMultiItemPrice ) );

            var checkout = new Checkout( new PriceList( new [] { itemA, itemB } ));

            return new TestContext {
                ItemA = itemAPrice,
                ItemB = itemBPrice,
                ItemBMultiItemPrice = itemBMultiItemPrice,
                Checkout = checkout
            };

        }

        private class PriceRecord {
            public string Code { get; set; }
            public int UnitPrice { get; set; }
        }

        private class TestContext {
            public PriceRecord ItemA { get; set; }
            public PriceRecord ItemB { get; set; }
            public MultiItemPrice ItemBMultiItemPrice { get; set; }
            
            public ICheckout Checkout { get; set; }
 
        }
    }
}
