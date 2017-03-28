using System;

namespace RobotWars.Domain
{
    public class IllegalMoveException : Exception
    {
        public IllegalMoveException(string message) : base(message)
        {
        }
    }
}