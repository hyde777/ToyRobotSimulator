using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface IRobotFactory
    {
        Task<Robot> Create((uint, uint) position, Direction direction);
    }
}