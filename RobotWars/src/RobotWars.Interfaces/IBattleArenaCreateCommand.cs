namespace RobotWars.Interfaces
{
    public interface IBattleArenaCreateCommand : ICommand
    {
        int MaximumPositionY { get; }
        int MaximumPositionX { get; }
    }
}