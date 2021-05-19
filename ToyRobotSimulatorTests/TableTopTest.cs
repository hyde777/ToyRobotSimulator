using FluentAssertions;
using Moq;
using NUnit.Framework;
using ToyRobotSimulator;
using Action = ToyRobotSimulator.Action;

namespace ToyRobotSimulatorTests
{
    public class TableTopTest
    {
        private readonly Mock<IRobotFactory> _mock;
        private readonly ITableTop _tableTop;
        private readonly (uint X, uint Y) _dimensions;

        public TableTopTest()
        {
            _mock = new Mock<IRobotFactory>();
            _dimensions = (5, 5);
            _tableTop = new TableTop(_mock.Object, _dimensions);
        }

        [Test]
        public void ShouldCreateANewRobotWhenPlaceIsOn()
        {
            var direction = Direction.North;
            var position = ((uint)0,(uint)0);
            
            _tableTop.Execute(new Action
            {
                Type = ActionEnum.Place,
                Position = position,
                Facing = direction
            });
            
            _mock.Verify(x => x.Create(position, direction));
        }

        [Test]
        public void ShouldNotCreateANewRobotWhenOutsideTableTopXDimension()
        {
            var direction = Direction.North;
            var outsideOfDimensionX = _dimensions.X + 1;
            var position = (dimensionsX: outsideOfDimensionX ,(uint)0);
            var action = new Action
            {
                Type = ActionEnum.Place,
                Position = position,
                Facing = direction
            };
            
            _tableTop.Execute(action);
            
            _tableTop.Invoking(x => x.Execute(action)).Should().Throw<RobotOutOfTableTopException>();
            _mock.Verify(x => x.Create(position, direction), Times.Never);
        }

        [Test]
        public void ShouldNotCreateANewRobotWhenOutsideTableTopYDimension()
        {
            var direction = Direction.North;
            var outsideOfDimensionY = _dimensions.Y + 1;
            var position = ((uint)0 ,outsideOfDimensionY);
            var action = new Action
            {
                Type = ActionEnum.Place,
                Position = position,
                Facing = direction
            };
            
            _tableTop.Execute(action);
            
            _tableTop.Invoking(x => x.Execute(action)).Should().Throw<RobotOutOfTableTopException>();
            _mock.Verify(x => x.Create(position, direction), Times.Never);

        }
    }
}