using System;
using System.Runtime.Serialization;

namespace RobotWars.Interface
{
	[Serializable]
	public class RobotInitialisationException : GameException
	{
		public RobotInitialisationException()
		{
		}

		public RobotInitialisationException(string message) : base(message)
		{
		}

		public RobotInitialisationException(
			string message,
			Exception innerException) : base(message, innerException)
		{
		}

		public RobotInitialisationException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}
	}
}