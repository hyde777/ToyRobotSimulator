namespace ToyRobotSimulator
{
    public record East : IOrientation
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x + 1, initial.y);
        }

        public IOrientation TurnAntiClockWise() => new North();
        public IOrientation TurnClockWise() => new South();

        public override string ToString() => "EAST";
    }
}