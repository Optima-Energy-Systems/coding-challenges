namespace RobotWars.Interface
{
	public interface ICoordinate
	{
		int Value { get; }

		ICoordinate Plus(int delta);
	}
}