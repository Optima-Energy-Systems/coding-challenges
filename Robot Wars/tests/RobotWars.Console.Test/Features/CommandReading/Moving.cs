using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Console.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Console.Test.Features.CommandReading
{
	[TestClass]
	public class Moving
	{
		private readonly Func<IRobot, Task> _stubWriter = async _ => await Task.Yield();

		[TestMethod]
		public async Task WhenARobotMoves_NoExceptionIsThrown()
		{
			var input = new[] { "5 5", "0 0 N", "M" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
		}

		[TestMethod]
		public async Task WhenARobotMovesTwice_NoExceptionIsThrown()
		{
			var input = new[] { "5 5", "0 0 N", "MM" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
		}

		[TestMethod]
		public async Task WhenARobotTurnsThenMoves_NoExceptionIsThrown()
		{
			var input = new[] { "5 5", "0 0 N", "RM" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
		}

		[TestMethod]
		public async Task WhenARobotMovesThenTurns_NoExceptionIsThrown()
		{
			var input = new[] { "5 5", "0 0 N", "MR" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
		}

		[TestMethod]
		public async Task WhenARobotMovesThenTurnsTheMoves_NoExceptionIsThrown()
		{
			var input = new[] { "5 5", "0 0 N", "MRM" };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
		}
	}
}
