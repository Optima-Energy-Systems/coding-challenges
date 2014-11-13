using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameRun(new ConsoleWrapper());
        }

        public static void GameRun(ConsoleWrapper console)
        {
            // Read the options for the arena.
            Arena arena = new Arena(console.ReadLine().Trim());

            // Check the arena is valid.
            if (!arena.IsValid)
            {
                console.WriteLine("Sorry your arena could not be created - '{0}'", arena.ErrorMessage);
            }
            else
            {
                var robotConfigs = CreateRobots(console, arena, 2);
                MoveRobots(console, robotConfigs);
            }

            console.WriteLine("Please any key to continue...");
            console.ReadKey();
        }

        private static RobotConfig[] CreateRobots(ConsoleWrapper console, Arena arena, int count)
        {
            var robots = new List<RobotConfig>();

            for (int i = 0; i < count; i++)
            {
                RobotConfig config = new RobotConfig
                {
                    Robot = new Robot(arena, console.ReadLine()),
                    Command = console.ReadLine()
                };

                robots.Add(config);
            }

            return robots.ToArray();
        }

        private static void MoveRobots(ConsoleWrapper console, RobotConfig[] configs)
        {
            for (int i = 0; i < configs.Length; i++)
            {
                var currentConfig = configs[i];

                // Check the robot is valid.
                var currentRobot = currentConfig.Robot;
                if (!currentRobot.IsValid)
                {
                    console.WriteLine("Sorry, robot {0} could not be created: {1}", i + 1, currentRobot.ErrorMessage);
                    break;

                }

                // Move the robots
                currentRobot.Navagate(currentConfig.Command);
                if (!currentRobot.IsValid)
                {
                    console.WriteLine("Sorry, robot {0} could has had a problem: {1}", i + 1, currentRobot.ErrorMessage);
                    break;
                }

                // Display the output
                console.WriteLine(currentRobot);
            }
        }

        private class RobotConfig
        {
            public Robot Robot { get; set; }

            public string Command { get; set; }
        }
    }

    public class ConsoleWrapper
    {
        public virtual void WriteLine(object value)
        {
            Console.WriteLine(value);
        }

        public virtual void WriteLine(string format, object arg0)
        {
            Console.WriteLine(format, arg0);
        }

        public virtual void WriteLine(string format, object arg0, object arg1)
        {
            Console.WriteLine(format, arg0, arg1);
        }

        public virtual string ReadLine()
        {
            return Console.ReadLine();
        }

        public virtual ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }
    }
}
