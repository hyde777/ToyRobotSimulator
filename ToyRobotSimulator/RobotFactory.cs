using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public class RobotFactory : IRobotFactory
    {
        public Task<IRobot> Create((uint, uint) position, IOrientation direction)
        { 
            var robot = new Robot(position, direction);
            return Task.FromResult<IRobot>(robot);
        }
    }
}