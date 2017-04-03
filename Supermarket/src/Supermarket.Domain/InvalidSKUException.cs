using System;

namespace Supermarket.Domain
{
    public class InvalidSkuException : Exception
    {
        public InvalidSkuException(string message) : base(message)
		{
        }
    }
}