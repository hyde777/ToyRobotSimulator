using FluentAssertions;
using Moq;
using NUnit.Framework;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTests
{
    public class RobotTests
    {
        private readonly (uint x, uint y) avalableSpace;

        public RobotTests()
        {
            avalableSpace = (8,8);
        }

        [Test]
        public void ShouldMoveRobotInTheNorth()
        {
            (uint x, uint y) position = (2,0);
            var cardinalite = new North();
            var robot = new Robot(position, cardinalite);

            var movedRobot = robot.Move(avalableSpace);

            movedRobot.Should().Be(new Robot((position.x, position.y + 1), cardinalite));
        }

        [Test]
        public void ShouldMoveRobotInTheSouth()
        {
            (uint x, uint y) position = (2,2);
            var cardinalite = new South();
            var robot = new Robot(position, cardinalite);

            var movedRobot = robot.Move(avalableSpace);

            movedRobot.Should().Be(new Robot((position.x, position.y - 1), cardinalite));
        }

        [Test]
        public void ShouldMoveRobotInTheWest()
        {
            (uint x, uint y) position = (2,2);
            var cardinalite = new West();
            var robot = new Robot(position, cardinalite);

            var movedRobot = robot.Move(avalableSpace);

            movedRobot.Should().BeEquivalentTo(new Robot((position.x - 1, position.y), cardinalite));
        } 
        
        [Test]
        public void ShouldMoveRobotInEast()
        {
            (uint x, uint y) position = (0,2);
            var cardinalite = new East();
            var robot = new Robot(position, cardinalite);

            var movedRobot = robot.Move(avalableSpace);

            movedRobot.Should().BeEquivalentTo(new Robot((position.x + 1, position.y), cardinalite));
        }
        
        [Test]
        public void IfRobotIsOutOfBoundAfterMoveNorthThrowException()
        {
            var robot = new Robot((avalableSpace.x - 1, avalableSpace.y - 1), new North());

            var robotDidNothing = robot.Move(avalableSpace);
            
            robotDidNothing.Should().BeEquivalentTo(robot);
        }
        [Test]
        public void IfRobotIsOutOfBoundAfterMoveEastThrowException()
        {
            var robot = new Robot((avalableSpace.x - 1, avalableSpace.y - 1), new East());

            var robotDidNothing = robot.Move(avalableSpace);
            
            robotDidNothing.Should().BeEquivalentTo(robot);
        }

        [Test]
        public void ShouldTurnRobotAntiClockWiseWhenLeft()
        {
            (uint x, uint y) position = (0,2);
            var orientation = new Mock<IOrientation>();
            var robot = new Robot(position, orientation.Object);

            robot.TurnLeft();
            
            orientation.Verify(x => x.TurnAntiClockWise(), Times.Once);
        }

        [Test]
        public void ShouldTurnRobotClockWiseWhenRight()
        {
            (uint x, uint y) position = (0,2);
            var orientation = new Mock<IOrientation>();
            var robot = new Robot(position, orientation.Object);

            robot.TurnRight();
            
            orientation.Verify(x => x.TurnClockWise(), Times.Once);
        }

        [Test]
        public void ShouldReport()
        {
            (uint x, uint y) position = (0,2);
            var robot = new Robot(position, new North());

            var report = robot.Report();

            report.Should().Be("0,2,NORTH");
        }
        
        [Test]
        public void ShouldReportBis()
        {
            (uint x, uint y) position = (3,4);
            var robot = new Robot(position, new West());

            var report = robot.Report();

            report.Should().Be("3,4,WEST");
        }
    }
}