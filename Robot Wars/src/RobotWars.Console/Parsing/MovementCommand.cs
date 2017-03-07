using System.Collections.Generic;
using RobotWars.Interface;
using Sprache;

namespace RobotWars.Console.Parsing
{
	internal class MovementCommand
	{
		public static Parser<IEnumerable<IMovementCommand>> Parser
		{
			get
			{
				var command =
					from c in TurnCommand.Parser.Or(MoveCommand.Parser)
					select c;

				var terminator = Sprache.Parse.LineTerminator.Or(Sprache.Parse.LineTerminator.End());

				return from c in command.Many()
					   from recordTerminator in terminator
					   select c;
			}
		}

		public static IEnumerable<IMovementCommand> Parse(
			string input)
		{
			return Parser.Parse(input);
		}

	}
}