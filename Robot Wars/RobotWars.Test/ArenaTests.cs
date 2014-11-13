using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotWars.Test
{
    [TestClass]
    public class ArenaTests
    {
        [TestMethod]
        public void ArenaNullValue()
        {
            var arena = new Arena(null);
            Assert.IsFalse(arena.IsValid);
            Assert.AreEqual(arena.ErrorMessage, "The value is null");
        }

        [TestMethod]
        public void ArenaEmptyValue()
        {
            var arena = new Arena("");
            Assert.IsFalse(arena.IsValid);
            Assert.AreEqual(arena.ErrorMessage, "The value is invalid");
        }

        [TestMethod]
        public void ArenaNoneNumeric()
        {
            var arena = new Arena("a b");
            Assert.IsFalse(arena.IsValid);
            Assert.AreEqual(arena.ErrorMessage, "The value is invalid");
        }

        [TestMethod]
        public void ArenaWidthToSmall()
        {
            var arena = new Arena("0 5");
            Assert.IsFalse(arena.IsValid);
            Assert.AreEqual(arena.ErrorMessage, "Width need to be a number between 1 and 65535");
        }

        [TestMethod]
        public void ArenaWidthToLarge()
        {
            var arena = new Arena("65536 5");
            Assert.IsFalse(arena.IsValid);
            Assert.AreEqual(arena.ErrorMessage, "Width need to be a number between 1 and 65535");
        }

        [TestMethod]
        public void ArenaHeightToSmall()
        {
            var arena = new Arena("5 0");
            Assert.IsFalse(arena.IsValid);
            Assert.AreEqual(arena.ErrorMessage, "Height need to be a number between 1 and 65535");
        }

        [TestMethod]
        public void ArenaHeightToLarge()
        {
            var arena = new Arena("5 65536");
            Assert.IsFalse(arena.IsValid);
            Assert.AreEqual(arena.ErrorMessage, "Height need to be a number between 1 and 65535");
        }

        [TestMethod]
        public void ArenaValid()
        {
            var arena = new Arena("10 10");
            Assert.IsTrue(arena.IsValid);
        }
    }
}
