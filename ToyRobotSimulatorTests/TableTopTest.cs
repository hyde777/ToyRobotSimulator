using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTests
{
    public class TableTopTest
    {
        private readonly Mock<IRobotFactory> _robotfactoryMock;
        private readonly ITableTop _tableTop;
        private readonly (uint X, uint Y) _dimensions;
        private readonly (uint X, uint Y) _southWestCorner;

        public TableTopTest()
        {
            _robotfactoryMock = new Mock<IRobotFactory>();
            _dimensions = (5, 5);
            _tableTop = new TableTop(_robotfactoryMock.Object, _dimensions);
            _southWestCorner = ((uint)0,(uint)0);
        }

        [Test]
        public void ShouldPlaceANewRobotWhenPlaceIsOn()
        {
            var direction = Direction.North;
            var position = _southWestCorner;
            
            _tableTop.Execute(new Action
            {
                Type = ActionEnum.Place,
                Position = position,
                Facing = direction
            });
            
            _robotfactoryMock.Verify(x => x.Create(position, direction));
        }
        

        [Test]
        public void ShouldNotPlaceANewRobotWhenOutsideTableTopXDimension()
        {
            var direction = Direction.North;
            var position = _dimensions;
            var action = new Action
            {
                Type = ActionEnum.Place,
                Position = position,
                Facing = direction
            };
            
            _tableTop.Execute(action);
            
            _tableTop.Invoking(x => x.Execute(action)).Should().Throw<RobotOutOfTableTopException>();
            _robotfactoryMock.Verify(x => x.Create(position, direction), Times.Never);
        }

        [Test]
        public void ShouldNotPlaceANewRobotWhenOutsideTableTopYDimension()
        {
            var direction = Direction.North;
            var outsideOfDimensionY = _dimensions.Y + 1;
            var position = ((uint)0 ,outsideOfDimensionY);
            var place = Place(position, direction);
            
            _tableTop.Execute(place);
            
            _tableTop.Invoking(x => x.Execute(place)).Should().Throw<RobotOutOfTableTopException>();
            _robotfactoryMock.Verify(x => x.Create(position, direction), Times.Never);
        }

        private Action Place((uint, uint outsideOfDimensionY) position, Direction direction)
        {
            return new()
            {
                Type = ActionEnum.Place,
                Position = position,
                Facing = direction
            };
        }

        [Test]
        public void ShouldMoveOnceIfPlacedBeforeHand()
        {
            var mock = new Mock<IRobot>();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, Direction.North))
                .Returns(Task.FromResult(mock.Object));
            _tableTop.Execute(Place(_southWestCorner, Direction.North));

            _tableTop.Execute(new Action {Type = ActionEnum.Move});

            mock.Verify(rob => rob.Move(_dimensions), Times.Once);
        }

        [Test]
        public void ShouldTurnLeftIfPlacedBeforeHand()
        {
            var mock = new Mock<IRobot>();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, Direction.North))
                .Returns(Task.FromResult(mock.Object));
            _tableTop.Execute(Place(_southWestCorner, Direction.North));

            _tableTop.Execute(new Action {Type = ActionEnum.Left});

            mock.Verify(rob => rob.TurnLeft(), Times.Once);
        }

        [Test]
        public void ShouldTurnRightIfPlacedBeforeHand()
        {
            var mock = new Mock<IRobot>();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, Direction.North))
                .Returns(Task.FromResult(mock.Object));
            _tableTop.Execute(Place(_southWestCorner, Direction.North));

            _tableTop.Execute(new Action {Type = ActionEnum.Right});

            mock.Verify(rob => rob.TurnRight(), Times.Once);
        }

        [Test]
        public void SHouldDoNothingIfRobotNotPlaced()
        {
            var mock = new Mock<IRobot>();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, Direction.North))
                .Returns(Task.FromResult(mock.Object));

            _tableTop.Execute(new Action {Type = ActionEnum.Right});
            _tableTop.Execute(new Action {Type = ActionEnum.Move});
            _tableTop.Execute(new Action {Type = ActionEnum.Left});

            mock.Verify(rob => rob.TurnRight(), Times.Never);
            mock.Verify(rob => rob.TurnLeft(), Times.Never);
            mock.Verify(rob => rob.Move(_dimensions), Times.Never);
        }
    }
}