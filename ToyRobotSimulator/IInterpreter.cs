namespace ToyRobotSimulator
{
    public interface IInterpreter
    {
        Action Convert(string line);
    }
}