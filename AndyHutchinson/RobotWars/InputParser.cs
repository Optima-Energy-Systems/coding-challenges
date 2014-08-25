using System;
using System.IO;

namespace RobotWars
{
    /**
     * Responsible for reading an input source, setting up the
     * grid limits and robot initial positions, and passing each
     * robot its moves.
     */
    public class InputParser
    {
        private TextReader input;
 
        /**
         * Prompt the user about what input is expected next?
         */
        private bool prompt;

        /**
         * Provide feedback on the console about parsed values?
         */
        private bool echo;

        private int gridSizeX = -1;
        private int gridSizeY = -1;

        private int initialPositionX = -1;
        private int initialPositionY = -1;
        private Direction initialDirection = null;

        /**
         * Create an input parser that reads from a file
         * and doesn't prompt.
         */
        public InputParser(string fileName, bool echo)
        {
            input = new StreamReader(fileName);
            prompt = false;
            this.echo = echo;
        }

        /**
         * Create an input parser that reads from the console
         * and prompts the user with helpful reminders. 
         */
        public InputParser(bool echo)
        {            
            input = Console.In;
            prompt = true;
            this.echo = echo;
        }

        /**
         * Create a quite input parser with no input.
         */
        public InputParser()
        {
            input = null;
            echo = false;
            prompt = false;
        }

        /**
         * Read the input, prompting the user if required.
         */ 
        public void Parse()
        {
            if (prompt)
            {
                Console.WriteLine("Enter the grid size (e.g. 7 7)");
            }
            string gridSizeLine = input.ReadLine();

            if (gridSizeLine == null)
            {
                return;
            }
            ParseGridSize(gridSizeLine);

            while(true)
            {
                if (prompt)
                {
                    Console.WriteLine("Enter a robot initial position (e.g. 3 4 W)");
                }
                string initialPositionLine = input.ReadLine();
                
                if (initialPositionLine == null)
                {
                    break;
                }
                ParseInitialPosition(initialPositionLine);

                if (prompt)
                {
                    Console.WriteLine("Enter the robot's moves (e.g. LMRM)");
                }
                string movesLine = input.ReadLine();

                if (movesLine == null)
                {
                    break;
                }

                Robot r = CreateRobot();
                ParseMovesLine(movesLine, r);
            }
        }

        /**
         * Parse the grid size line.
         */
        public void ParseGridSize(string line)
        {
            string[] sizes = line.Split(new char[] { ' ' });

            if (sizes == null || sizes.Length != 2)
            {
                throw new RobotWarsException("Bad grid size line: " + line);
            }

            try
            {
                gridSizeX = int.Parse(sizes[0]);
                gridSizeY = int.Parse(sizes[1]);
            }
            catch (Exception)
            {
                throw new RobotWarsException("Bad grid size line: " + line);
            }

            if (echo)
            {
                Console.WriteLine("Got grid size of: " + gridSizeX + " " + gridSizeY);
            }
        }

        /**
         * Parse an initial position line.
         */
        public void ParseInitialPosition(string line)
        {
            string[] positions = line.Split(new char[] { ' ' });

            if (positions == null || positions.Length != 3)
            {
                throw new RobotWarsException("Bad initial position line: " + line);
            }

            try
            {
                initialPositionX = int.Parse(positions[0]);
                initialPositionY = int.Parse(positions[1]);
                initialDirection = Direction.FindDirection(positions[2]);
            }
            catch (Exception)
            {
                throw new RobotWarsException("Bad initial position line: " + line);
            }

            if (echo)
            {
                Console.WriteLine("Got a robot initial position of: " + 
                                  initialPositionX + " " + initialPositionY + " " + initialDirection);
            }
        }

        /**
         * Parse a moves line and apply the moves to the specified robot.
         */
        public void ParseMovesLine(string line, Robot r)
        {
            if (echo)
            {
                Console.WriteLine("Got a robot moves line of: " + line);
            }

            char[] chars = line.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                r.Move(chars[i]);
            }

            Console.WriteLine("");
            Console.WriteLine("-----> Robot Final Position: " + r + " <-----");
            Console.WriteLine("");

        }

        /** 
         * Create a robot with the parsed grid limits and initial position.
         */
        public Robot CreateRobot()
        {
            return new Robot(initialPositionX, initialPositionY, initialDirection,
                             gridSizeX, gridSizeY);

        }
    }
}
