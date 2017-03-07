using RobotWars.Interface;

namespace RobotWars.Console.Commands
{
	internal struct InitialiseArenaCommand : IInitialiseArenaCommand
	{
		public InitialiseArenaCommand(IDimension maximumX, IDimension maximumY)
		{
			MaximumX = maximumX;
			MaximumY = maximumY;
		}

		public IDimension MaximumY { get; }
		public IDimension MaximumX { get; }
	}
}