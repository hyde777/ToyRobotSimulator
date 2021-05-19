﻿namespace ToyRobotSimulator
{
    public record East : ICardinalite
    {
        public (uint, uint) CalculateMovement((uint x, uint y) initial)
        {
            return (initial.x, initial.y + 1);
        }
    }
}