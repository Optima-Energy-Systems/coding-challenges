using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class RobotWarsException : Exception
    {
        public RobotWarsException() : base() { }

        public RobotWarsException(string message) : base(message) { }
    }

}
