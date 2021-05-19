using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface ITableTop
    {
        Task<Robot> Place(Action action);
    }
}