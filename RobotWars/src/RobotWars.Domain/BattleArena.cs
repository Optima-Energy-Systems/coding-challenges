using System;
using System.Collections.Generic;
using System.Linq;
using RobotWars.Interfaces;

namespace RobotWars.Domain
{
    public class BattleArena : IBattleArena
    {
        public int MaximumPositionX { get; }

        public int MaximumPositionY { get; }

        public IEnumerable<IRobot> Robots => _robots.AsEnumerable();

        private List<IRobot> _robots = new List<IRobot>();

        public BattleArena(int maximumX, int maximumY)
        {
            if (maximumX < 0)
                throw new ArgumentOutOfRangeException(nameof(maximumX), "Must be greater than or equal to zero");
            if (maximumY < 0)
                throw new ArgumentOutOfRangeException(nameof(maximumY), "Must be greater than or equal to zero");

            MaximumPositionX = maximumX;
            MaximumPositionY = maximumY;
        }

        public void AddRobot(IRobot robot)
        {
            if (robot.PositionX > MaximumPositionX || robot.PositionY > MaximumPositionY)
                throw new IllegalMoveException("Robot placed outside the arena perimitter");

            if (!PositionAvailable(robot))
                throw new CollisionException($"A robot already exists at ({robot.PositionX},{robot.PositionY})");

            _robots.Add(robot);
        }

        public void UpdateRobotPosition(IRobot oldRobot, IRobot newRobot)
        {
            if (newRobot.PositionX > MaximumPositionX || newRobot.PositionY > MaximumPositionY)
                throw new IllegalMoveException("Robot strayed outside the arena perimitter");

            if (!PositionAvailable(newRobot))
                throw new CollisionException($"A robot already exists at ({newRobot.PositionX},{newRobot.PositionY})");

            _robots.Remove(oldRobot);
            _robots.Add(newRobot);
        }

        public bool PositionAvailable(IRobot robot)
        {
            IRobot existingRobot = _robots.Where(r => r.PositionX == robot.PositionX && r.PositionY == robot.PositionY).FirstOrDefault();
            return existingRobot == null;
        }
    }
}