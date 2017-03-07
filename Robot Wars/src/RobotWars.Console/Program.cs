using System;
using System.IO;
using System.Threading.Tasks;
using RobotWars.Interface;

namespace RobotWars.Console
{
	public class Program
	{
		public static void Main(
			string[] args)
		{
			GameLoop.Start(
					ReadLine,
					robot => WriteRobot(robot, System.Console.Out),
					WriteErrorMessage)
				.Wait();
		}

		private static async Task<string> ReadLine()
		{
			return await System.Console.In.ReadLineAsync();
		}

		internal static async Task WriteRobot(
			IRobot robot,
			TextWriter textWriter)
		{
			await textWriter.WriteLineAsync($"{robot.X.Value} {robot.Y.Value} {robot.Facing}");
		}

		private static void WriteErrorMessage(
			Exception exception)
		{
			System.Console.Error.WriteLine("Error: " + exception.Message);
			if (exception.InnerException != null)
				WriteErrorMessage(exception.InnerException);
		}
	}
}
