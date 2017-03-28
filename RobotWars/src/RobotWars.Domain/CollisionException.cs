using System;

namespace RobotWars.Domain
{
    public class CollisionException : Exception
    {
        public CollisionException(string message) : base(message)
        {
        }
    }
}