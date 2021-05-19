using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface ITableTop
    {
        Task Execute(Action action);
    }
}