using FluentAssertions;
using NUnit.Framework;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTests
{
    public class RobotTests
    {
        
        [Test]
        public void ShouldMoveRobotInTheNorth()
        {
            (uint x, uint y) position = (2,0);
            var cardinalite = new North();
            var robot = new Robot(position, cardinalite);

            var movedRobot = robot.Move();

            movedRobot.Should().Be(new Robot((position.x + 1, position.y), cardinalite));
        }

        [Test]
        public void ShouldMoveRobotInTheSouth()
        {
            (uint x, uint y) position = (2,0);
            var cardinalite = new South();
            var robot = new Robot(position, cardinalite);

            var movedRobot = robot.Move();

            movedRobot.Should().Be(new Robot((position.x - 1, position.y), cardinalite));
        }

        [Test]
        public void ShouldMoveRobotInTheWest()
        {
            (uint x, uint y) position = (0,2);
            var cardinalite = new West();
            var robot = new Robot(position, cardinalite);

            var movedRobot = robot.Move();

            movedRobot.Should().BeEquivalentTo(new Robot((position.x, position.y - 1), cardinalite));
        } 
        
        [Test]
        public void ShouldMoveRobotInEast()
        {
            (uint x, uint y) position = (0,2);
            var cardinalite = new East();
            var robot = new Robot(position, cardinalite);

            var movedRobot = robot.Move();

            movedRobot.Should().BeEquivalentTo(new Robot((position.x, position.y + 1), cardinalite));
        }
    }
}