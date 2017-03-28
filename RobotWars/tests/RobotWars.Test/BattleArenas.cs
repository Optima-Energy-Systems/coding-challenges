using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Domain;

namespace RobotWars.Test
{
    [TestClass]
    public class BattleArenas
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenXPositionIsNegative_AnExceptionThrown()
        {
            BattleArena arena = new BattleArena(-1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenYPositionIsNegative_AnExceptionThrown()
        {
            BattleArena arena = new BattleArena(2, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenXAndYPositionIsNegative_AnExceptionThrown()
        {
            BattleArena arena = new BattleArena(-2, -2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenCommandXPositionIsNegative_AnExceptionThrown()
        {
            BattleArenaCreateCommand command = new BattleArenaCreateCommand(-1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenCommandYPositionIsNegative_AnExceptionThrown()
        {
            BattleArenaCreateCommand command = new BattleArenaCreateCommand(-1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenCommandXAndYPositionIsNegative_AnExceptionThrown()
        {
            BattleArenaCreateCommand command = new BattleArenaCreateCommand(-1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void WhenCreateArenaCommandIsInvalid_AnExceptionThrown()
        {
            CommandParser.ParseArenaCommand("XYZ");
        }

        [TestMethod]
        public void WhenCreateArenaCommandIsValid_CorrectMaximumXPositionReturned()
        {
            BattleArenaCreateCommand command = CommandParser.ParseArenaCommand("5 5");
            Assert.AreEqual(command.MaximumPositionX, 5);
        }

        [TestMethod]
        public void WhenCreateArenaCommandIsValid_CorrectMaximumYPositionReturned()
        {
            BattleArenaCreateCommand command = CommandParser.ParseArenaCommand("5 5");
            Assert.AreEqual(command.MaximumPositionY, 5);
        }
    }
}