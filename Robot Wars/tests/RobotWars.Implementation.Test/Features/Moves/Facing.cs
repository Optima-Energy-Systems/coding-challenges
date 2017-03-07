using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Implementation.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Implementation.Test.Features.Moves
{
	[TestClass]
	public class Facing
	{
		[TestMethod]
		public void WhenPlacedFacingNorth_TheRobotIsFacingNorth()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(5, 6, 'N');

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand);

			Assert.AreEqual("N", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenPlacedFacingSouth_TheRobotIsFacingSouth()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(5, 6, 'S');

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand);

			Assert.AreEqual("S", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenPlacedFacingWest_TheRobotIsFacingWest()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(5, 6, 'W');

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand);

			Assert.AreEqual("W", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenPlacedFacingEast_TheRobotIsFacingEast()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(5, 6, 'E');

			var robot = new ArenaFactory()
				.Initialise(initialiseArenaCommand)
				.AddRobot(initialiseRobotCommand);

			Assert.AreEqual("E", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenPlacedWithAnUnknownFacing_AnExceptionIsThrown()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(5, 6, 'X');

			Assert.ThrowsException<RobotInitialisationException>(() =>
				new ArenaFactory()
					.Initialise(initialiseArenaCommand)
					.AddRobot(initialiseRobotCommand));
		}
	}
}