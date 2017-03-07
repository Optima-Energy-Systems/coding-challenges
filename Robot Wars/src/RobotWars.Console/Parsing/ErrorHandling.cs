using System;
using Sprache;

namespace RobotWars.Console.Parsing
{
	internal static class ErrorHandling
	{
		public static TNew TryCreate<TIn, TNew>(Func<TIn, TNew> factory, TIn input)
		{
			return TryCreate(() => factory(input));
		}

		public static TNew TryCreate<TNew>(Func<TNew> factory)
		{
			try
			{
				return factory();
			}
			catch (Exception exception) when (
				exception is ArgumentOutOfRangeException
				|| exception is OverflowException
			)
			{
				throw new ParseException("Input is out of the range of allowed values.", exception);
			}
		}
	}
}