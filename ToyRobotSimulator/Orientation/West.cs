namespace ToyRobotSimulator
{
    public record West : IOrientation
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x - 1, initial.y);
        }

        public IOrientation TurnAntiClockWise() => new South();
        public IOrientation TurnClockWise() => new North();
        public override string ToString() => "WEST";
    }
}