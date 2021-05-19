namespace ToyRobotSimulator
{
    public record East : IOrientation
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x, initial.y + 1);
        }

        public IOrientation TurnAntiClockWise() => new North();
        public IOrientation TurnClockWise()
        {
            throw new System.NotImplementedException();
        }
    }
}