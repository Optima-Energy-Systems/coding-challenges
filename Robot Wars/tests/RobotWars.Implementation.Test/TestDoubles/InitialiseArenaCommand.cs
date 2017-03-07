using Moq;
using RobotWars.Interface;

namespace RobotWars.Implementation.Test.TestDoubles
{
	internal class InitialiseArenaCommand : IInitialiseArenaCommand
	{
		public InitialiseArenaCommand(
			int maximumX,
			int maximumY)
		{
			MaximumX = Mock.Of<IDimension>(dimension => dimension.Value == maximumX);
			MaximumY = Mock.Of<IDimension>(dimension => dimension.Value == maximumY);
		}

		public IDimension MaximumY { get; }
		public IDimension MaximumX { get; }
	}
}
