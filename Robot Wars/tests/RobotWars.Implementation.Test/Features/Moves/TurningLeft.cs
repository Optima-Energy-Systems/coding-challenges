using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotWars.Implementation.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Implementation.Test.Features.Moves
{
	[TestClass]
	public class TurningLeft
	{
		[TestMethod]
		public void WhenARobotTurnsLeftFromNorth_TheRobotIsFacingWest()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(0, 0, 'N');
			var turnCommand = new TurnCommand(Mock.Of<IDirectionLeft>());

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand)
				.Move(turnCommand);

			Assert.AreEqual("W", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenARobotTurnsLeftFromWest_TheRobotIsFacingSouth()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(0, 0, 'W');
			var turnCommand = new TurnCommand(Mock.Of<IDirectionLeft>());

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand)
				.Move(turnCommand);

			Assert.AreEqual("S", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenARobotTurnsLeftFromSouth_TheRobotIsFacingEast()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(0, 0, 'S');
			var turnCommand = new TurnCommand(Mock.Of<IDirectionLeft>());

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand)
				.Move(turnCommand);

			Assert.AreEqual("E", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenARobotTurnsLeftFromEast_TheRobotIsFacingNorth()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(0, 0, 'E');
			var turnCommand = new TurnCommand(Mock.Of<IDirectionLeft>());

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand)
				.Move(turnCommand);

			Assert.AreEqual("N", robot.Facing.ToString());
		}
	}
}
