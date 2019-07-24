using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Robot
    {
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
            Console.WriteLine("\n\n Now enter your beautiful name, my star: \n");
            string name = Console.ReadLine();
            Console.WriteLine("\n\n\nThis is not for heart fainted! Enter the sequence that will steer and move your \nbuddy Robot to the desired place inside the Arena.\nThink (or Ram??) well " +name+ " darling, or you may not get to move the tin again :D\n");
          
            Console.ReadLine();
        }
        public void SteerNMove()
        {
            string rawMoveSequenceCapture = Console.ReadLine();
            var rawSequence = rawMoveSequenceCapture.Split(' ');

        }
    }
}
