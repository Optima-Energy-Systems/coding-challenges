using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    /**
     * A robot has a x/y position and a direction and can be
     * told to move (either L/R rotations or M - forwards).
     */ 
    public class Robot
    {
        /** Current x position */
        private int x;
        /** Current y position */
        private int y;
        /** Current direction */
        private Direction direction;

        /** x limit */
        private int limitX;
        /** y limit */
        private int limitY;

        /**
         * Create a robot with an initial x, y position and direction.
         * Also specify it's movement limits.
         */
        public Robot(int x, int y, Direction direction, int limitX, int limitY)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;

            this.limitX = limitX;
            this.limitY = limitY;
        }

        /**
         * Perform a single movement as indicated by the argument
         */
        public void Move(char move)
        {
            switch(move)
            {
                case 'L':
                    direction = direction.GetLeftDirection();
                    break;

                case 'R':
                    direction = direction.GetRightDirection();
                    break;

                case 'M':
                    x += direction.GetMovementX();
                    y += direction.GetMovementY();
                    CheckBounds();
                    break;

                default: 
                    throw new RobotWarsException("Bad move: " + move);
            }
        }

        private void CheckBounds()
        {
            if (x < 0 || x > limitX ||
                y < 0 || y > limitY)
            {
                throw new RobotWarsException("Out of bounds");
            }
        }

        /**
         * Report our position
         */
        public override string ToString()
        {
            return x + " " + y + " " + direction;
        }
    }
}
