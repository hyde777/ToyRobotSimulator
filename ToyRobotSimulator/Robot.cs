using System;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public record Robot
    {
        private readonly (uint X, uint Y) _position;
        private readonly Direction _direction;
        
        public Robot((uint, uint) position, Direction direction)
        {
            _position = position;
            _direction = direction;
        }
        
        public Robot Move()
        {
            if (Direction.North == _direction)
            {
                return new Robot((_position.X + 1, _position.Y), _direction);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}