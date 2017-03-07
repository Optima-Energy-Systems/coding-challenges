using RobotWars.Interface;

namespace RobotWars.Implementation.Test.TestDoubles
{
	internal class TurnCommand : ITurnCommand
	{
		public TurnCommand(IDirection d)
		{
			Direction = d;
		}

		public IDirection Direction { get; }
	}
}