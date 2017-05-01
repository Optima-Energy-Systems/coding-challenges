using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars;

namespace RobotWarsUnitTests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void TestRobotCreate()
        {
            var robot1 = new Robot(5, 6, 2, 3, "N");
            Assert.AreEqual(robot1.X, 2);
            Assert.AreEqual(robot1.Y, 3);
            Assert.AreEqual(robot1.Direction, RobotDirections.North);

            var robot2 = new Robot(5, 6, 2, 3, "S");
            Assert.AreEqual(robot2.Direction, RobotDirections.South);
            var robot3 = new Robot(5, 6, 2, 3, "W");
            Assert.AreEqual(robot3.Direction, RobotDirections.West);
            var robot4 = new Robot(5, 6, 2, 3, "E");
            Assert.AreEqual(robot4.Direction, RobotDirections.East);
        }

        [TestMethod]
        public void TestRobotCreateInBounds()
        {
            var robot1 = new Robot(5, 6, 2, 3, "N");
        }

        [TestMethod]
        public void TestRobotCreateOutOfBounds()
        {
            const string testError = "Robot placed out of bounds";

            try
            {
                var robot1 = new Robot(5, 6, 2, 8, "N");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message.ToString();
                Assert.AreEqual(testError, errorMessage);
            }

        }

        [TestMethod]
        public void TestRobotArenaOutOfBounds()
        {
            const string testError = "Arena size out of bounds";

            try
            {
                var robot1 = new Robot(-1, 6, 2, 5, "N");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message.ToString();
                Assert.AreEqual(testError, errorMessage);
            }

        }

        [TestMethod]
        public void TestRobotInvalidDirection()
        {
            const string testError = "Unknown robot direction";

            try
            {
                var robot1 = new Robot(5, 5, 2, 5, "X");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message.ToString();
                Assert.AreEqual(testError, errorMessage);
            }

        }

        [TestMethod]
        public void TestRobotNoDirection()
        {
            const string testError = "Invalid robot direction";

            try
            {
                var robot1 = new Robot(5, 5, 2, 5, "");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message.ToString();
                Assert.AreEqual(testError, errorMessage);
            }

        }

        [TestMethod]
        public void TestRobotInvalidLengthDirection()
        {
            const string testError = "Invalid robot direction";

            try
            {
                var robot1 = new Robot(5, 5, 2, 5, "LR");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message.ToString();
                Assert.AreEqual(testError, errorMessage);
            }

        }

        [TestMethod]
        public void TestRobotValidNorthMove()
        {
            var startX = 2;
            var startY = 3;
            var robot1 = new Robot(5, 5, startX, startY, "N");
            robot1.Move("M");
            Assert.AreEqual(robot1.X, startX);
            Assert.AreEqual(robot1.Y, startY+1);
        }

        [TestMethod]
        public void TestRobotValidSouthMove()
        {
            var startX = 2;
            var startY = 3;
            var robot1 = new Robot(5, 5, startX, startY, "S");
            robot1.Move("M");
            Assert.AreEqual(robot1.X, startX);
            Assert.AreEqual(robot1.Y, startY - 1);
        }

        [TestMethod]
        public void TestRobotValidEastMove()
        {
            var startX = 2;
            var startY = 3;
            var robot1 = new Robot(5, 5, startX, startY, "E");
            robot1.Move("M");
            Assert.AreEqual(robot1.X, startX + 1);
            Assert.AreEqual(robot1.Y, startY);
        }

        [TestMethod]
        public void TestRobotValidWestMove()
        {
            var startX = 2;
            var startY = 3;
            var robot1 = new Robot(5, 5, startX, startY, "W");
            robot1.Move("M");
            Assert.AreEqual(robot1.X, startX - 1);
            Assert.AreEqual(robot1.Y, startY);
        }

        // can add tests for invalid moves here - out of bounds etc

        [TestMethod]
        public void TestRobotSpinLeft()
        {
            var startX = 2;
            var startY = 3;
            var robot1 = new Robot(5, 5, startX, startY, "N");
            robot1.Move("L");
            Assert.AreEqual(robot1.X, startX);
            Assert.AreEqual(robot1.Y, startY);
            Assert.AreEqual(robot1.Direction, RobotDirections.West);

            robot1.Move("L");
            Assert.AreEqual(robot1.Direction, RobotDirections.South);

            robot1.Move("L");
            Assert.AreEqual(robot1.Direction, RobotDirections.East);

            robot1.Move("L");
            Assert.AreEqual(robot1.Direction, RobotDirections.North);
        }

        [TestMethod]
        public void TestRobotSpinRight()
        {
            var startX = 2;
            var startY = 3;
            var robot1 = new Robot(5, 5, startX, startY, "N");
            robot1.Move("R");
            Assert.AreEqual(robot1.X, startX);
            Assert.AreEqual(robot1.Y, startY);
            Assert.AreEqual(robot1.Direction, RobotDirections.East);

            robot1.Move("R");
            Assert.AreEqual(robot1.Direction, RobotDirections.South);

            robot1.Move("R");
            Assert.AreEqual(robot1.Direction, RobotDirections.West);

            robot1.Move("R");
            Assert.AreEqual(robot1.Direction, RobotDirections.North);
        }


        [TestMethod]
        public void TestRobotWarsFullTest()
        {
            // Tests the scenarios required by the coding challenge

            const int arenaWidth = 5;
            const int arenaHeight = 5;

            Robot robot1 = new Robot(arenaHeight, arenaWidth, 1, 2, "N");
            Robot robot2 = new Robot(arenaHeight, arenaWidth, 3, 3, "E");

            robot1.Move("LMLMLMLMM");
            robot2.Move("MMRMMRMRRM");

            Assert.AreEqual(robot1.X, 1);
            Assert.AreEqual(robot1.Y, 3);
            Assert.AreEqual(robot1.Direction, RobotDirections.North);

            Assert.AreEqual(robot2.X, 5);
            Assert.AreEqual(robot2.Y, 1);
            Assert.AreEqual(robot2.Direction, RobotDirections.East);
        }

    }
}
