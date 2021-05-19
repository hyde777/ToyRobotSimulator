namespace ToyRobotSimulator
{
    public interface IRobot
    {
        Robot Move((uint X, uint Y) availableSpace);
        Robot TurnLeft();
        Robot TurnRight();
        string Report();
    }
}