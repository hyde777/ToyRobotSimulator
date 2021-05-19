using System;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface IRobot
    {
        Robot Move((uint X, uint Y) valueTuple);
        Robot TurnLeft();
        Robot TurnRight();
        void Report();
    }

    public record Robot : IRobot
    {
        private readonly (uint X, uint Y) _position;
        private readonly IOrientation _direction;
        
        public Robot((uint, uint) position, IOrientation direction)
        {
            _position = position;
            _direction = direction;
        }
        
        public Robot Move((uint X, uint Y) availableSpace)
        {
            (uint x, uint y) newMovement = _direction.CalculateMovement(_position);
            if (newMovement.x >= availableSpace.X || newMovement.y >= availableSpace.Y)
            {
                return this;
            }
            return new(newMovement, _direction);
        }

        public Robot TurnLeft() => new(_position, _direction.TurnAntiClockWise());

        public Robot TurnRight() => new(_position, _direction.TurnClockWise());
        public void Report()
        {
            throw new NotImplementedException();
        }
    }
}