using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Domain;

namespace RobotWars.Test
{
    [TestClass]
    public class RobotCommands
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void WhenCreateRobotCommandIsInvalid_AnExceptionThrown()
        {
            CommandParser.ParseRobotCreateCommand("XYZ");
        }

        [TestMethod]
        public void WhenCreateRobotCommandIsValid_CorrectCommandCreated()
        {
            RobotCreateCommand command = CommandParser.ParseRobotCreateCommand("1 2 N");
            Assert.AreEqual(command.PositionX, 1);
            Assert.AreEqual(command.PositionY, 2);
            Assert.AreEqual(command.Orientation.ToString(), Orientation.North.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void WhenRobotCommandIsInvalid_AnExceptionThrown()
        {
            CommandParser.ParseRobotCommand("XYZ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenRobotDirectionIsInvalid_AnExceptionThrown()
        {
            RobotTurnCommand command = new RobotTurnCommand('X');
        }
    }
}