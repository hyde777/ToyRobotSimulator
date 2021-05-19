using System;
using FluentAssertions;
using NUnit.Framework;
using ToyRobotSimulator;
using Action = ToyRobotSimulator.Action;

namespace ToyRobotSimulatorTests
{
    public class InterpreterTests
    {
        [Test]
        public void ConvertPlaceInStructuredData()
        {
            IInterpreter interpreter = new CommandInterpreter();

            var convert = interpreter.Convert("PLACE 0,0,NORTH");

            convert.Should().Be(new Action
            {
                Type = ActionEnum.Place,
                Position = (0,0),
                Facing = Direction.North
            });
        }
    }
}