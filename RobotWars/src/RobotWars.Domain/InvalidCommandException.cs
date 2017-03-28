using System;

namespace RobotWars.Domain
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(string message) : base(message)
		{
        }
    }
}