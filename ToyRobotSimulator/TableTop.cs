using System;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public class TableTop : ITableTop
    {
        private readonly IRobotFactory _robotFactory;
        private readonly (uint X, uint Y) _dimension;

        public TableTop(IRobotFactory robotFactory, (uint X, uint Y) dimension)
        {
            _robotFactory = robotFactory;
            _dimension = dimension;
        }

        public async Task<Robot> Place(Action action)
        {
            if (action.Type != ActionEnum.Place) throw new NotImplementedException();
            
            if (action.Position.X > _dimension.X 
                || action.Position.Y > _dimension.Y)
            {
                throw new RobotOutOfTableTopException();
            }

            return await _robotFactory.Create(action.Position, Direction.North);

        }
    }
}