namespace RobotWars.Interfaces
{
    public interface IRobotCreateCommand : ICommand
    {
        int PositionX { get; }
        int PositionY { get; }
        IOrientation Orientation { get; }
    }
}