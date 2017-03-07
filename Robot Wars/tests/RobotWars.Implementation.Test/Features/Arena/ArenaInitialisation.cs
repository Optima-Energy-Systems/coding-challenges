using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotWars.Implementation.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Implementation.Test.Features.Arena
{
    [TestClass]
    public class ArenaInitialisation
    {
		[TestMethod]
		public void WhenTheFirstMaximumIsZero_AnExceptionIsThrown()
		{
			var command = new InitialiseArenaCommand(0, 5);
			Assert.ThrowsException<ArenaInitialisationException>(() => new ArenaFactory().Initialise(command));
		}

		[TestMethod]
		public void WhenTheFirstMaximumIsLessThanZero_AnExceptionIsThrown()
		{
			var command = new InitialiseArenaCommand(-3, 5);
			Assert.ThrowsException<ArenaInitialisationException>(() => new ArenaFactory().Initialise(command));
		}

		[TestMethod]
		public void WhenTheSecondMaximumIsZero_AnExceptionIsThrown()
		{
			var command = new InitialiseArenaCommand(5, 0);
			Assert.ThrowsException<ArenaInitialisationException>(() => new ArenaFactory().Initialise(command));
		}

		[TestMethod]
		public void WhenTheSecondMaximumIsLessThanTaskZero_AnExceptionIsThrown()
		{
			var command = new InitialiseArenaCommand(5, -3);
			Assert.ThrowsException<ArenaInitialisationException>(() => new ArenaFactory().Initialise(command));
		}
	}
}
