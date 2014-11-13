using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Robot
    {
        #region Fields
        
        private static readonly Regex _valueParseExpresion = new Regex("^(?<x>[0-9]+) (?<y>[0-9]+) (?<direction>[a-z])$", RegexOptions.IgnoreCase); // We are allowing a-z in the direction so we can give a helpful error message if invalid.

        private static NavigationCommand[] _navigationCommands = new[]
        {
            new NavigationCommand { Direction = Direction.N, OffsetY = 1 },
            new NavigationCommand { Direction = Direction.E, OffsetX = 1 },
            new NavigationCommand { Direction = Direction.S, OffsetY = -1 },
            new NavigationCommand { Direction = Direction.W, OffsetX = -1 }
        };

        #endregion

        #region Constructors

        public Robot(Arena arena, string start)
        {
            if (arena == null)
            {
                // If the arena is null we want to throw an error as it will be a coding error that will have cause this.
                throw new ArgumentNullException("arena");
            }

            if (!arena.IsValid)
            {
                // Again if the arena is invalid we want to throw an error.
                throw new ArgumentException("Arena is invalid", "arena");
            }

            Arena = arena;

            Match valueParseMatch = _valueParseExpresion.Match(start);

            if (!valueParseMatch.Success)
            {
                ErrorMessage = "The value is invalid";
                return;
            }

            ushort xParseResult;
            if (!ushort.TryParse(valueParseMatch.Groups["x"].Value, out xParseResult) || xParseResult > arena.Width)
            {
                ErrorMessage = string.Format("X need to be a number between 0 and {0}", arena.Width);
                return;
            }

            ushort yParseResult;
            if (!ushort.TryParse(valueParseMatch.Groups["y"].Value, out yParseResult) || yParseResult > arena.Height)
            {
                ErrorMessage = string.Format("Y need to be a number between 0 and {0}", arena.Height);
                return;
            }

            Direction directionParseResult;
            if (!Enum.TryParse(valueParseMatch.Groups["direction"].Value, out directionParseResult))
            {
                ErrorMessage = "Direction has to be N, E, S, or W";
                return;
            }

            Direction = directionParseResult;
            X = xParseResult;
            Y = yParseResult;
        }

        #endregion

        #region Properties

        public Arena Arena { get; private set; }

        public bool IsValid
        {
            get
            {
                return ErrorMessage == null;
            }
        }

        public string ErrorMessage { get; private set; }

        #endregion

        #region Method

        public bool Navagate(string commands)
        {
            ErrorMessage = null;

            foreach (char c in commands)
            {
                if (!NavagateStep(c))
                {
                    return false;
                }
            }

            return true;
        }

        private bool NavagateStep(char commandText)
        {
            Command command;
            if (!Enum.TryParse(commandText.ToString(), out command))
            {
                ErrorMessage = string.Format("The command '{0}' cannot be understood", commandText);
                return false;
            }

            switch (command)
            {
                case Command.R:
                    Direction = Direction == Direction.W ? Direction.N : Direction + 1;
                    break;

                case Command.L:
                    Direction = Direction == Direction.N ? Direction.W : Direction - 1;
                    break;

                case Command.M:
                    NavigationCommand navigationCommand = _navigationCommands.Single(x => x.Direction == Direction);
                    ushort newX = (ushort)(X + navigationCommand.OffsetX);
                    ushort newY = (ushort)(Y + navigationCommand.OffsetY);

                    if (!Arena.InsidePlayingArea(newX, newY))
                    {
                        ErrorMessage = "Robot has hit a wall";
                        return false;
                    }

                    X = newX;
                    Y = newY;
                    break;
            }

            return true;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", X, Y, Direction);
        }

        public Direction Direction { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        #endregion

        #region Private Classes and Enums

        private enum Command
        {
            L,
            M,
            R
        }

        public enum Navigation
        {
            L,
            R,
            M
        }

        private class NavigationCommand
        {
            public Direction Direction { get; set; }

            public int OffsetY { get; set; }

            public int OffsetX { get; set; }
        }

        #endregion
    }
}
