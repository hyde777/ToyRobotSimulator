using System;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public record Robot
    {
        private readonly (uint X, uint Y) _position;
        private readonly IOrientation _direction;
        
        public Robot((uint, uint) position, IOrientation direction)
        {
            _position = position;
            _direction = direction;
        }
        
        public Robot Move()
        {
            return new(_direction.CalculateMovement(_position), _direction);
        }

        public Robot TurnLeft() => new(_position, _direction.TurnAntiClockWise());

        public Robot TurnRight() => new(_position, _direction.TurnAntiClockWise());
    }
}