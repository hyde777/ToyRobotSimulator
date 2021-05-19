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
        
        
        [Test]
        public void ConvertMoveInStructuredData()
        {
            IInterpreter interpreter = new CommandInterpreter();

            var convert = interpreter.Convert("MOVE");

            convert.Should().Be(new Action
            {
                Type = ActionEnum.Move,
            });
        }

        [Test]
        public void ConvertReportInStructuredData()
        {
            IInterpreter interpreter = new CommandInterpreter();

            var convert = interpreter.Convert("REPORT");

            convert.Should().Be(new Action
            {
                Type = ActionEnum.Report,
            });
        }
    }
}