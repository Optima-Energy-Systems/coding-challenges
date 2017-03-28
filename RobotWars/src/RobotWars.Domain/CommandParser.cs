using System;
using System.Collections.Generic;
using System.Linq;
using RobotWars.Interfaces;

namespace RobotWars.Domain
{
    public class CommandParser
    {
        public static BattleArenaCreateCommand ParseArenaCommand(string input)
        {
            if (input == null)
                throw new ArgumentNullException("");

            if(!input.All(c => char.IsDigit(c) || char.IsWhiteSpace(c)))
                throw new InvalidCommandException($"Invalid command: {input}");

            var args = input.ToUpper().Split(null);
            if (args.Count() != 2)
                throw new InvalidCommandException($"Invalid command: {input}");

            return new BattleArenaCreateCommand(int.Parse(args[0].ToString()), int.Parse(args[1].ToString()));

        }

        public static RobotCreateCommand ParseRobotCreateCommand(string input)
        {
            if (input == null)
                throw new ArgumentNullException("");

            if (!input.All(c => char.IsDigit(c) || char.IsWhiteSpace(c) || char.IsLetter(c)))
                throw new InvalidCommandException($"Invalid command: {input}");

            var args = input.ToUpper().Split(null);
            if (args.Count() != 3 || args.Any(arg => string.IsNullOrWhiteSpace(arg)))
                throw new InvalidCommandException($"Invalid command: {input}");

            return new RobotCreateCommand(int.Parse(args[0].ToString()), int.Parse(args[1].ToString()), new Orientation(args[2].First()));
        }


        public static List<ICommand> ParseRobotCommand(string input)
        {
            if (input == null)
                throw new ArgumentNullException("");

            input = input.ToUpper();
            if (!input.All(c => c == 'M' || c == 'R' || c== 'L'))
                throw new InvalidCommandException($"Invalid command: {input}");

            List<ICommand> commands = new List<ICommand>();
            foreach (char c in input)
            {
                if (c == 'M')
                    commands.Add(new RobotMoveCommand());
                else
                    commands.Add(new RobotTurnCommand(c));
            }

            return commands;
        }
    }
}