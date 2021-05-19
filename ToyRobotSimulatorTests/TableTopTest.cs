using Moq;
using NUnit.Framework;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTests
{
    public class TableTopTest
    {
        [Test]
        public void METHOD()
        {
            var mock = new Mock<IRobotFactory>();
            IRobotFactory robotFactory = mock.Object;
            ITableTop tableTop = new TableTop(robotFactory);

            var direction = Direction.North;
            var position = (0,0);
            tableTop.Execute(new Action
            {
                Type = ActionEnum.Place,
                Position = position,
                Facing = direction
            });
            
            mock.Verify(x => x.Create(position, direction));
        }
    }
}