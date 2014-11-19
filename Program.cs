using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotWar
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.Write("Enter the grid top coordinates:");
                String commandLineInput = Console.ReadLine();
                
                Console.Write("Enter the number of robots:");
                int numRobots = Convert.ToInt16(Console.ReadLine());

                Dictionary <int, Robot>  robotList = new Dictionary<int, Robot>();

                for (int i = 1; i <= numRobots; i++)
                {
                    Console.Write("Enter the Robo" + i + " position:");
                    char[] roboPosition = ((String)Console.ReadLine()).ToCharArray();
                    Console.Write("Enter the Commands:");
                    char[] roboCommands = ((String)Console.ReadLine()).ToCharArray();
                    Robot newRobot = new Robot();
                    newRobot.xGrid = Convert.ToInt16(roboPosition[0].ToString());
                    newRobot.yGrid = Convert.ToInt16(roboPosition[1].ToString());
                    newRobot.facingPosition = Convert.ToString(roboPosition[2].ToString());
                    newRobot.commands = roboCommands;
                    robotList.Add(i, newRobot);
                }

                for (int i = 1; i <= numRobots; i++)
                {
                    Console.WriteLine ("Robot " + i + " current Position is " + robotList[i].getFinalPosition());

                }
               
                Console.WriteLine("Press a key to exit");
                String readKey = Console.ReadLine();
            }
            catch(Exception e){
                //exception handling needs to be done.
            }


        }
    }
}
