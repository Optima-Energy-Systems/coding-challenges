using System;
using RobotWars.Interface;

namespace RobotWars.Implementation
{
    public class ArenaFactory : IUninitialisedArena
    {
	    private const string ArenaInitialisationFailed = "Arena initialisation failed.";

	    public IArena Initialise(IInitialiseArenaCommand arenaCommand)
		{
			return TryInitialiseArena(arenaCommand);
		}

		private static IArena TryInitialiseArena(IInitialiseArenaCommand arenaCommand)
		{
			try
			{
				return new Arena(arenaCommand.MaximumX, arenaCommand.MaximumY);
			}
			catch (Exception ex)
			{
				throw new ArenaInitialisationException(ArenaInitialisationFailed, ex);
			}
		}
    }
}
