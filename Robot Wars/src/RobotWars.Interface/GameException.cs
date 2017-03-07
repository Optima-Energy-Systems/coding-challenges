using System;
using System.Runtime.Serialization;

namespace RobotWars.Interface
{
	[Serializable]
	public class GameException : Exception
	{
		public GameException()
		{
		}

		public GameException(string message) : base(message)
		{
		}

		public GameException(
			string message,
			Exception innerException) : base(message, innerException)
		{
		}

		public GameException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}
	}
}