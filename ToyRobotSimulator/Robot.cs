namespace ToyRobotSimulator
{
    public class Robot
    {
        private readonly (int X, int Y) _position;
        private readonly Direction _direction;

        public Robot((int, int) position, Direction direction)
        {
            _position = position;
            _direction = direction;
        }
    }
}