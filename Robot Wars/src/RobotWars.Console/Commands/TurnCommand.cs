using RobotWars.Interface;

namespace RobotWars.Console.Commands
{
	internal class TurnCommand : ITurnCommand
	{
		public static readonly TurnCommand TurnLeft = new TurnCommand(Commands.Direction.Left);
		public static readonly TurnCommand TurnRight = new TurnCommand(Commands.Direction.Right);

		public TurnCommand(IDirection direction)
		{
			Direction = direction;
		}

		public IDirection Direction { get; }
	}
}
