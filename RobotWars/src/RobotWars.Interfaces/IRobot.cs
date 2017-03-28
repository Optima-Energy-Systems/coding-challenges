namespace RobotWars.Interfaces
{
    public interface IRobot
    {
        int PositionY { get; }
        int PositionX { get; }
        IOrientation Orientation { get; }
        IRobot Move();
        IRobot Turn(IRobotTurnCommand command);
    }
}