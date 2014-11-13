using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotWars.Test
{
    [TestClass]
    public class RobotTest
    {
        private Arena _arena;

        [TestInitialize]
        public void Initialize()
        {
            _arena = new Arena("5 5");
            Assert.IsTrue(_arena.IsValid, _arena.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RobotArenaNull()
        {
            new Robot(null, "5 5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RobotArenaInvalid()
        {
            new Robot(new Arena("0 0"), "5 5");
        }

        [TestMethod]
        public void RobotNoneNumeric()
        {
            var robot = new Robot(_arena, "A B N");
            Assert.IsFalse(robot.IsValid);
            Assert.AreEqual(robot.ErrorMessage, "The value is invalid");
        }

        [TestMethod]
        public void RobotXToLarge()
        {
            var robot = new Robot(_arena, "6 0 N");
            Assert.IsFalse(robot.IsValid);
            Assert.AreEqual(robot.ErrorMessage, "X need to be a number between 0 and 5");
        }

        [TestMethod]
        public void RobotYToLarge()
        {
            var robot = new Robot(_arena, "0 6 N");
            Assert.IsFalse(robot.IsValid);
            Assert.AreEqual(robot.ErrorMessage, "Y need to be a number between 0 and 5");
        }

        [TestMethod]
        public void RobotInvalidDirection()
        {
            var robot = new Robot(_arena, "0 0 A");
            Assert.IsFalse(robot.IsValid);
            Assert.AreEqual(robot.ErrorMessage, "Direction has to be N, E, S, or W");
        }

        [TestMethod]
        public void RobotFullCommand1()
        {
            var robot = new Robot(_arena, "1 2 N");

            if (!robot.Navagate("LMLMLMLMM"))
            {
                Assert.Fail(robot.ErrorMessage);
            }

            string result = robot.ToString();

            Assert.AreEqual(result, "1 3 N");
        }

        [TestMethod]
        public void RobotFullCommand2()
        {
            var robot = new Robot(_arena, "3 3 E");

            if (!robot.Navagate("MMRMMRMRRM"))
            {
                Assert.Fail(robot.ErrorMessage);
            }

            string result = robot.ToString();

            Assert.AreEqual(result, "5 1 E");
        }


        [TestMethod]
        public void RobotHitWall()
        {
            RobotHitWallHelper("4 4 N", "MM");
            RobotHitWallHelper("4 4 E", "MM");
            RobotHitWallHelper("1 1 S", "MM");
            RobotHitWallHelper("1 1 W", "MM");
        }

        private void RobotHitWallHelper(string start, string command)
        {
            Robot robot = new Robot(_arena, start);

            if (robot.Navagate(command))
            {
                Assert.Fail("Robot didn't hit wall");
            }

            Assert.AreEqual(robot.ErrorMessage, "Robot has hit a wall", "The command '{0}' from '{1}' didn't hit the wall", command, start);
        }
    }
}
