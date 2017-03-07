using System;
using System.Collections.Generic;
using RobotWars.Console.Commands;
using RobotWars.Interface;
using Sprache;

namespace RobotWars.Console.Parsing
{
	internal class TurnCommand
	{
		public static Parser<IMovementCommand> Parser => 
			from f in Parse.Char('L').Return(Commands.TurnCommand.TurnLeft)
				.Or(Parse.Char('R').Return(Commands.TurnCommand.TurnRight))
			select f;
	}
}