using System.Collections.Generic;

namespace RobotWars.Interfaces
{
    public interface IBattleArena
    {
        int MaximumPositionY { get; }
        int MaximumPositionX { get; }
        IEnumerable<IRobot> Robots { get; }
        void AddRobot(IRobot robot);
        void UpdateRobotPosition(IRobot oldrobot, IRobot newRobot);
        bool PositionAvailable(IRobot robot);
    }
}