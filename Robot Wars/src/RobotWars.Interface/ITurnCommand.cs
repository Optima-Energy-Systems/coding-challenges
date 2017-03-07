namespace RobotWars.Interface
{
	public interface ITurnCommand : IMovementCommand
	{
		IDirection Direction { get; }
	}
}