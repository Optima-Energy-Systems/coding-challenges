using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ProgramInvalidArena()
        {
            new TestConsoleRapper(
                new[] { "0 0" },
                new[] { "Sorry your arena could not be created - 'Width need to be a number between 1 and 65535'" }
                ).RunTest();
        }

        [TestMethod]
        public void ProgramInvalidRobot()
        {
            new TestConsoleRapper(
                new[] { "5 5", "6 6 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" },
                new[] { "Sorry, robot 1 could not be created: X need to be a number between 0 and 5" }
                ).RunTest();
        }

        [TestMethod]
        public void ProgramRobotHitWall()
        {
            new TestConsoleRapper(
                new[] { "5 5", "1 2 N", "MMMMMMMMM", "3 3 E", "MMRMMRMRRM" },
                new[] { "Sorry, robot 1 could has had a problem: Robot has hit a wall" }
                ).RunTest();
        }

        [TestMethod]
        public void ProgramValidGame()
        {
            new TestConsoleRapper(
                new[] { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" },
                new[] { "1 3 N", "5 1 E" }
                ).RunTest();
        }

        private class TestConsoleRapper : ConsoleWrapper
        {
            private List<string> _expectedOuput;
            private Queue<string> _input;
            private List<string> _output;

            public TestConsoleRapper(string[] input, string[] expectedOuput)
            {
                _input = new Queue<string>(input);
                _output = new List<string>();
                _expectedOuput = new List<string>(expectedOuput);
                _expectedOuput.Add("Please any key to continue...");
            }

            public void RunTest()
            {
                Program.GameRun(this);
                CollectionAssert.AreEqual(_expectedOuput, _output);
            }

            public override void WriteLine(object value)
            {
                _output.Add(value.ToString());
            }

            public override void WriteLine(string format, object arg0)
            {
                _output.Add(string.Format(format, arg0));
            }

            public override void WriteLine(string format, object arg0, object arg1)
            {
                _output.Add(string.Format(format, arg0, arg1));
            }

            public override string ReadLine()
            {
                return _input.Dequeue();
            }

            public override ConsoleKeyInfo ReadKey()
            {
                return new ConsoleKeyInfo();
            }
        }
    }
}
