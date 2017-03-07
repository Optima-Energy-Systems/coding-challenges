using System;
using Moq;
using RobotWars.Interface;

namespace RobotWars.Implementation.Test.TestDoubles
{
	internal class InitialiseRobotCommand : IInitialiseRobotCommand
	{
		public InitialiseRobotCommand(
			int x,
			int y)
		{
			X = new Coordinate(x);
			Y = new Coordinate(y);
			Facing = StubFacing('N');
		}

		public InitialiseRobotCommand(
			int x,
			int y,
			char f) : this(x, y)
		{
			Facing = StubFacing(f);
		}

		private static IFacing StubFacing(
			char f)
		{
			var stub = new Mock<IFacing>();
			stub.Setup(facing => facing.ToString()).Returns(f.ToString());
			return stub.Object;
		}

		public ICoordinate X { get; }
		public ICoordinate Y { get; }
		public IFacing Facing { get; }
	}
}