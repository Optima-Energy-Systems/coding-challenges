using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class SupermarketException : Exception
    {
        public SupermarketException() : base() { }

        public SupermarketException(string message) : base(message) { }
    }
}
