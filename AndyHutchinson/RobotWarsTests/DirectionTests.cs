using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars;

namespace RobotWarsTests
{
    [TestClass]
    public class DirectionTests
    {
        [TestMethod]
        public void TestNeighbours()
        {
            // North's neighbours.
            Assert.AreSame(Direction.FindDirection(Direction.WEST_ID),
                           Direction.FindDirection(Direction.NORTH_ID).GetLeftDirection());                         
            Assert.AreSame(Direction.FindDirection(Direction.EAST_ID),
                           Direction.FindDirection(Direction.NORTH_ID).GetRightDirection());

            // East's neighbours.
            Assert.AreSame(Direction.FindDirection(Direction.NORTH_ID),
                           Direction.FindDirection(Direction.EAST_ID).GetLeftDirection());
            Assert.AreSame(Direction.FindDirection(Direction.SOUTH_ID),
                           Direction.FindDirection(Direction.EAST_ID).GetRightDirection());

            // South's neighbours.
            Assert.AreSame(Direction.FindDirection(Direction.EAST_ID),
                           Direction.FindDirection(Direction.SOUTH_ID).GetLeftDirection());
            Assert.AreSame(Direction.FindDirection(Direction.WEST_ID),
                           Direction.FindDirection(Direction.SOUTH_ID).GetRightDirection());

            // West's neighbours
            Assert.AreSame(Direction.FindDirection(Direction.SOUTH_ID),
                           Direction.FindDirection(Direction.WEST_ID).GetLeftDirection());
            Assert.AreSame(Direction.FindDirection(Direction.NORTH_ID),
                           Direction.FindDirection(Direction.WEST_ID).GetRightDirection());
        }

        [TestMethod]
        public void TestMoves()
        {
            // North's moves.
            Assert.AreEqual( 0, Direction.FindDirection(Direction.NORTH_ID).GetMovementX());
            Assert.AreEqual( 1, Direction.FindDirection(Direction.NORTH_ID).GetMovementY());

            // East's moves.
            Assert.AreEqual( 1, Direction.FindDirection(Direction.EAST_ID).GetMovementX());
            Assert.AreEqual( 0, Direction.FindDirection(Direction.EAST_ID).GetMovementY());

            // South's moves.
            Assert.AreEqual( 0, Direction.FindDirection(Direction.SOUTH_ID).GetMovementX());
            Assert.AreEqual(-1, Direction.FindDirection(Direction.SOUTH_ID).GetMovementY());

            // West's moves
            Assert.AreEqual(-1, Direction.FindDirection(Direction.WEST_ID).GetMovementX());
            Assert.AreEqual( 0, Direction.FindDirection(Direction.WEST_ID).GetMovementY());
        }
    }
}
