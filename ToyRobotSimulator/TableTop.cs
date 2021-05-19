using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public class TableTop : ITableTop
    {
        private readonly IRobotFactory _robotFactory;

        public TableTop(IRobotFactory robotFactory)
        {
            _robotFactory = robotFactory;
        }

        public async Task Execute(Action action)
        {
            await _robotFactory.Create(action.Position, Direction.North);
        }
    }
}