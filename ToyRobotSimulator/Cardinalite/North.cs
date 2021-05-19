namespace ToyRobotSimulator
{
    public class North : IOrientation
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x + 1, initial.y);
        }

        public IOrientation TurnAntiClockWise() => new West();
    }
}