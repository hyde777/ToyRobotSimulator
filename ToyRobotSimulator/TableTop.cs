﻿using System;
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
            if (ActionEnum.Place == action.Type)
            {
                if (action.Position.X >= _dimension.X
                    || action.Position.Y >= _dimension.Y)
                {
                    throw new RobotOutOfTableTopException();
                }

                _robotPlaced = await _robotFactory.Create(action.Position, Direction.North);
            }
            if(_robotPlaced is null) {return;}

            switch (action.Type)
            {
                case ActionEnum.Move:
                    _robotPlaced = _robotPlaced.Move(_dimension);
                    break;
                case ActionEnum.Left:
                    _robotPlaced = _robotPlaced.TurnLeft();
                    break;
                case ActionEnum.Right:
                    _robotPlaced = _robotPlaced.TurnRight();
                    break;
                case ActionEnum.Report:
                    _output.Print(_robotPlaced.Report());
                    break;
            }
        }
    }
}