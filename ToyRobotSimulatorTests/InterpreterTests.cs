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
        public void ConvertPlaceInStructuredDataBis()
        {
            IInterpreter interpreter = new CommandInterpreter();

            var convert = interpreter.Convert("PLACE 2,3,NORTH");

            convert.Should().Be(new Action
            {
                Type = ActionEnum.Place,
                Position = (2,3),
                Facing = Direction.North
            });
        }

        [TestCase("REPORT", ActionEnum.Report)]
        [TestCase("MOVE", ActionEnum.Move)]
        [TestCase("LEFT", ActionEnum.Left)]
        [TestCase("RIGHT", ActionEnum.Right)]
        public void ConvertReportInStructuredData(string action, ActionEnum enumAction)
        {
            IInterpreter interpreter = new CommandInterpreter();

            var convert = interpreter.Convert(action);

            convert.Should().Be(new Action
            {
                Type = enumAction,
            });
        }
    }
}