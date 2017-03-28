using System;
using RobotWars.Interfaces;

namespace RobotWars.Domain
{
    public class Orientation : IOrientation
    {
        public static readonly Orientation North = new Orientation('N');
        public static readonly Orientation East = new Orientation('E');
        public static readonly Orientation South = new Orientation('S');
        public static readonly Orientation West = new Orientation('W');

        private char _orientation { get; }

        public Orientation(char orientation)
        {
            switch (orientation)
            {
                case 'N':
                case 'E':
                case 'S':
                case 'W':
                    _orientation = orientation; break;
                default:
                    throw new ArgumentException($"Invalid orientation parameter: {orientation}", nameof(orientation));
            }
        }

        public IOrientation TurnLeft()
        {
            switch (_orientation)
            {
                case 'N':
                    return Orientation.West;
                case 'E':
                    return Orientation.North;
                case 'S':
                    return Orientation.East;
                case 'W':
                    return Orientation.South;
                default:
                    throw new ArgumentException($"Invalid orientation: {_orientation}", nameof(_orientation));
            }
        }

        public IOrientation TurnRight()
        {
            switch (_orientation)
            {
                case 'N':
                    return Orientation.East;
                case 'E':
                    return Orientation.South;
                case 'S':
                    return Orientation.West;
                case 'W':
                    return Orientation.North;
                default:
                    throw new ArgumentException($"Invalid orientation: {_orientation}", nameof(_orientation));
            }
        }

        public override string ToString()
        {
            return _orientation.ToString();
        }
    }
}