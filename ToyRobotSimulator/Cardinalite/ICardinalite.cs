namespace ToyRobotSimulator
{
    public interface ICardinalite
    {
        (uint, uint) CalculateMovement((uint x, uint y) initial);
    }
}