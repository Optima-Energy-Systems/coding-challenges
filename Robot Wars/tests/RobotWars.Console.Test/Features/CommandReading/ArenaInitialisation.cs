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
	public class ArenaInitialisation
	{
		private readonly Func<IRobot, Task> _stubWriter = async _ => await Task.Yield();

		[TestMethod]
		public async Task WhenTheFirstLineIsValid_TheArenaHasAMatchingMaxXandY()
		{
			var stubReader = new StubReader(new[] {"5 6"});
			var arena = await GameLoop.Start(
				stubReader.Read,
				_stubWriter,
				exception => { Assert.Fail("Unexpected exception", exception); });
			Assert.AreEqual(5, arena.MaximumX.Value);
			Assert.AreEqual(6, arena.MaximumY.Value);
		}

		[TestMethod]
		public async Task WhenTheFirstLineIsIncomplete_AnExceptionIsThrown()
		{
			var stubReader = new StubReader(new[] {"5 "});
			var exceptions = new List<Exception>();

			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(ParseException));
		}

		[TestMethod]
		public async Task WhenTheFirstMaximumIsLessThanZero_AnExceptionIsThrown()
		{
			var stubReader = new StubReader(new[] {"-3 5"});
			var exceptions = new List<Exception>();

			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(ParseException));
		}

		[TestMethod]
		public async Task WhenTheSecondMaximumIsLessThanTaskZero_AnExceptionIsThrown()
		{
			var stubReader = new StubReader(new[] {"5 -3"});
			var exceptions = new List<Exception>();

			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(ParseException));
		}

		[TestMethod]
		public async Task WhenTheFirstMaximumIsGreaterThanMaximumInteger_AnExceptionIsThrown()
		{
			var stubReader = new StubReader(new[] {"2147483648 5"});
			var exceptions = new List<Exception>();

			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(ParseException));
		}

		[TestMethod]
		public async Task WhenTheSecondMaximumIsGreaterThanMaximumInteger_AnExceptionIsThrown()
		{
			var stubReader = new StubReader(new[] {"5 2147483648"});
			var exceptions = new List<Exception>();

			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(ParseException));
		}

		[TestMethod]
		public async Task WhenTheInputIsNonNumeric_AnExceptionIsThrown()
		{
			var stubReader = new StubReader(new[] {"A B"});
			var exceptions = new List<Exception>();

			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(ParseException));
		}

		[TestMethod]
		public async Task WhenTheFirstLineIsEmpty_AnExceptionIsThrown()
		{
			var stubReader = new StubReader(new string[] {});
			var exceptions = new List<Exception>();

			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { exceptions.Add(exception); });

			Assert.AreEqual(1, exceptions.Count);
			Assert.IsInstanceOfType(exceptions[0], typeof(ParseException));
		}
	}
}
