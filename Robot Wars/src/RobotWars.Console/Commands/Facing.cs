using RobotWars.Interface;

namespace RobotWars.Console.Commands
{
	internal class Facing : IFacing
	{
		public static readonly IFacing North = new Facing('N');
		public static readonly IFacing South = new Facing('S');
		public static readonly IFacing East = new Facing('E');
		public static readonly IFacing West = new Facing('W');

		private readonly char _direction;

		private Facing(char direction)
		{
			_direction = direction;
		}

		public override string ToString()
		{
			return _direction.ToString();
		}
	}
}