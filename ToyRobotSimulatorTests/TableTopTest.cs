using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTests
{
    public class TableTopTest
    {
        private Mock<IRobotFactory> _robotfactoryMock;
        private ITableTop _tableTop;
        private (uint X, uint Y) _dimensions;
        private (uint X, uint Y) _southWestCorner;
        private IMyOutput _mockObject;

        public TableTopTest()
        {
           
        }

        [SetUp]
        public void Setup()
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
            var direction = new North();
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
        public void ShouldPlaceANewRobotWhenPlaceIsOnBis()
        {
            var direction = new South();
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
        public void ShouldIgnoreANewRobotWhenOutsideTableTopXDimension()
        {
            var direction = new North();
            var position = _dimensions;
            var action = new Action
            {
                ActionType = ActionType.Place,
                Position = position,
                Facing = direction
            };
            
            _tableTop.Execute(action);
            
            _robotfactoryMock.Verify(x => x.Create(position, direction), Times.Never);
        }

        [Test]
        public void ShouldIgnorePlaceANewRobotWhenOutsideTableTopYDimension()
        {
            var direction = new North();
            var outsideOfDimensionY = _dimensions.Y + 1;
            var position = ((uint)0 ,outsideOfDimensionY);
            var place = Place(position, direction);
            
            _tableTop.Execute(place);
            
            _robotfactoryMock.Verify(x => x.Create(position, direction), Times.Never);
        }

        private Action Place((uint, uint outsideOfDimensionY) position, IOrientation direction)
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
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, new North()))
                .Returns(Task.FromResult(mock.Object));
            _tableTop.Execute(Place(_southWestCorner, new North()));

            _tableTop.Execute(new Action {ActionType = ActionType.Move});

            mock.Verify(rob => rob.Move(_dimensions), Times.Once);
        }

        [Test]
        public void ShouldTurnLeftIfPlacedBeforeHand()
        {
            var mock = new Mock<IRobot>();
            var direction = new North();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, direction))
                .Returns(Task.FromResult(mock.Object));
            _tableTop.Execute(Place(_southWestCorner, direction));

            _tableTop.Execute(new Action {ActionType = ActionType.Left});

            mock.Verify(rob => rob.TurnLeft(), Times.Once);
        }

        [Test]
        public void ShouldTurnRightIfPlacedBeforeHand()
        {
            var mock = new Mock<IRobot>();
            var direction = new North();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, direction))
                .Returns(Task.FromResult(mock.Object));
            _tableTop.Execute(Place(_southWestCorner, direction));

            _tableTop.Execute(new Action {ActionType = ActionType.Right});

            mock.Verify(rob => rob.TurnRight(), Times.Once);
        }

        [Test]
        public void SHouldDoNothingIfRobotNotPlaced()
        {
            var mock = new Mock<IRobot>();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, new North()))
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
            var direction = new North();
            _robotfactoryMock.Setup(x => x.Create(_southWestCorner, direction))
                .Returns(Task.FromResult(mock.Object));
            _tableTop.Execute(Place(_southWestCorner, direction));

            _tableTop.Execute(new Action {ActionType = ActionType.Report});

            mock.Verify(rob => rob.Report(), Times.Once);

        }
    }
}