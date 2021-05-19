using FluentAssertions;
using NUnit.Framework;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTests
{
    public class CardinaliteTests
    {
        [Test]
        public void NorthShouldBeWestWhenTurnedAntiClockWise()
        {
            ICardinalite north = new North();

            var turnAntiClockWise = north.TurnAntiClockWise();

            turnAntiClockWise.Should().BeOfType<West>();
        }

        [Test]
        public void WestShouldBeSouthWhenTurnedAntiClockWise()
        {
            ICardinalite north = new West();

            var turnAntiClockWise = north.TurnAntiClockWise();

            turnAntiClockWise.Should().BeOfType<South>();
        }
        
        [Test]
        public void SouthShouldBeEastWhenTurnedAntiClockWise()
        {
            ICardinalite north = new South();

            var turnAntiClockWise = north.TurnAntiClockWise();

            turnAntiClockWise.Should().BeOfType<East>();
        }
        
    }
}