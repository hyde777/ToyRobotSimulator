using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface IToyRobotSimulator
    {
        Task Command(string filePath);
    }
}