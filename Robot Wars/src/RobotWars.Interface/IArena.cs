using System.Collections.Generic;

namespace RobotWars.Interface
{
	public interface IArena
    {
        IDimension MaximumY { get; }
        IDimension MaximumX { get; }
	    IReadOnlyCollection<IRobot> Robots { get; }

	    IRobot AddRobot(IInitialiseRobotCommand command);
	    IRobot ReplaceRobot(IRobot current, IRobot replacement);
    }
}