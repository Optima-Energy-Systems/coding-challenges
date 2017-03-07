using RobotWars.Interface;

namespace RobotWars.Implementation
{
	internal class Coordinate : ICoordinate
	{
		public Coordinate(int value)
		{
			Value = value;
		}

		public int Value { get; }

		public ICoordinate Plus(
			int delta)
		{
			return new Coordinate(Value + delta);
		}
	}
}