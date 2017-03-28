using System;
using RobotWars.Interfaces;

namespace RobotWars.Domain
{
    public class Robot : IRobot
    {
        public int PositionX { get; private set; }

        public int PositionY { get; }
        public IOrientation Orientation { get; private set; }

        public Robot(int positionX, int positionY, IOrientation orientation)
        {
            if (positionX < 0)
                throw new ArgumentOutOfRangeException(nameof(positionX), "Must be greater than or equal to zero");
            if (positionY < 0)
                throw new ArgumentOutOfRangeException(nameof(positionY), "Must be greater than or equal to zero");

            PositionX = positionX;
            PositionY = positionY;
            Orientation = orientation;
        }

        public IRobot Move()
        {
            switch (Orientation.ToString().ToUpper())
            {
                case "N":
                    return new Robot(PositionX, PositionY + 1, Orientation);
                case "E":
                    return new Robot(PositionX + 1, PositionY, Orientation);
                case "S":
                    return new Robot(PositionX, PositionY - 1, Orientation);
                case "W":
                    return new Robot(PositionX - 1, PositionY, Orientation);
                default:
                    throw new IllegalMoveException($"Invalid orientation value: {Orientation}");
            }
        }

        public IRobot Turn(IRobotTurnCommand command)
        {
            if (command.TurnDirection == Direction.Left)
                return new Robot(PositionX, PositionY, Orientation.TurnLeft());

            if (command.TurnDirection == Direction.Right)
                return new Robot(PositionX, PositionY, Orientation.TurnRight());

            return this;
        }

        public override string ToString()
        {
            return $"{PositionX} {PositionY} {Orientation}";
        }
    }
}
