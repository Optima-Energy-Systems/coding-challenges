namespace RobotWars.Interface
{
	public interface IInitialiseRobotCommand
	{
		ICoordinate X { get; }
		ICoordinate Y { get; }
		IFacing Facing { get; }
	}
}