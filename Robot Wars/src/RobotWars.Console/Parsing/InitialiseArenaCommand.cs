using System;
using RobotWars.Console.Commands;
using RobotWars.Interface;
using Sprache;

namespace RobotWars.Console.Parsing
{
    internal static class InitialiseArenaCommand
    {
	    private static Parser<IInitialiseArenaCommand> Parser
		{
			get
			{
				var dimension = 
					from c in Sprache.Parse.Number.Select(_ => ErrorHandling.TryCreate(Int32.Parse, _))
					select ErrorHandling.TryCreate(() => new Dimension(c));

				var separator = Sprache.Parse.WhiteSpace;
				var terminator = Sprache.Parse.LineTerminator.Or(Sprache.Parse.LineTerminator.End());

				return from x in dimension
					from y in separator.Then(_ => dimension)
					from recordTerminator in terminator
					select ErrorHandling.TryCreate<IInitialiseArenaCommand>(() => new Commands.InitialiseArenaCommand(x, y));
			}
		}

	    public static IInitialiseArenaCommand Parse(
		    string arenaInput)
	    {
		    return Parser.Parse(arenaInput);
	    }
    }
}