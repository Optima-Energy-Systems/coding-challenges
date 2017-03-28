using System;
using RobotWars.Interfaces;

namespace RobotWars.Domain
{
    public class RobotTurnCommand : IRobotTurnCommand
    {
        public IDirection TurnDirection { get; }

        public RobotTurnCommand(char direction)
        {
            switch (direction)
            {
                case 'L':
                    TurnDirection = Direction.Left; break;
                case 'R':
                    TurnDirection = Direction.Right; break;
                default:
                    throw new ArgumentException($"Invalid direction: {direction}", nameof(direction));
            }
        }
    }
}