namespace ToyRobotSimulator
{
    public record West : ICardinalite
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x, initial.y - 1);
        }

        public ICardinalite TurnAntiClockWise() => new South();
    }
}