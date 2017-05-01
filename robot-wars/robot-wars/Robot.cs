using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public enum RobotDirections { North, South, East, West }
    enum RobotMove { SpinLeft, SpinRight, Forward }

    public class Robot
    {
        private int x;
        private int y;
        private RobotDirections direction;
        private int arenaHeight;
        private int arenaWidth;

        public int X
        {
            get
            {
                return this.x;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
        }

        public RobotDirections Direction
        {
            get
            {
                return this.direction;
            }
        }

        public Robot(int arenaHeight, int arenaWidth, int startX, int startY, string direction)
        {
            if (arenaHeight < 1 || arenaWidth < 1)
            {
                throw new Exception("Arena size out of bounds");
            }

            if (startX < 1 || startX > arenaWidth || startY < 1 || startY > arenaHeight)
            {
                throw new Exception("Robot placed out of bounds");
            }

            x = startX;
            y = startY;
            this.arenaHeight = arenaHeight;
            this.arenaWidth = arenaWidth;
            this.direction = this.GetDirection(direction);
        }

        public void Move(string moves)
        {
            List<RobotMove> moveList = Moves(moves);
            foreach (var move in moveList)
            {
                Move(move);
            }
        }

        private void Move(RobotMove move)
        {
            switch (move)
            {
                case RobotMove.Forward: MoveForward(); break;
                case RobotMove.SpinLeft: SpinLeft(); break;
                case RobotMove.SpinRight: SpinRight(); break;
            }
        }

        private void MoveForward()
        {
            switch (direction)
            {
                case RobotDirections.North:
                    if (y + 1 > arenaHeight)
                    {
                        throw new Exception("Moved off grid");
                    }
                    else
                    {
                        y++;
                    }
                    break;
                case RobotDirections.South:
                    if (y - 1 < 0)
                    {
                        throw new Exception("Moved off grid");
                    }
                    else
                    {
                        y--;
                    }
                    break;
                case RobotDirections.West:
                    if (x - 1 < 0)
                    {
                        throw new Exception("Moved off grid");
                    }
                    else
                    {
                        x--;
                    }
                    break;
                case RobotDirections.East:
                    if (x + 1 > arenaWidth)
                    {
                        throw new Exception("Moved off grid");
                    }
                    else
                    {
                        x++;
                    }
                    break;
            }
        }
    

        private void SpinLeft()
        {
            switch (direction)
            {
                case RobotDirections.North: direction = RobotDirections.West; break;
                case RobotDirections.South: direction = RobotDirections.East; break;
                case RobotDirections.West: direction = RobotDirections.South; break;
                case RobotDirections.East: direction = RobotDirections.North; break;
            }
        }

        private void SpinRight()
        {
            switch (direction)
            {
                case RobotDirections.North: direction = RobotDirections.East; break;
                case RobotDirections.South: direction = RobotDirections.West; break;
                case RobotDirections.West: direction = RobotDirections.North; break;
                case RobotDirections.East: direction = RobotDirections.South; break;
            }
        }

        private RobotDirections GetDirection(string direction)
        {
            if (direction.Length<1 || direction.Length>1)
            {
                throw new Exception("Invalid robot direction");
            }
            switch (direction[0])
            {
                case 'N': return RobotDirections.North;
                case 'S': return RobotDirections.South;
                case 'E': return RobotDirections.East;
                case 'W': return RobotDirections.West;
            }
            throw new Exception("Unknown robot direction");
        }

        private List<RobotMove> Moves(string moves)
        {
            if (moves.Length < 1)
            {
                throw new Exception("Invalid number of moves");
            }

            List<RobotMove> moveList = new List<RobotMove>();

            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'L': moveList.Add(RobotMove.SpinLeft); break;
                    case 'R': moveList.Add(RobotMove.SpinRight); break;
                    case 'M': moveList.Add(RobotMove.Forward); break;
                    default:  throw new Exception("Unknown robot move : '" + move + "'");
                }
            }

            return moveList;
        }

    }
}
