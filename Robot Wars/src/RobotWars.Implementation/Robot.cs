using System;
using RobotWars.Interface;

namespace RobotWars.Implementation
{
	internal class Robot : IRobot
	{
		private readonly Facing _facing;
		private readonly IArena _arena;
		private readonly ICoordinate _x;
		private readonly ICoordinate _y;

		public ICoordinate X
		{
			get { ThrowIfDisposed(); return _x; }
		}

		public ICoordinate Y
		{
			get { ThrowIfDisposed(); return _y; }
		}

		public IFacing Facing
		{
			get { ThrowIfDisposed(); return _facing; }
		}

		public bool IsDisposed { get; private set; }

		public Robot(
			ICoordinate x,
			ICoordinate y,
			IFacing facing,
			IArena arena)
		{
			if (x == null)
				throw new ArgumentNullException(nameof(x));
			if (y == null)
				throw new ArgumentNullException(nameof(y));
			if (facing == null)
				throw new ArgumentNullException(nameof(facing));
			if (arena == null)
				throw new ArgumentNullException(nameof(arena));

			_x = x;
			_y = y;
			_facing = Implementation.Facing.Get(facing);
			_arena = arena;
		}

		public IRobot Move(
			IMovementCommand command)
		{
			ThrowIfDisposed();
			switch (command)
			{
				case ITurnCommand t:
					return Turn(t);
				case IMoveCommand m:
					return Move();
				default:
					throw new NotSupportedException($"Command of type {command} is not supported.");
			}

		}

		private IRobot Move()
		{
			ThrowIfDisposed();
			return _arena.ReplaceRobot(
				this,
				new Robot(
					X.Plus(_facing.DeltaX),
					Y.Plus(_facing.DeltaY),
					_facing,
					_arena));
		}

		private IRobot Turn(
			ITurnCommand command)
		{
			ThrowIfDisposed();
			return _arena.ReplaceRobot(
				this,
				new Robot(
					X, 
					Y, 
					_facing.Turn(command.Direction),
					_arena));
		}

		public void Dispose()
		{
			IsDisposed = true;
		}

		private void ThrowIfDisposed()
		{
			if(IsDisposed)
				throw new ObjectDisposedException(nameof(Robot));
		}
	}
}