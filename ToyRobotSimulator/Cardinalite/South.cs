﻿namespace ToyRobotSimulator
{
    public class South : ICardinalite
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x - 1, initial.y);
        }

        public ICardinalite TurnAntiClockWise()
        {
            throw new System.NotImplementedException();
        }
    }
}