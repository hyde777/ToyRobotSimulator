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
    }

    public interface ICardinalite
    {
        (uint, uint) CalculateMovement((uint x, uint y) initial);
    }

    public class South : ICardinalite
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x - 1, initial.y);
        }
    }

    public class North : ICardinalite
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x + 1, initial.y);
        }
    }

    public class West : ICardinalite
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x, initial.y - 1);
        }
    }
}