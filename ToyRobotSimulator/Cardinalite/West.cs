namespace ToyRobotSimulator
{
    public record West : IOrientation
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x, initial.y - 1);
        }

        public IOrientation TurnAntiClockWise() => new South();
        public IOrientation TurnClockWise() => new North();
    }
}