using System;
using System.Linq;
using System.Threading.Tasks;
using RobotWars.Console.Parsing;
using RobotWars.Interface;

namespace RobotWars.Console
{
	internal class ArenaManagement
	{
		public static async Task<IRobot> ProcessRobot(
			IArena arena,
			Func<Task<string>> inputReader)
		{
			var robot = await AddRobot(arena, inputReader);
			return robot == null ? null : await MoveRobot(robot, inputReader);
		}

		private static async Task<IRobot> AddRobot(
			IArena arena,
			Func<Task<string>> inputReader)
		{
			var input = await ReadLine(inputReader);
			return input == null ? null : arena.AddRobot(InitialiseRobotCommand.Parse(input));
		}

		private static async Task<IRobot> MoveRobot(
			IRobot robot,
			Func<Task<string>> inputReader)
		{
			var commandInput = await ReadLine(inputReader);

			if (commandInput == null)
				return null;

			return MovementCommand
				.Parse(commandInput)
				.Aggregate(robot, (r, command) => r.Move(command));
		}

		private static async Task<string> ReadLine(Func<Task<string>> textReader)
		{
			var input = await textReader();
			return string.IsNullOrEmpty(input) ? null : input;
		}
	}
}