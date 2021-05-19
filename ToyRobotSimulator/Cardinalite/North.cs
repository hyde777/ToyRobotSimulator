namespace ToyRobotSimulator
{
    public class North : IOrientation
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x, initial.y + 1);
        }

        public IOrientation TurnAntiClockWise() => new West();
        public IOrientation TurnClockWise() => new East();
        public override string ToString()
        {
            return "NORTH";
        }
    }
}