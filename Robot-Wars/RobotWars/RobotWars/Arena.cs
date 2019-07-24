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
            int ArenaSize = height * width;

            Console.WriteLine("Height is " + height + " and Width is " + width);
            //Console.WriteLine("Height and width are " + height.GetType()  + " and " +width.GetType());
            char[] arena = new char[ArenaSize];
            for (int i = 0; i < ArenaSize; i++)
            {
                arena[i] = 'A';

            }
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
