using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotWars.Implementation.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Implementation.Test.Features.Moves
{
	[TestClass]
	public class Turning
	{
		[TestMethod]
		public void WhenARobotTurnsLeftThenRightFromNorth_TheRobotIsFacingNorth()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(0, 0, 'N');

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand)
				.Move(new TurnCommand(Mock.Of<IDirectionLeft>()))
				.Move(new TurnCommand(Mock.Of<IDirectionRight>()));

			Assert.AreEqual("N", robot.Facing.ToString());
		}
	}
}
