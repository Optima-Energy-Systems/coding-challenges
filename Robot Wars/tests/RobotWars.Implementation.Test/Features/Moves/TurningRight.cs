using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotWars.Implementation.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Implementation.Test.Features.Moves
{
	[TestClass]
	public class TurningRight
	{
		[TestMethod]
		public void WhenARobotTurnsRightFromNorth_TheRobotIsFacingEast()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(0, 0, 'N');
			var turnCommand = new TurnCommand(Mock.Of<IDirectionRight>());

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand)
				.Move(turnCommand);

			Assert.AreEqual("E", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenARobotTurnsRightFromWest_TheRobotIsFacingNorth()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(0, 0, 'W');
			var turnCommand = new TurnCommand(Mock.Of<IDirectionRight>());

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand)
				.Move(turnCommand);

			Assert.AreEqual("N", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenARobotTurnsRightFromSouth_TheRobotIsFacingWest()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(0, 0, 'S');
			var turnCommand = new TurnCommand(Mock.Of<IDirectionRight>());

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand)
				.Move(turnCommand);

			Assert.AreEqual("W", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenARobotTurnsRightFromEast_TheRobotIsFacingSouth()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(0, 0, 'E');
			var turnCommand = new TurnCommand(Mock.Of<IDirectionRight>());

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand)
				.Move(turnCommand);

			Assert.AreEqual("S", robot.Facing.ToString());
		}
	}
}
