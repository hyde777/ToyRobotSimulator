using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface IRobotFactory
    {
        Task<IRobot> Create((uint, uint) position, Direction direction);
    }
}