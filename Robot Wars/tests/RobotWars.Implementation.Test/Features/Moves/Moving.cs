using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotWars.Implementation.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Implementation.Test.Features.Moves
{
	[TestClass]
	public class Moving
	{
		[TestMethod]
		public void WhenARobotMovesNorth_ThePositionIsUpdated()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(3, 2, 'N'))
				.Move(new MoveCommand());

			Assert.AreEqual(3, robot.X.Value);
			Assert.AreEqual(3, robot.Y.Value);
			Assert.AreEqual("N", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenARobotMoves_TheNumberOfRobotsIsUnchanged()
		{
			var arena = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3));

			var robot = arena
				.AddRobot(new InitialiseRobotCommand(3, 2, 'N'))
				.Move(new MoveCommand());

			Assert.IsNotNull(robot);
			Assert.AreEqual(1, arena.Robots.Count);
		}

		[TestMethod]
		public void WhenARobotMovesSouth_ThePositionIsUpdated()
		{
			var moveCommand = new MoveCommand();

			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(0, 1, 'S'))
				.Move(moveCommand);

			Assert.AreEqual(0, robot.X.Value);
			Assert.AreEqual(0, robot.Y.Value);
			Assert.AreEqual("S", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenARobotMovesWest_ThePositionIsUpdated()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(1, 0, 'W'))
				.Move(new MoveCommand());

			Assert.AreEqual(0, robot.X.Value);
			Assert.AreEqual(0, robot.Y.Value);
			Assert.AreEqual("W", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenARobotMovesEast_ThePositionIsUpdated()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(2, 3, 'E'))
				.Move(new MoveCommand());

			Assert.AreEqual(3, robot.X.Value);
			Assert.AreEqual(3, robot.Y.Value);
			Assert.AreEqual("E", robot.Facing.ToString());
		}

		[TestMethod]
		public void WhenARobotTurnsThenMovesEast_ThePositionIsUpdated()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(5, 6))
				.AddRobot(new InitialiseRobotCommand(1, 1, 'N'))
				.Move(new TurnCommand(Mock.Of<IDirectionRight>()))
				.Move(new MoveCommand());

			Assert.AreEqual(2, robot.X.Value);
			Assert.AreEqual(1, robot.Y.Value);
			Assert.AreEqual("E", robot.Facing.ToString());
		}
	}
}
