using RobotWars.Interface;

namespace RobotWars.Console.Commands
{
	internal static class Direction
	{
		public static readonly IDirectionLeft Left = new DirectionLeft();
		public static readonly IDirectionRight Right = new DirectionRight();

		private class DirectionRight : IDirectionRight
		{
		}

		private class DirectionLeft : IDirectionLeft
		{
		}
	}
}