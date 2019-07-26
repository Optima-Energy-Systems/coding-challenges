using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Arena
    {
        int height;
        int width;

        public Arena ()
        {
            Console.WriteLine("First thing first. Let's establish the Arena size, height and weight, one number for each, separated by a space");
            string rawInputArenaSize = Console.ReadLine();
            var rawNumbers = rawInputArenaSize.Split(' ');
            
            try
            {
                width = int.Parse(rawNumbers[0]);
                height = int.Parse(rawNumbers[1]);
            }
            catch(FormatException exception)
            {
                Console.WriteLine("Let's try again. \nEnter height and weight, one number for each, separated by a space");
            }
            
            int arenaSize = height * width;

            Console.WriteLine("Height is " + height + " and Width is " + width);
            
            //building arena:
            char[,] arena = new char[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    arena[i,j] = 'A';

                }

            }

            //initialize robots position by making the char in pos 0,0
            //different to others from the array.
            //to be reviewed if unnecessary
            //arena[0,0] = '1';


            //checking the array
            for (int i = 0; i < arena.GetUpperBound(0); i++)
            {
                for (int j = 0; j < arena.GetUpperBound(1); j++)
                {
                    Console.WriteLine(arena[i,j]);
                }
            }

            Console.WriteLine(arena.Length);
            //Console.WriteLine(Array.IndexOf(arena, '1'));



            Console.ReadLine();

        }

       
        

    }
}
