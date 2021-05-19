namespace ToyRobotSimulator
{
    public record West : ICardinalite
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x, initial.y - 1);
        }
    }
}