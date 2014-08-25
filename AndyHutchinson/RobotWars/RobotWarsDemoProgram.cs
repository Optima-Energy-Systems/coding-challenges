using System;
using System.IO;

namespace RobotWars
{
    class RobotWarsDemoProgram
    {
        private const string DEFAULT_FILE = "..\\..\\SampleInput.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("****** Andy Hutchinson - Robot Wars Demo ******");
            Console.WriteLine("***********************************************");
            Console.WriteLine();
            Console.WriteLine("*** Reading deault input file: " + DEFAULT_FILE + " ***");
            Console.WriteLine();

            InputParser parser = new InputParser(DEFAULT_FILE, true);
            parser.Parse();

            Console.WriteLine("*** See the unit tests for more examples ***");
            Console.WriteLine("*** You can enter more input, or Press <Ctrl-C> to exit ***");
            Console.WriteLine();

            parser = new InputParser(true);
            parser.Parse();

        }


    }
}
