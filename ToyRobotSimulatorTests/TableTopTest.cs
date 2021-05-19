using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ToyRobotSimulator;
using Action = ToyRobotSimulator.Action;

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
            
            _tableTop.Place(new Action
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
            var outsideOfDimensionX = _dimensions.X + 1;
            var position = (dimensionsX: outsideOfDimensionX ,(uint)0);
            var action = new Action
            {
                Type = ActionEnum.Place,
                Position = position,
                Facing = direction
            };
            
            _tableTop.Place(action);
            
            _tableTop.Invoking(x => x.Place(action)).Should().Throw<RobotOutOfTableTopException>();
            _robotfactoryMock.Verify(x => x.Create(position, direction), Times.Never);
        }

        [Test]
        public void ShouldNotPlaceANewRobotWhenOutsideTableTopYDimension()
        {
            var direction = Direction.North;
            var outsideOfDimensionY = _dimensions.Y + 1;
            var position = ((uint)0 ,outsideOfDimensionY);
            var place = Place(position, direction);
            
            _tableTop.Place(place);
            
            _tableTop.Invoking(x => x.Place(place)).Should().Throw<RobotOutOfTableTopException>();
            _robotfactoryMock.Verify(x => x.Create(position, direction), Times.Never);
        }

        private static Action Place((uint, uint outsideOfDimensionY) position, Direction direction)
        {
            return new()
            {
                Type = ActionEnum.Place,
                Position = position,
                Facing = direction
            };
        }

        [Test]
        public void ShouldMoveRobotInTheDirectionNorthFacing()
        {
            var robot = new Robot(_southWestCorner, Direction.North);

            var movedRobot = robot.Move();

            movedRobot.Should().Be(new Robot((_southWestCorner.X + 1, _southWestCorner.Y), Direction.North));
        }

        [Test]
        public void ShouldMoveRobotInTheDirectionSouth()
        {
            (uint x, uint y) valueTuple = (2,0);
            var robot = new Robot(valueTuple, Direction.South);

            var movedRobot = robot.Move();

            movedRobot.Should().Be(new Robot((valueTuple.x - 1, valueTuple.y), Direction.South));
        }
    }
}