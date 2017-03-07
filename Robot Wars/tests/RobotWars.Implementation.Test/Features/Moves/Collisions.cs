using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Implementation.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Implementation.Test.Features.Moves
{
	[TestClass]
	public class Collisions
	{
		[TestMethod]
		public void WhenTheRobotMovesSouthFromTheBottom_NoMovementOccurs()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(0, 0, 'S'));

			Assert.AreEqual(0, robot.X.Value);
			Assert.AreEqual(0, robot.Y.Value);
			Assert.AreEqual("S", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenTheRobotMovesNorthFromTheTop_NoMovementOccurs()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(3, 3, 'N'));

			Assert.AreEqual(3, robot.X.Value);
			Assert.AreEqual(3, robot.Y.Value);
			Assert.AreEqual("N", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenTheRobotMovesWestFromTheLeft_NoMovementOccurs()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(0, 0, 'W'));

			Assert.AreEqual(0, robot.X.Value);
			Assert.AreEqual(0, robot.Y.Value);
			Assert.AreEqual("W", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenTheRobotMovesEastFromTheRight_NoMovementOccurs()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(3, 3, 'E'));

			Assert.AreEqual(3, robot.X.Value);
			Assert.AreEqual(3, robot.Y.Value);
			Assert.AreEqual("E", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenTheRobotsWouldCollide_NoMovementOccurs()
		{
			var arena = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3));

			var firstRobot = arena
				.AddRobot(new InitialiseRobotCommand(0, 0, 'N'));
			var secondRobot = arena
				.AddRobot(new InitialiseRobotCommand(0, 1, 'N'));

			Assert.AreEqual(0, firstRobot.X.Value);
			Assert.AreEqual(0, firstRobot.Y.Value);
			Assert.AreEqual("N", firstRobot.Facing.ToString());
			Assert.AreEqual(0, secondRobot.X.Value);
			Assert.AreEqual(1, secondRobot.Y.Value);
			Assert.AreEqual("N", secondRobot.Facing.ToString());
		}
	}
}
