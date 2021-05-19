namespace ToyRobotSimulator
{
    public interface IOrientation
    {
        (uint, uint) CalculateMovement((uint x, uint y) initial);
        IOrientation TurnAntiClockWise();
    }
}