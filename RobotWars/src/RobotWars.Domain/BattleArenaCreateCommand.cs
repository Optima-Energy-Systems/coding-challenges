using System;
using RobotWars.Interfaces;

namespace RobotWars.Domain
{
    public class BattleArenaCreateCommand : IBattleArenaCreateCommand
    {
        public int MaximumPositionX { get; }

        public int MaximumPositionY { get; }

        public BattleArenaCreateCommand(int maximumX, int maximumY)
        {
            if (maximumX <= 0)
                throw new ArgumentOutOfRangeException(nameof(maximumX), "Must be greater than zero");
            if (maximumY <= 0)
                throw new ArgumentOutOfRangeException(nameof(maximumY), "Must be greater than zero");

            MaximumPositionX = maximumX;
            MaximumPositionY = maximumY;
        }
    }
}