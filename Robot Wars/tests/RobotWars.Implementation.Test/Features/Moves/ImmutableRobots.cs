using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotWars.Implementation.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Implementation.Test.Features.Moves
{
	[TestClass]
	public class ImmutableRobots
	{
		[TestMethod]
		public void WhenARobotIsMoved_TheOriginalIsDisposed()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(3, 2, 'N'));

			robot.Move(new MoveCommand());

			Assert.IsTrue(robot.IsDisposed);
		}

		[TestMethod]
		public void WhenADisposedRobotsXIsAccessed_AnExceptionIsThrown()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(3, 2, 'N'));
			robot.Move(new MoveCommand());

			Assert.ThrowsException<ObjectDisposedException>(() =>
			{
				var _ = robot.X;
			});
		}

		[TestMethod]
		public void WhenADisposedRobotsYIsAccessed_AnExceptionIsThrown()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(3, 2, 'N'));
			robot.Move(new MoveCommand());

			Assert.ThrowsException<ObjectDisposedException>(() =>
			{
				var _ = robot.Y;
			});
		}

		[TestMethod]
		public void WhenADisposedRobotsFacingIsAccessed_AnExceptionIsThrown()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(3, 2, 'N'));
			robot.Move(new MoveCommand());

			Assert.ThrowsException<ObjectDisposedException>(() =>
			{
				var _ = robot.Facing;
			});
		}

		[TestMethod]
		public void WhenADisposedRobotIsMoved_AnExceptionIsThrown()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(0, 0, 'N'));
			robot.Move(new MoveCommand());

			Assert.ThrowsException<ObjectDisposedException>(() =>
			{
				robot.Move(new MoveCommand());
			});
		}

		[TestMethod]
		public void WhenARobotIsTurned_TheOriginalIsDisposed()
		{
			var robot = new ArenaFactory()
				.Initialise(new InitialiseArenaCommand(3, 3))
				.AddRobot(new InitialiseRobotCommand(3, 2, 'N'));

			robot.Move(new TurnCommand(Mock.Of<IDirectionLeft>()));

			Assert.IsTrue(robot.IsDisposed);
		}
	}
}
