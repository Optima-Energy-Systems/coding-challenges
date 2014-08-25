using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars;

namespace RobotWarsTests
{
    [TestClass]
    public class InputParserTests
    {
        [TestMethod]
        public void TestItReadsInputAndMovesRobot()
        {
            InputParser p = new InputParser();
            p.ParseGridSize("10 10");
            p.ParseInitialPosition("5 6 E");
            Robot r = p.CreateRobot();
            Assert.AreEqual("5 6 E", r.ToString());
            p.ParseMovesLine("RMLLLM", r);
            Assert.AreEqual("4 5 W", r.ToString());
        }
    }
}
