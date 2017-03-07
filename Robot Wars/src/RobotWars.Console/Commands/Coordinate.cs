using RobotWars.Interface;

namespace RobotWars.Console.Commands
{
	internal class Coordinate : ShapedStruct<int>, ICoordinate
	{
		public Coordinate(int value) : base(value)
		{
		}

		public static explicit operator Coordinate(int value) => new Coordinate(value);

		public ICoordinate Plus(
			int delta)
		{
			return new Coordinate(Value + delta);
		}
	}
}