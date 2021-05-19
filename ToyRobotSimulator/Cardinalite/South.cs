﻿namespace ToyRobotSimulator
{
    public class South : IOrientation
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x - 1, initial.y);
        }

        public IOrientation TurnAntiClockWise() => new East();
        public IOrientation TurnClockWise() => new West();
    }
}