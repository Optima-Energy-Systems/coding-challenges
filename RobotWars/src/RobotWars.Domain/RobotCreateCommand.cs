using System;
using RobotWars.Interfaces;

namespace RobotWars.Domain
{
    public class RobotCreateCommand : IRobotCreateCommand
    {
        public int PositionX { get; }

        public int PositionY { get; }
        public IOrientation Orientation { get; }

        public RobotCreateCommand(int positionX, int positionY, IOrientation orientation)
        {
            if (positionX < 0)
                throw new ArgumentOutOfRangeException(nameof(positionX), "Must be greater than or equal to zero");
            if (positionY < 0)
                throw new ArgumentOutOfRangeException(nameof(positionY), "Must be greater than or equal to zero");

            PositionX = positionX;
            PositionY = positionY;
            Orientation = orientation;
        }
    }
}