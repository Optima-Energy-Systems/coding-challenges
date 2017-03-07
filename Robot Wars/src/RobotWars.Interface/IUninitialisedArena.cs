namespace RobotWars.Interface
{
	public interface IUninitialisedArena
	{
		IArena Initialise(IInitialiseArenaCommand command);
	}
}