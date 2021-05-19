using FluentAssertions;
using NUnit.Framework;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTests
{
    public class OrientationTests
    {
        [Test]
        public void NorthShouldBeWestWhenTurnedAntiClockWise()
        {
            IOrientation north = new North();

            var turnAntiClockWise = north.TurnAntiClockWise();

            turnAntiClockWise.Should().BeOfType<West>();
        }

        [Test]
        public void WestShouldBeSouthWhenTurnedAntiClockWise()
        {
            IOrientation west = new West();

            var turnAntiClockWise = west.TurnAntiClockWise();

            turnAntiClockWise.Should().BeOfType<South>();
        }
        
        [Test]
        public void SouthShouldBeEastWhenTurnedAntiClockWise()
        {
            IOrientation south = new South();

            var turnAntiClockWise = south.TurnAntiClockWise();

            turnAntiClockWise.Should().BeOfType<East>();
        }

        [Test]
        public void EastShouldBeNorthWhenTurnedAntiClockWise()
        {
            IOrientation east = new East();

            var turnAntiClockWise = east.TurnAntiClockWise();

            turnAntiClockWise.Should().BeOfType<North>();
        }

        [Test]
        public void NorthShouldBeEastWhenTurnedClockWise()
        {
            IOrientation north = new North();

            var turnAntiClockWise = north.TurnClockWise();

            turnAntiClockWise.Should().BeOfType<East>();
        }
    }
}