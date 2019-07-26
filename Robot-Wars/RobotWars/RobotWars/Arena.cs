using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Arena
    {
        private readonly int height;
        private readonly int width;

        public Arena ()
        {
            Console.WriteLine("First thing first. Let's establish the Arena size, height and weight, one number for each, separated by a space");
            string rawInputArenaSize = Console.ReadLine();
            var rawNumbers = rawInputArenaSize.Split(' ');
            height = int.Parse(rawNumbers[0]);
            width = int.Parse(rawNumbers[1]);
            int arenaSize = height * width;

            Console.WriteLine("Height is " + height + " and Width is " + width);
            
            //building arena:
            char[] arena = new char[arenaSize];
            for (int i = 0; i < arenaSize; i++)
            {
                arena[i] = 'A';

            }
            //initialize robots position by making the char in pos 0,0
            //different to others from the array.
            //to be reviewed if unnecessary
            arena[0] = '1';

            for (int i = 0; i < arena.Length; i++)
            {
                Console.Write(arena[i]);
            }

            Console.WriteLine(arena.Length);
            Console.WriteLine(Array.IndexOf(arena, '1'));



            Console.ReadLine();

        }
        

    }
}
