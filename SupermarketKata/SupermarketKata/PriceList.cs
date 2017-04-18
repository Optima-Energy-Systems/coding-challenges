using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketKata {

    public class PriceList {
        private readonly Dictionary<string, Price> priceList;
        private readonly Price nullPrice;

        public PriceList( IEnumerable<StockKeepingUnitPrice> prices ) {
            if( prices == null ) throw new ArgumentNullException( nameof( prices ) );


            priceList = prices.ToDictionary( i => i.Code, i => i.Price );
            nullPrice = new Price( 0 );
        }

        public Price this[ string code ] {
            get {

                return priceList.ContainsKey( code )
                     ? priceList[ code ]
                     : nullPrice;

            }
        }
    }

    public class StockKeepingUnitPrice {

        public StockKeepingUnitPrice( string code, Price price ) {
            if( price == null ) throw new ArgumentNullException( nameof( price ) );


            this.Code = code;
            this.Price = price;
        }

        public string Code { get; }
        public Price Price { get; }

    }


}
