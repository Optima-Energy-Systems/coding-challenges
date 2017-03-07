using System;
using System.Collections.Generic;
using System.Linq;
using RobotWars.Interface;

namespace RobotWars.Implementation
{
	internal class Arena : IArena
	{
		private readonly List<IRobot> _robots = new List<IRobot>();

		public Arena(
			IDimension maximumX,
			IDimension maximumY)
		{
			if (maximumX.Value <= 0)
				throw new ArgumentOutOfRangeException(nameof(maximumX), "Maximum X co-ordinate must be larger than zero");
			if (maximumY.Value <= 0)
				throw new ArgumentOutOfRangeException(nameof(maximumY), "Maximum Y co-ordinate must be larger than zero");

			MaximumX = maximumX;
			MaximumY = maximumY;
		}

		public IRobot AddRobot(
			IInitialiseRobotCommand robotCommand)
		{
			if (robotCommand.X.Value < 0
			    || robotCommand.Y.Value < 0
			    || robotCommand.X.Value > MaximumX.Value
			    || robotCommand.Y.Value > MaximumY.Value)
				throw new RobotInitialisationException("Robot is outside the bounds of the arena.");

			return AddRobotToCollection(robotCommand);
		}

		private Robot AddRobotToCollection(
			IInitialiseRobotCommand robotCommand)
		{
			return AddRobotToCollectionWithCollisionCheck(TryCreateRobot(robotCommand));
		}

		private Robot TryCreateRobot(
			IInitialiseRobotCommand robotCommand)
		{
			try
			{
				return new Robot(robotCommand.X, robotCommand.Y, robotCommand.Facing, this);
			}
			catch(NotSupportedException nsex)
			{
				throw new RobotInitialisationException("Robot initialisation failed.", nsex);
			}
		}

		private Robot AddRobotToCollectionWithCollisionCheck(
			Robot robot)
		{
			if (ExistsCollision(robot, robot) != null)
				throw new RobotInitialisationException("Robots cannot be placed in the same location as an existing robot.");

			_robots.Add(robot);
			return robot;
		}

		public IRobot ReplaceRobot(
			IRobot current,
			IRobot replacement)
		{
			if(current == null)
				throw new ArgumentNullException(nameof(current));
			if(replacement == null)
				throw new ArgumentNullException(nameof(replacement));

			var index = _robots.FindIndex(robot => robot == current);
			if (index == -1)
				throw new InvalidOperationException("Robot is not present in arena.");

			if (replacement.X.Value < 0
				|| replacement.Y.Value < 0
				|| replacement.X.Value > MaximumX.Value
				|| replacement.Y.Value > MaximumY.Value
				|| ExistsCollision(replacement, current) != null)
					return current;

			current.Dispose();
			return _robots[index] = replacement;
		}

		private IRobot ExistsCollision(IRobot robot, IRobot exclude) =>
			_robots.SingleOrDefault(r => r != exclude && r.X.Value == robot.X.Value && r.Y.Value == robot.Y.Value);

		public IDimension MaximumY { get; }
		public IDimension MaximumX { get; }
		public IReadOnlyCollection<IRobot> Robots => _robots.AsReadOnly();
	}
}