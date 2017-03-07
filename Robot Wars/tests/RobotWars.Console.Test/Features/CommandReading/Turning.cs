using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Console.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Console.Test.Features.CommandReading
{
	[TestClass]
	public class Turning
	{
		private readonly Func<IRobot, Task> _stubWriter = async _ => await Task.Yield();

		[TestMethod]
		public async Task WhenARobotTurnsLeft_NoExceptionIsThrown()
		{
			var input = new[] { "5 5", "0 0 N", "L" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
		}

		[TestMethod]
		public async Task WhenARobotTurnsLeftFromNorth_TheRobotIsFacingWest()
		{
			var input = new[] { "5 5", "0 0 N", "L" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				async robot =>
				{
					Assert.AreEqual("W", robot.Facing.ToString());
					await Task.Yield();
				},
				exception => { Assert.Fail("Unexpected exception", exception); });
		}

		[TestMethod]
		public async Task WhenARobotTurnsRightFromNorth_TheRobotIsFacingEast()
		{
			var input = new[] { "5 5", "0 0 N", "R" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				async robot =>
				{
					Assert.AreEqual("E", robot.Facing.ToString());
					await Task.Yield();
				},
				exception => { Assert.Fail("Unexpected exception", exception); });
		}

		[TestMethod]
		public async Task WhenARobotTurnsLeftThenRight_NoExceptionIsThrown()
		{
			var input = new[] { "5 5", "0 0 N", "LR" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
		}

		[TestMethod]
		public async Task WhenARobotTurnsLeftTwiceFromNorth_TheRobotIsFacingSouth()
		{
			var input = new[] { "5 5", "0 0 N", "LL" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				async robot =>
				{
					Assert.AreEqual("S", robot.Facing.ToString());
					await Task.Yield();
				},
				exception => { Assert.Fail("Unexpected exception", exception); });
		}

		[TestMethod]
		public async Task WhenARobotTurnsRightThenLeft_NoExceptionIsThrown()
		{
			var input = new[] { "5 5", "0 0 N", "RL" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
		}
	}
}
