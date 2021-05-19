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
        private IMyOutput _mockObject;

        public TableTopTest()
        {
            _robotfactoryMock = new Mock<IRobotFactory>();
            _dimensions = (5, 5);
            _tableTop = new TableTop(_robotfactoryMock.Object, _dimensions, _mockObject);
            _southWestCorner = ((uint)0,(uint)0);
            _mockObject = new Mock<IMyOutput>().Object;
        }

        [Test]
        public void ShouldPlaceANewRobotWhenPlaceIsOn()
        {
            var direction = Direction.North;
            var position = _southWestCorner;
            
            _tableTop.Execute(new Action
            {
                ActionType = ActionType.Place,
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
                ActionType = ActionType.Place,
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
                ActionType = ActionType.Place,
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

            _tableTop.Execute(new Action {ActionType = ActionType.Move});

            mock.Verify(rob => rob.Move(_dimensions), Times.Once);
        }

        [Test]
        public void ShouldTurnLeftIfPlacedBeforeHand()
        {
            var mock = new Mock<IRobot>();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, Direction.North))
                .Returns(Task.FromResult(mock.Object));
            _tableTop.Execute(Place(_southWestCorner, Direction.North));

            _tableTop.Execute(new Action {ActionType = ActionType.Left});

            mock.Verify(rob => rob.TurnLeft(), Times.Once);
        }

        [Test]
        public void ShouldTurnRightIfPlacedBeforeHand()
        {
            var mock = new Mock<IRobot>();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, Direction.North))
                .Returns(Task.FromResult(mock.Object));
            _tableTop.Execute(Place(_southWestCorner, Direction.North));

            _tableTop.Execute(new Action {ActionType = ActionType.Right});

            mock.Verify(rob => rob.TurnRight(), Times.Once);
        }

        [Test]
        public void SHouldDoNothingIfRobotNotPlaced()
        {
            var mock = new Mock<IRobot>();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, Direction.North))
                .Returns(Task.FromResult(mock.Object));

            _tableTop.Execute(new Action {ActionType = ActionType.Right});
            _tableTop.Execute(new Action {ActionType = ActionType.Move});
            _tableTop.Execute(new Action {ActionType = ActionType.Left});

            mock.Verify(rob => rob.TurnRight(), Times.Never);
            mock.Verify(rob => rob.TurnLeft(), Times.Never);
            mock.Verify(rob => rob.Move(_dimensions), Times.Never);
            mock.Verify(rob => rob.Report(), Times.Never);
        }

        [Test]
        public void ReportIfAskedAboutIt()
        {
            var mock = new Mock<IRobot>();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, Direction.North))
                .Returns(Task.FromResult(mock.Object));
            _tableTop.Execute(Place(_southWestCorner, Direction.North));

            _tableTop.Execute(new Action {ActionType = ActionType.Report});

            mock.Verify(rob => rob.Report(), Times.Once);

        }
    }
}