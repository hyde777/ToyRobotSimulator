using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface IMyOutput
    {
        Task Print(string text);
    }
}