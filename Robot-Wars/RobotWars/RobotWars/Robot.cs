using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using RobotWars.Arena;

namespace RobotWars
{
    public class Robot
    {
        string rawMoveSequenceCapture = "";
        char cardinal = '0';


        public int Move(string moveCommand)
        {
            int x=0;
            if (moveCommand == "M")
            {
                x = x + 1;
            }
            return x;

            
        }
        public Robot()
        {
            Console.WriteLine("\nNow enter your beautiful name, my star: \n");
            string name = Console.ReadLine();
            Console.WriteLine("\nThis is not for heart fainted! Enter the sequence that will steer and move your \nbuddy Robot, with CAPITAL LETTERS, to the desired place inside the Arena.\nThink (or RAM??) well, " +name+ " darling, or you may not get the chance to move the tin again :D\n");
            

        }

        public void SteerNMove()
        {
            string rawMoveSequenceCapture = Console.ReadLine();
            int countLeftTurns = rawMoveSequenceCapture.Count(f => f == 'L');
            int countRightTurns = rawMoveSequenceCapture.Count(f => f == 'R');
            int countMoves = rawMoveSequenceCapture.Count(f => f == 'M');
            int spinVector = countRightTurns - countLeftTurns;
            char heading = '0';
            //feedback, next three lines to be deleted
            Console.WriteLine("Left " + countLeftTurns);
            Console.WriteLine("Right " + countRightTurns);
            Console.WriteLine("moves " + countMoves);
            // computing final heading
            //consider North position 0, East position 1, South position 2 and West position 3
            //for clockwise steering, spinVector > 0
       
            if (spinVector > 0)
            {
                if (spinVector % 4 == 0)
                {
                    heading = 'N';
                }
                else
                {
                    if (spinVector % 2 == 0)
                    {
                        heading = 'S';
                    }
                    else
                    {
                        if (spinVector % 3 == 0)
                        {
                            heading = 'W';
                        }
                        else
                        {
                            heading = 'E';
                        }
                    }
                }
            }

            //for anti-clockwise steering spinVector < 0, the statement for East and West will reverse

            if (spinVector < 0)
            {
                if (spinVector % 4 == 0)
                {
                    heading = 'N';
                }
                else
                {
                    if (spinVector % 2 == 0)
                    {
                        heading = 'S';
                    }
                    else
                    {
                        if (spinVector % 3 == 0)
                        {
                            heading = 'E';
                        }
                        else
                        {
                            heading = 'W';
                        }
                    }
                }
            }

            //feedback from heading:
            Console.WriteLine("Final heading is: " + heading);
            //return heading; must turn void in char- to do
            Console.ReadLine();
        }
//============================================================================
        //computing movement
        public void MovingRobot ()
        {
            if (rawMoveSequenceCapture[0] == 'M')
            {
                Console.WriteLine("Hot start!!");
            }
            for (int i = 0; i < rawMoveSequenceCapture.Length; i++)
            {
                switch (cardinal)
                {
                    case 'N':
                        Console.WriteLine("North");
                        break;
                    case 'S':
                        Console.WriteLine("South");
                        break;
                    case 'E':
                        break;

                }
            }
        }
        
        
        }


    }

