using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketKata {

    public class ScanedItems {
        private readonly Dictionary<string, int> scannedItems = new Dictionary<string, int>();

        public class Item {

            public Item( string code, int quantity ) {
                if( quantity < 0 ) throw new ArgumentException( nameof( quantity ) );


                this.Code = code;
                this.Quantity = quantity;
            }

            public string Code { get; }
            public int Quantity { get; }
        }

        public void Add( string code ) {

            if( !scannedItems.ContainsKey( code ) ) {
                scannedItems[ code ] = 0;
            }
            scannedItems[ code ] += 1;

        }

        public IEnumerable<Item> Items {
            get {

                return
                    scannedItems
                        .Select( i => new Item( i.Key, i.Value ) );

            }
        }

    }

}
