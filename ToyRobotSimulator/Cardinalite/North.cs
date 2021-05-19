namespace ToyRobotSimulator
{
    public class North : ICardinalite
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x + 1, initial.y);
        }
    }
}