using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Interfaces;
using RobotWars.Domain;

namespace RobotWars.Test
{
    [TestClass]
    public class Robots
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenXPositionIsNegative_AnExceptionThrown()
        {
            Robot robot = new Robot(-1, 2, Orientation.North);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenYPositionIsNegative_AnExceptionThrown()
        {
            Robot robot = new Robot(2, -2, Orientation.North);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenXAndYPositionIsNegative_AnExceptionThrown()
        {
            Robot robot = new Robot(-2, -2, Orientation.North);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenCommandXPositionIsNegative_AnExceptionThrown()
        {
            RobotCreateCommand command = new RobotCreateCommand(-1, 2, Orientation.North);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenCommandYPositionIsNegative_AnExceptionThrown()
        {
            RobotCreateCommand command = new RobotCreateCommand(2, -1, Orientation.North);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenCommandXAndYPositionIsNegative_AnExceptionThrown()
        {
            RobotCreateCommand command = new RobotCreateCommand(-1, -1, Orientation.North);
        }

        [TestMethod]
        [ExpectedException(typeof(CollisionException))]
        public void WhenRobotCollidesWithRobot_AnExceptionThrown()
        {
            BattleArena arena = new BattleArena(5, 5);
            Robot robot1 = new Robot(0, 1, Orientation.North);
            Robot robot2 = new Robot(0, 0, Orientation.North);
            arena.AddRobot(robot1);
            arena.AddRobot(robot2);
            IRobot newRobotPosition = robot2.Move();

            arena.UpdateRobotPosition(robot2, newRobotPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(IllegalMoveException))]
        public void WhenRobotStraysOutOfArena_AnExceptionThrown()
        {
            BattleArena arena = new BattleArena(0, 0);
            Robot robot1 = new Robot(0, 0, Orientation.North);

            IRobot newRobotPosition = robot1.Move();

            arena.UpdateRobotPosition(robot1, newRobotPosition);
        }

        [TestMethod]
        public void WhenRobotTurnsLeft_HasCorrectOrientation()
        {
            BattleArena arena = new BattleArena(5, 5);
            Robot robot1 = new Robot(0, 0, Orientation.North);
            RobotTurnCommand command = new RobotTurnCommand('L');
            IRobot newRobotPosition = robot1.Turn(command);

            Assert.AreEqual(newRobotPosition.Orientation.ToString(), "W");
        }

        [TestMethod]
        public void WhenRobotTurnsRight_HasCorrectOrientation()
        {
            BattleArena arena = new BattleArena(5, 5);
            Robot robot1 = new Robot(0, 0, Orientation.North);
            RobotTurnCommand command = new RobotTurnCommand('R');
            IRobot newRobotPosition = robot1.Turn(command);

            Assert.AreEqual(newRobotPosition.Orientation.ToString(), "E");
        }

        [TestMethod]
        public void WhenRobotMoves_HasCorrectPosition()
        {
            BattleArena arena = new BattleArena(5, 5);
            Robot robot1 = new Robot(0, 0, Orientation.North);
            RobotTurnCommand command = new RobotTurnCommand('R');
            IRobot newRobotPosition = robot1.Turn(command).Move();

            Assert.AreEqual(newRobotPosition.PositionX, 1);
            Assert.AreEqual(newRobotPosition.PositionY, 0);
            Assert.AreEqual(newRobotPosition.Orientation.ToString(), "E");
        }
    }
}