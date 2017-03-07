using RobotWars.Interface;

namespace RobotWars.Console.Commands
{
	internal class Dimension : ShapedStruct<int>, IDimension
    {
        public Dimension(int value)
            : base(value)
        {
        }

        public static explicit operator Dimension(int value) => new Dimension(value);
    }
}