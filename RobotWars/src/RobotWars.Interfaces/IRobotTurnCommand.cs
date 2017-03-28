namespace RobotWars.Interfaces
{
    public interface IRobotTurnCommand : ICommand
    {
        IDirection TurnDirection { get; }
    }
}