using NUnit.Framework;
using RobotWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWarsTests
{
    [TestFixture]
    public class RobotWarTest
    {
        [Test]
        public void CheckArenaSize()
        {
            Arena arena = new Arena();
            Assert.AreEqual(5, Arena.)
        }
       
        [Test]
        public void Move1xfrom0Robot()
        {
            Robot robot = new Robot();
            Assert.AreEqual(1, robot.Move("M"));

        }
        [Test]
        public void TurnLeftfromNorthRobot()
        {
            Robot robot = new Robot();
            Assert.AreEqual("E", robot.Move("L"));

        }

        
    }
}
