using System;
using System.Collections.Generic;
using RobotWars.Interfaces;
using RobotWars.Domain;

namespace RobotWars
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BattleArenaCreateCommand createArenaCommand = WaitForArenaCreation();
                BattleArena arena = new BattleArena(createArenaCommand.MaximumPositionX, createArenaCommand.MaximumPositionY);

                while (true)
                {
                    try
                    {
                        IRobotCreateCommand createRobotCommand = WaitForRobotCreationCommand();
                        IRobot currentlyControlledRobot = new Robot(createRobotCommand.PositionX, createRobotCommand.PositionY, createRobotCommand.Orientation);
                        arena.AddRobot(currentlyControlledRobot);

                        IList<ICommand> robotCommands = WaitForRobotCommands(currentlyControlledRobot);
                        foreach (ICommand command in robotCommands)
                        {
                            if (command is IRobotTurnCommand)
                            {
                                IRobotTurnCommand turnCommand = command as IRobotTurnCommand;
                                currentlyControlledRobot = currentlyControlledRobot.Turn(turnCommand);
                            }
                            else if (command is IRobotMoveCommand)
                            {
                                currentlyControlledRobot = currentlyControlledRobot.Move();
                            }
                        }

                        Console.WriteLine(currentlyControlledRobot.ToString());
                    }
                    catch (Exception ex) when (ex is CollisionException)
                    {
                        WriteError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private static BattleArenaCreateCommand WaitForArenaCreation()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    return CommandParser.ParseArenaCommand(input);
                }
                catch (Exception ex) when (ex is InvalidCommandException || ex is ArgumentException)
                {
                    WriteError(ex);
                }
            }
        }

        private static RobotCreateCommand WaitForRobotCreationCommand()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    return CommandParser.ParseRobotCreateCommand(input);
                }
                catch (Exception ex) when (ex is InvalidCommandException || ex is ArgumentException)
                {
                    WriteError(ex);
                }
            }
        }

        private static List<ICommand> WaitForRobotCommands(IRobot robot)
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    return CommandParser.ParseRobotCommand(input);
                }
                catch (Exception ex) when (ex is InvalidCommandException || ex is ArgumentException)
                {
                    WriteError(ex);
                }
            }
        }

        private static void WriteError(Exception exception)
        {
            Console.WriteLine(exception.Message);
            if (exception.InnerException != null)
                WriteError(exception.InnerException);
        }
    }
}
