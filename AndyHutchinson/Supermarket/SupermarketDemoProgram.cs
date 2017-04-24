using System;

namespace Supermarket
{
    class SupermarketDemoProgram
    {
        /**
         * Quickly demonstrate supermarket functionality.
         */
        static void Main(string[] args)
        {
            Item itemA = new Item("A", 50, 3, 130);
            Item itemB = new Item("B", 30, 2, 45);
            Item itemC = new Item("C", 20);
            Item itemD = new Item("D", 15);

            ItemRepository itemRepository = new ItemRepository();
            itemRepository.SaveItem(itemA);
            itemRepository.SaveItem(itemB);
            itemRepository.SaveItem(itemC);
            itemRepository.SaveItem(itemD);

            Checkout checkout = new Checkout(itemRepository);

            Console.WriteLine("************************************************");
            Console.WriteLine("****** Andy Hutchinson - Supermarket Demo ******");
            Console.WriteLine("************************************************");
            Console.WriteLine();
            Console.WriteLine("*** Example Items: ***");
            Console.WriteLine();
            Console.WriteLine(itemRepository);
            Console.WriteLine("*** Scanning Items at the checkout: ***");
            Console.WriteLine();

            checkout.Scan("B");
            Console.WriteLine("Scanned Item 'B' " + checkout);
            checkout.Scan("A");
            Console.WriteLine("Scanned Item 'A' " + checkout);
            checkout.Scan("B");
            Console.WriteLine("Scanned Item 'B' " + checkout);

            Console.WriteLine();
            Console.WriteLine("*** (See the unit tests for further examples) ***");
            Console.WriteLine();
            Console.WriteLine("*** Press <Enter> to exit ***");
            Console.ReadLine();

        }
    }
}
