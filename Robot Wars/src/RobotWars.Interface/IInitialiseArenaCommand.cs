namespace RobotWars.Interface
{
	public interface IInitialiseArenaCommand
	{
		IDimension MaximumY { get; }
		IDimension MaximumX { get; }
	}
}