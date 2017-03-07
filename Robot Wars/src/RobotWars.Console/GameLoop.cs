using System;
using System.Threading.Tasks;
using RobotWars.Console.Parsing;
using RobotWars.Implementation;
using RobotWars.Interface;
using Sprache;

namespace RobotWars.Console
{
	internal class GameLoop
	{
		public static async Task<IArena> Start(
			Func<Task<string>> inputReader,
			Func<IRobot, Task> resultWriter,
			Action<Exception> errorHandler)
		{
			try
			{
				return await ProcessInput(inputReader, resultWriter, errorHandler);
			}
			catch(Exception ex)
			{
				HandleErrors(errorHandler, ex);
				return null;
			}
		}

		private static async Task<IArena> ProcessInput(
			Func<Task<string>> inputReader,
			Func<IRobot, Task> resultWriter,
			Action<Exception> errorHandler)
		{
			var arenaInput = await inputReader() ?? string.Empty;
			var arena = new ArenaFactory().Initialise(InitialiseArenaCommand.Parse(arenaInput));

			while (await TryAddRobot(arena, inputReader, resultWriter, errorHandler));

			return arena;
		}

		private static async Task<bool> TryAddRobot(
			IArena arena,
			Func<Task<string>> inputReader,
			Func<IRobot, Task> resultWriter,
			Action<Exception> errorHandler)
		{
			try
			{
				return await AddRobot(arena, inputReader, resultWriter);
			}
			catch (Exception ex)
				when (ex is ParseException 
				|| ex is RobotInitialisationException)
			{
				HandleErrors(errorHandler, ex);
				return true;
			}
		}

		private static async Task<bool> AddRobot(
			IArena arena,
			Func<Task<string>> inputReader,
			Func<IRobot, Task> resultWriter)
		{
			var robot = await ArenaManagement.ProcessRobot(arena, inputReader);
			if (robot == null)
				return false;

			await resultWriter(robot);
			return true;
		}

		private static void HandleErrors(Action<Exception> errorHandler, Exception ex)
		{
			switch (ex)
			{
				case GameException g:
					errorHandler(ex);
					break;
				case ParseException p:
					errorHandler(ex);
					break;
				default:
					throw new GameException("Game encountered a fatal error", ex);
			}
		}
	}
}