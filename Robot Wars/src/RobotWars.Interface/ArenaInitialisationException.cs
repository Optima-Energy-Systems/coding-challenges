using System;
using System.Runtime.Serialization;

namespace RobotWars.Interface
{
	[Serializable]
	public class ArenaInitialisationException : GameException
	{
		public ArenaInitialisationException()
		{
		}

		public ArenaInitialisationException(string message) : base(message)
		{
		}

		public ArenaInitialisationException(
			string message,
			Exception innerException) : base(message, innerException)
		{
		}

		public ArenaInitialisationException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}
	}
}