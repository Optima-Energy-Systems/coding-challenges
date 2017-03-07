using System;
using RobotWars.Interface;

namespace RobotWars.Implementation
{
	internal class Facing : IFacing
	{
		public static readonly Facing North = new Facing('N', () => West, () => East, 0, 1);
		public static readonly Facing South = new Facing('S', () => East, () => West, 0, -1);
		public static readonly Facing East = new Facing('E', () => North, () => South, 1, 0);
		public static readonly Facing West = new Facing('W', () => South, () => North, -1, 0);

		public int DeltaX { get; }
		public int DeltaY { get; }

		public static Facing Get(IFacing facing)
		{
			if (facing == null)
				throw new ArgumentNullException(nameof(facing));

			var f = facing as Facing;
			if (f != null)
				return f;

			switch (facing.ToString())
			{
				case "N":
					return North;
				case "S":
					return South;
				case "E":
					return East;
				case "W":
					return West;
				default:
					throw new NotSupportedException($"Facing type of {facing} is not supported");
			}
		}


		private readonly char _facing;
		private readonly Func<Facing> _left;
		private readonly Func<Facing> _right;

		private Facing(char f,
			Func<Facing> left,
			Func<Facing> right,
			int deltaX,
			int deltaY)
		{
			_facing = f;
			_left = left;
			_right = right;
			DeltaX = deltaX;
			DeltaY = deltaY;
		}

		public override string ToString()
		{
			return _facing.ToString();
		}

		public Facing Turn(IDirection direction)
		{
			if (direction == null)
				throw new ArgumentNullException(nameof(direction));

			switch (direction)
			{
				case IDirectionLeft l:
					return _left();
				case IDirectionRight r:
					return _right();
				default:
					throw new NotSupportedException($"Direction of {direction} is not supported");
			}
		}
	}
}