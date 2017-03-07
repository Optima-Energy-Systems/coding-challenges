using RobotWars.Interface;

namespace RobotWars.Console.Commands
{
	internal class InitialiseRobotCommand : IInitialiseRobotCommand
	{
		public InitialiseRobotCommand(ICoordinate x,
			ICoordinate y,
			IFacing facing)
		{
			X = x;
			Y = y;
			Facing = facing;
		}

		public ICoordinate X { get; }
		public ICoordinate Y { get; }
		public IFacing Facing { get; }
	}
}
