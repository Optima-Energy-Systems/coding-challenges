using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Console.Test.TestDoubles;
using RobotWars.Interface;
using Sprache;

namespace RobotWars.Console.Test.Features.CommandReading
{
	[TestClass]
	public class RobotPlacement
	{
		private readonly Func<IRobot, Task> _stubWriter = async _ => await Task.Yield();

		[TestMethod]
		public async Task WhenTheFacingIsMissing_AnExceptionIsThrown()
		{
			var stubReader = new StubReader(new[] { "5 5", "0 0" });
			var exceptions = new List<Exception>();
			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(ParseException));
		}

		[TestMethod]
		public async Task WhenACoordinateIsMissing_AnExceptionIsThrown()
		{
			var stubReader = new StubReader(new[] { "5 5", "0 " });
			var exceptions = new List<Exception>();
			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(ParseException));
		}

		[TestMethod]
		public async Task WhenARobotIsPlacedAtANegativeX_AnExceptionIsThrown()
		{
			var stubReader = new StubReader(new[] { "5 5", "-3 0 N" });
			var exceptions = new List<Exception>();
			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(ParseException));
		}

		[TestMethod]
		public async Task WhenARobotIsPlacedAtANegativeY_AnExceptionIsThrown()
		{
			var stubReader = new StubReader(new[] { "5 5", "0 -3 N" });
			var exceptions = new List<Exception>();
			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(ParseException));
		}

		[TestMethod]
		public async Task WhenTwoRobotsArePlaced_BothPositionsAreOutput()
		{
			var input = new[] { "5 5", "0 0 N", "LR", "5 5 S", "LR" };
			var stubReader = new StubReader(input);
			var robots = new List<IRobot>();
			Func<IRobot, Task> stubWriter = async r =>
			{
				robots.Add(r);
				await Task.Yield();
			};

			await GameLoop.Start(
				stubReader.Read,
				stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });

			Assert.AreEqual(2, robots.Count);
			Assert.AreEqual(0, robots[0].X.Value);
			Assert.AreEqual(0, robots[0].X.Value);
			Assert.AreEqual("N", robots[0].Facing.ToString());
			Assert.AreEqual(5, robots[1].X.Value);
			Assert.AreEqual(5, robots[1].X.Value);
			Assert.AreEqual("S", robots[1].Facing.ToString());
		}

		[TestMethod]
		public async Task WhenOneRobotIsMisplaced_OnePositionIsOutput()
		{
			var input = new[] { "5 5", "6 6 N", "LR", "5 5 S", "LR" };
			var stubReader = new StubReader(input);
			var robots = new List<IRobot>();
			Func<IRobot, Task> stubWriter = async r =>
			{
				robots.Add(r);
				await Task.Yield();
			};

			await GameLoop.Start(
				stubReader.Read,
				stubWriter,
				exception => { });

			Assert.AreEqual(1, robots.Count);
			Assert.AreEqual(5, robots[0].X.Value);
			Assert.AreEqual(5, robots[0].X.Value);
			Assert.AreEqual("S", robots[0].Facing.ToString());
		}

		[TestMethod]
		public async Task WhenOneRobotIsMisplaced_OneErrorIsOutput()
		{
			var input = new[] { "5 5", "6 6 N", "5 5 S" };
			var stubReader = new StubReader(input);
			var exceptions = new List<Exception>();

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(RobotInitialisationException));
		}

		[TestMethod]
		public async Task AnEmptyLineAfterARobot_TerminatesTheOutputWithoutException()
		{
			var input = new[] { "5 5", "0 0 N", string.Empty };
			var stubReader = new StubReader(input);

			await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
		}
	}
}
