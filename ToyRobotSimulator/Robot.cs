using System;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public record Robot
    {
        private readonly (uint X, uint Y) _position;
        private readonly ICardinalite _direction;
        
        public Robot((uint, uint) position, ICardinalite direction)
        {
            _position = position;
            _direction = direction;
        }
        
        public Robot Move()
        {
            return new(_direction.CalculateMovement(_position), _direction);
        }

        public Robot TurnLeft()
        {
            return new(_position, new West());
        }
    }
}