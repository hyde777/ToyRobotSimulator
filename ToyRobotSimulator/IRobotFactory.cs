using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public interface IRobotFactory
    {
        Task<IRobot> Create((uint, uint) position, Direction direction);
    }

    public class RobotFactory : IRobotFactory
    {
        public Task<IRobot> Create((uint, uint) position, Direction direction)
        {
            Dictionary<Direction, IOrientation> dictionary = new Dictionary<Direction, IOrientation>
            {
                {Direction.North, new North()},
                {Direction.South, new South()},
                {Direction.West, new West()},
                {Direction.East, new East()},
            };
            var robot = new Robot(position, dictionary[direction]);
            return Task.FromResult<IRobot>(robot);
        }
    }
}