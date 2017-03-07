using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Console.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Console.Test.Features.CommandReading
{
	[TestClass]
	public class Collisions
	{
		private readonly Func<IRobot, Task> _stubWriter = async _ => await Task.Yield();

		[TestMethod]
		public async Task WhenARobotWouldHitTheWall_NoExceptionIsThrown()
		{
			var input = new[] { "5 5", "0 0 S", "M" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
		}

		[TestMethod]
		public async Task WhenARobotWouldHitAnotherRobot_NoExceptionIsThrown()
		{
			var input = new[] { "5 5", "0 1 S", "L", "0 0 N", "M" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
		}

		[TestMethod]
		public async Task WhenARobotWouldHitAnotherRobot_ProcessingContinues()
		{
			var input = new[] { "5 5", "0 1 S", "L", "0 0 N", "M", "3 3 S", "L" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });

			Assert.AreEqual(input.Length, stubReader.LinesRead);
		}

	}
}
