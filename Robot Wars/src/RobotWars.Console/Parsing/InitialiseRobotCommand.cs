using System;
using RobotWars.Console.Commands;
using RobotWars.Interface;
using Sprache;

namespace RobotWars.Console.Parsing
{
	internal class InitialiseRobotCommand
	{
		private static Parser<IInitialiseRobotCommand> Parser
		{
			get
			{
				var coordinate =
					from c in Sprache.Parse.Number.Select(_ => ErrorHandling.TryCreate(Int32.Parse, _))
					select ErrorHandling.TryCreate(() => new Coordinate(c));

				var facing = from f in Sprache.Parse.Char('N').Return(Facing.North)
						.Or(Sprache.Parse.Char('S').Return(Facing.South))
						.Or(Sprache.Parse.Char('E').Return(Facing.East))
						.Or(Sprache.Parse.Char('W').Return(Facing.West))
					select f;
	
				var separator = Sprache.Parse.WhiteSpace;
				var terminator = Sprache.Parse.LineTerminator.Or(Sprache.Parse.LineTerminator.End());

				return from x in coordinate
					   from y in separator.Then(_ => coordinate)
					   from f in separator.Then(_ => facing)
					   from recordTerminator in terminator
					   select ErrorHandling.TryCreate(() => new Commands.InitialiseRobotCommand(x, y, f));
			}
		}

		public static IInitialiseRobotCommand Parse(
			string input)
		{
			return Parser.Parse(input);
		}
	}
}