using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    /// <summary>
    /// Represents either north, east, south or west. Each direction
    /// knows its neighbours and knows how to move in its own direction.
    /// </summary>
    public class Direction
    {
        /** Letter identifying direction, either N/E/S/W. */
        private string id;

        /** Direction to the left of this direction */
        private string leftDirectionId;
        /** Direction to the right of this direction */
        private string rightDirectionId;

        /** X Movement in this direction */
        private int movementX;
        /** Y Movement in this direction */
        private int movementY;

        public const string NORTH_ID = "N";
        public const string EAST_ID  = "E";
        public const string SOUTH_ID = "S";
        public const string WEST_ID  = "W";

        private static Direction NORTH = new Direction(NORTH_ID, WEST_ID, EAST_ID, 0, 1);
        private static Direction EAST  = new Direction(EAST_ID, NORTH_ID, SOUTH_ID, 1, 0);
        private static Direction SOUTH = new Direction(SOUTH_ID, EAST_ID, WEST_ID, 0, -1);
        private static Direction WEST  = new Direction(WEST_ID, SOUTH_ID, NORTH_ID, -1, 0);

        private static Dictionary<string, Direction> directionsById = new Dictionary<string, Direction>
        {
            {NORTH.GetId(), NORTH},
            {EAST.GetId(),  EAST },
            {SOUTH.GetId(), SOUTH},
            {WEST.GetId(),  WEST }
        };

        /**
         * Private constructor as we only want to be able to
         * create the standard directions defined in this class.
         */
        private Direction(string id, string leftDirectionId, string rightDirectionId,
                          int movementX, int movementY)
        {
            this.id = id;
            this.leftDirectionId = leftDirectionId;
            this.rightDirectionId = rightDirectionId;
            this.movementX = movementX;
            this.movementY = movementY;
        }

        /** 
         * Returns either "N", "E", "S" or "W" depending 
         * on which direction this is. 
         */
        public string GetId() 
        {
            return id;
        }

        /** 
         * Returns the direction to the left of this direction, 
         * when facing in the direction of this direction, 
         * (i.e. the next direction anticlockwise from this one).
         */
        public Direction GetLeftDirection()
        {
            return FindDirection(leftDirectionId);
        }

        /**
         * Returns the direction to the right of this direction,
         * when facing in the direction of this direction,
         * (i.e. the next direction clockwise from this one).
         */
        public Direction GetRightDirection()
        {
            return FindDirection(rightDirectionId);
        }

        /**
         * Get the x delta for a movement in this direction.
         */
        public int GetMovementX()
        {
            return movementX;
        }

        /**
         * Get the y delta for a movement in this direction.
         */
        public int GetMovementY()
        {
            return movementY;
        }

        /**
         * For the demo output, just want a direction to be represented by
         * its 'id' letter.
         */
        public override string ToString()
        {
            return GetId();
        }

        /**
         * Find a direction corresponding to the passed letter (N/E/S/W).
         * Throw an exception if not recognized.
         */
        public static Direction FindDirection(string directionId)
        {
            try
            {
                return directionsById[directionId];
            }
            catch (KeyNotFoundException)
            {
                throw new RobotWarsException("Invalid direction: " + directionId);
            }
        }

    }
}
