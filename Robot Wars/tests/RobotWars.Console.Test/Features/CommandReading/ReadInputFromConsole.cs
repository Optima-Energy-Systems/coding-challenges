using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Console.Test.TestDoubles;
using RobotWars.Interface;

namespace RobotWars.Console.Test.Features.CommandReading
{
    [TestClass]
    public class ReadInputFromConsole
    {
		private readonly Func<IRobot, Task> _stubWriter = async _ => await Task.Yield();
		[TestMethod]
        public async Task WhenThereIsInput_TheStringIsRead()
        {
	        var input = new []{"5 5"};
	        var stubReader = new StubReader(input);
	        await GameLoop.Start(stubReader.Read, _stubWriter, exception => { Assert.Fail(exception.Message, exception); });
            Assert.AreEqual(1, stubReader.LinesRead);
        }

        [TestMethod]
        public async Task WhenThereAreTwoLinesOfInput_BothStringsAreRead()
        {
			var input = new[] { "5 5", "0 0 N" };
			var stubReader = new StubReader(input);
			await GameLoop.Start(stubReader.Read, _stubWriter, exception => { Assert.Fail(exception.Message, exception); });
			Assert.AreEqual(2, stubReader.LinesRead);
		}
    }
}
