using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface IRobotFactory
    {
        Task<Robot> Create((int, int) position, Direction direction);
    }
}