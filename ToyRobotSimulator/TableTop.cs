using System;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public class TableTop : ITableTop
    {
        private readonly IRobotFactory _robotFactory;
        private readonly (uint X, uint Y) _dimension;
        private IRobot _robot;

        public TableTop(IRobotFactory robotFactory, (uint X, uint Y) dimension)
        {
            _robotFactory = robotFactory;
            _dimension = dimension;
        }

        public async Task Execute(Action action)
        {
            if (ActionEnum.Place == action.Type)
            {
                if (action.Position.X > _dimension.X
                    || action.Position.Y > _dimension.Y)
                {
                    throw new RobotOutOfTableTopException();
                }

                _robot = await _robotFactory.Create(action.Position, Direction.North);
            }

            if (ActionEnum.Move == action.Type)
            {
                _robot = _robot.Move();
            }

            if (ActionEnum.Left == action.Type)
            {
                _robot = _robot.TurnLeft();
            }
        }
    }
}