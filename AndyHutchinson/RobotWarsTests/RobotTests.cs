using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars;

namespace RobotWarsTests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void TestRotatingLeft()
        {
            Robot r = new Robot(1, 2, Direction.FindDirection(Direction.NORTH_ID), 3, 4);

            Assert.AreEqual("1 2 N", r.ToString());
            r.Move('L');
            Assert.AreEqual("1 2 W", r.ToString());
            r.Move('L');
            Assert.AreEqual("1 2 S", r.ToString());
            r.Move('L');
            Assert.AreEqual("1 2 E", r.ToString());
            r.Move('L');
            Assert.AreEqual("1 2 N", r.ToString());
        }

        [TestMethod]
        public void TestRotatingRight()
        {
            Robot r = new Robot(3, 4, Direction.FindDirection(Direction.SOUTH_ID), 5, 6);

            Assert.AreEqual("3 4 S", r.ToString());
            r.Move('R');
            Assert.AreEqual("3 4 W", r.ToString());
            r.Move('R');
            Assert.AreEqual("3 4 N", r.ToString());
            r.Move('R');
            Assert.AreEqual("3 4 E", r.ToString());
            r.Move('R');
            Assert.AreEqual("3 4 S", r.ToString());
        }

        [TestMethod]
        public void TestMoving()
        {
            Robot r = new Robot(7, 8, Direction.FindDirection(Direction.EAST_ID), 9, 10);

            Assert.AreEqual("7 8 E", r.ToString());
            r.Move('M');
            Assert.AreEqual("8 8 E", r.ToString());
            r.Move('R');
            r.Move('M');
            Assert.AreEqual("8 7 S", r.ToString());
            r.Move('R');
            r.Move('M');
            Assert.AreEqual("7 7 W", r.ToString());
            r.Move('R');
            r.Move('M');
            Assert.AreEqual("7 8 N", r.ToString());
            r.Move('L');
            r.Move('M');
            r.Move('M');
            Assert.AreEqual("5 8 W", r.ToString());
            r.Move('L');
            r.Move('L');
            r.Move('M');
            r.Move('M');
            r.Move('M');
            Assert.AreEqual("8 8 E", r.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(RobotWarsException))]
        public void TestMovingOutOfBounds()
        {
            Robot r = new Robot(1, 1, Direction.FindDirection(Direction.NORTH_ID), 2, 2);

            Assert.AreEqual("1 1 N", r.ToString());
            r.Move('M');
            Assert.AreEqual("1 2 N", r.ToString());
            r.Move('M'); // Out of bounds.
        }
    }
}
