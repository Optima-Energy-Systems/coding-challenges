namespace SupermarketKata {

    public class Price {
        private readonly int unitPrice;
        private readonly MultiItemPrice multiItemPrice;

        public Price( int unitPrice, MultiItemPrice multiItemPrice ) {
            this.unitPrice = unitPrice;
            this.multiItemPrice = multiItemPrice;
        }

        public Price( int unitPrice )
                : this( unitPrice, null ) { }

        public int PriceFor( int quantity ) {

            return multiItemPrice == null
                        ? unitPrice * quantity
                        : ( ( multiItemPrice.Price * ( quantity / multiItemPrice.Quantity ) )
                          + ( unitPrice * ( quantity % multiItemPrice.Quantity ) ) );
        }
    }

    public class MultiItemPrice {

        public MultiItemPrice( int quantity, int price ) {

            this.Quantity = quantity;
            this.Price = price;

        }

        public int Quantity { get; }
        public int Price { get; }
    }


}
