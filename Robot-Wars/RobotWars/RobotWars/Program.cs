using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                                   H e r o e s!");
            Console.WriteLine("             Welcome to the   R_O_B_O_T    W_A_R_S   Contest!!\n\n\n");

            Console.WriteLine("First thing first. Let's establish the Arena size, height and weight, one number for each, separated by a space");
            int height = 0;
            int width = 0;
            string rawInputArenaSize = Console.ReadLine();
            var rawNumbers = rawInputArenaSize.Split(' ');

            try
            {
                width = int.Parse(rawNumbers[0]);
                height = int.Parse(rawNumbers[1]);
            }
            catch (FormatException exception)
            {
                Console.WriteLine("Let's try again. \nEnter height and weight, one number for each, separated by a space");
            }
            char[,] arena = new char[width, height];

            //verbose feedback of size:
            Console.WriteLine("Height is " + height + " and Width is " + width);

            //building arena:

           
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    arena[i, j] = 'A';

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
                    Console.Write(arena[i, j]);
                }
            }

            Console.WriteLine($"    Total arena size is {arena.Length} units");
            //Console.WriteLine(Array.IndexOf(arena, '1'));
            Console.WriteLine("Enter to continue...");


            Console.ReadLine();

            Robot robot1 = new Robot();
            robot1.SteerNMove();
            
            //Console.WriteLine($"MovingRobot return and heading {robot1.Heading()}");
                        
        }
        
    }
}
