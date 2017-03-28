using System;
using RobotWars.Interfaces;

namespace RobotWars.Domain
{
    public class Direction : IDirection
    {
        public static readonly Direction Left = new Direction('L');
        public static readonly Direction Right = new Direction('R');

        private char _direction { get; }

        public Direction(char direction)
        {
            switch (direction)
            {
                case 'L':
                case 'R':
                    _direction = direction; break;
                default:
                    throw new ArgumentException($"Invalid direction parameter: {direction}", nameof(direction));
            }
        }
    }
}