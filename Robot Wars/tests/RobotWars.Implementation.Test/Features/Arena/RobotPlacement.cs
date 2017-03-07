using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotWars.Implementation.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Implementation.Test.Features.Arena
{
	[TestClass]
	public class RobotPlacement
	{
		[TestMethod]
		public void ANewArena_HasNoRobots()
		{
			var command = new InitialiseArenaCommand(5, 6);

			IArena actual = new ArenaFactory().Initialise(command);

			Assert.AreEqual(0, actual.Robots.Count);
		}

		[TestMethod]
		public void WhenPlacedAtTheOrigin_TheRobotIsPlacedCorrectly()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(0, 0);

			var arena = new ArenaFactory().Initialise(initialiseArenaCommand);
			arena.AddRobot(initialiseRobotCommand);

			Assert.AreEqual(1, arena.Robots.Count);
			Assert.AreEqual(0, arena.Robots.First().X.Value);
			Assert.AreEqual(0, arena.Robots.First().Y.Value);
			Assert.AreEqual(initialiseRobotCommand.Facing.ToString(), arena.Robots.First().Facing.ToString());
		}

		[TestMethod]
		public void WhenPlacedAtTheMaximumCoordinates_TheRobotIsPlacedCorrectly()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(5, 6);

			var arena = new ArenaFactory().Initialise(initialiseArenaCommand);
			arena.AddRobot(initialiseRobotCommand);

			Assert.AreEqual(1, arena.Robots.Count);
			Assert.AreEqual(5, arena.Robots.First().X.Value);
			Assert.AreEqual(6, arena.Robots.First().Y.Value);
			Assert.AreEqual(initialiseRobotCommand.Facing.ToString(), arena.Robots.First().Facing.ToString());
		}

		[TestMethod]
		public void WhenPlacedBelowOriginX_AnExceptionIsThrown()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(-5, 6);

			Assert.ThrowsException<RobotInitialisationException>(() => 
				new ArenaFactory()
					.Initialise(initialiseArenaCommand)
					.AddRobot(initialiseRobotCommand));
		}

		[TestMethod]
		public void WhenPlacedBelowOriginY_AnExceptionIsThrown()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(5, -6);

			Assert.ThrowsException<RobotInitialisationException>(() => 
				new ArenaFactory()
					.Initialise(initialiseArenaCommand)
					.AddRobot(initialiseRobotCommand));
		}

		[TestMethod]
		public void WhenPlacedAboveMaximumX_AnExceptionIsThrown()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(6, 6);

			Assert.ThrowsException<RobotInitialisationException>(() =>
				new ArenaFactory()
					.Initialise(initialiseArenaCommand)
					.AddRobot(initialiseRobotCommand));
		}

		[TestMethod]
		public void WhenPlacedAboveMaximumY_AnExceptionIsThrown()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);
			var initialiseRobotCommand = new InitialiseRobotCommand(5, 7);

			Assert.ThrowsException<RobotInitialisationException>(() =>
				new ArenaFactory()
					.Initialise(initialiseArenaCommand)
					.AddRobot(initialiseRobotCommand));
		}

		[TestMethod]
		public void WhenTwoRobotsArePlaced_BothArePlacedCorrectly()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);

			var firstInitialiseRobotCommand = new InitialiseRobotCommand(3, 3);
			var secondInitialiseRobotCommand = new InitialiseRobotCommand(5, 5);

			var arena = new ArenaFactory().Initialise(initialiseArenaCommand);
			arena.AddRobot(firstInitialiseRobotCommand);
			arena.AddRobot(secondInitialiseRobotCommand);

			Assert.AreEqual(2, arena.Robots.Count);
			Assert.AreEqual(3, arena.Robots.First().X.Value);
			Assert.AreEqual(3, arena.Robots.First().Y.Value);
			Assert.AreEqual(5, arena.Robots.Skip(1).First().X.Value);
			Assert.AreEqual(5, arena.Robots.Skip(1).First().Y.Value);
		}

		[TestMethod]
		public void WhenTwoRobotsArePlacedOnTopOfEachOther_TheFirstRobotIsPlaced()
		{
			var initialiseArenaCommand = new InitialiseArenaCommand(5, 6);

			var firstInitialiseRobotCommand = new InitialiseRobotCommand(3, 2);
			var secondInitialiseRobotCommand = new InitialiseRobotCommand(3, 2);

			var arena = new ArenaFactory().Initialise(initialiseArenaCommand);
			arena.AddRobot(firstInitialiseRobotCommand);
			Assert.ThrowsException<RobotInitialisationException>(() => arena.AddRobot(secondInitialiseRobotCommand));

			Assert.AreEqual(1, arena.Robots.Count);
			Assert.AreEqual(3, arena.Robots.First().X.Value);
			Assert.AreEqual(2, arena.Robots.First().Y.Value);
		}
	}
}
