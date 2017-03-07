using System;

namespace RobotWars.Interface
{
	public interface IRobot : IDisposable
	{
		ICoordinate X { get; }
		ICoordinate Y { get; }
		IFacing Facing { get; }

		IRobot Move(IMovementCommand command);
		bool IsDisposed { get; }
	}
}