using System;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public class TableTop : ITableTop
    {
        private readonly IRobotFactory _robotFactory;
        private readonly (uint X, uint Y) _dimension;
        private readonly IMyOutput _output;
        private IRobot _robotPlaced;

        public TableTop(IRobotFactory robotFactory, (uint X, uint Y) dimension, IMyOutput output)
        {
            _robotFactory = robotFactory;
            _dimension = dimension;
            _output = output;
        }

        public async Task Execute(Action action)
        {
            if (ActionType.Place == action.ActionType)
            {
                if (action.Position.X >= _dimension.X
                    || action.Position.Y >= _dimension.Y)
                {
                    throw new RobotOutOfTableTopException();
                }

                _robotPlaced = await _robotFactory.Create(action.Position, action.Facing);
            }
            if(_robotPlaced is null) {return;}

            switch (action.ActionType)
            {
                case ActionType.Move:
                    _robotPlaced = _robotPlaced.Move(_dimension);
                    break;
                case ActionType.Left:
                    _robotPlaced = _robotPlaced.TurnLeft();
                    break;
                case ActionType.Right:
                    _robotPlaced = _robotPlaced.TurnRight();
                    break;
                case ActionType.Report:
                    await _output.Print(_robotPlaced.Report());
                    break;
            }
        }
    }
}