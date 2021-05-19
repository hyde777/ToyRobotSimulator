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
                ActionType = ActionType.Place,
                Position = (0,0),
                Facing = Direction.North
            });
        }
        
        
        [Test]
        public void ConvertPlaceInStructuredDataWithSouth()
        {
            IInterpreter interpreter = new CommandInterpreter();

            var convert = interpreter.Convert("PLACE 0,0,SOUTH");

            convert.Should().Be(new Action
            {
                ActionType = ActionType.Place,
                Position = (0,0),
                Facing = Direction.South
            });
        }
        
        [Test]
        public void ConvertPlaceInStructuredDataWithDifferentXAndY()
        {
            IInterpreter interpreter = new CommandInterpreter();

            var convert = interpreter.Convert("PLACE 2,3,NORTH");

            convert.Should().Be(new Action
            {
                ActionType = ActionType.Place,
                Position = (2,3),
                Facing = Direction.North
            });
        }

        [TestCase("REPORT", ActionType.Report)]
        [TestCase("MOVE", ActionType.Move)]
        [TestCase("LEFT", ActionType.Left)]
        [TestCase("RIGHT", ActionType.Right)]
        public void ConvertReportInStructuredData(string action, ActionType actionType)
        {
            IInterpreter interpreter = new CommandInterpreter();

            var convert = interpreter.Convert(action);

            convert.Should().Be(new Action
            {
                ActionType = actionType,
            });
        }
    }
}