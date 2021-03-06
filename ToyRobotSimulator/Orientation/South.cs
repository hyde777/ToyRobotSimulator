namespace ToyRobotSimulator
{
    public record South : IOrientation
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x, initial.y - 1);
        }

        public IOrientation TurnAntiClockWise() => new East();
        public IOrientation TurnClockWise() => new West();

        public override string ToString() => "SOUTH";
    }
}