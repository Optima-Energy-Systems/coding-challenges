using System;

namespace Supermarket.Domain
{
    public class InvalidPricingException : Exception
    {
        public InvalidPricingException(string message) : base(message)
		{
        }
    }
}