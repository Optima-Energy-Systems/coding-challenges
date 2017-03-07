using RobotWars.Interface;
using Sprache;

namespace RobotWars.Console.Parsing
{
	internal class MoveCommand
	{
		public static Parser<IMovementCommand> Parser => 
			from c in Parse.Char('M')
			select new Commands.MoveCommand();
	}
}