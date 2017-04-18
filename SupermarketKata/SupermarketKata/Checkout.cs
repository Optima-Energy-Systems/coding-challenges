using System;
using System.Linq;

namespace SupermarketKata {

    public class Checkout : ICheckout {
        private readonly PriceList priceList;
        private readonly ScanedItems scannedItems;

        public Checkout( PriceList priceList ) {
            if( priceList == null ) throw new ArgumentNullException( nameof( priceList ) );


            this.priceList = priceList;
            this.scannedItems = new ScanedItems();
        }

 
        public void Scan( string item ) {
            scannedItems.Add( item );
        }

        public int GetTotalPrice() {

            return
                scannedItems
                    .Items
                    .Select( item => priceList[ item.Code ].PriceFor( item.Quantity ) )
                    .Aggregate( 0, ( acc, n ) => acc += n );

        }
    }
    
}
