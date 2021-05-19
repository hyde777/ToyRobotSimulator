using System.Collections.Generic;

namespace ToyRobotSimulator
{
    public class CommandInterpreter : IInterpreter
    {
        private readonly string _separator;

        public CommandInterpreter()
        {
            _separator = " ";
        }

        public Action Convert(string line)
        {
            Dictionary<string, ActionEnum> dictionary = new Dictionary<string, ActionEnum>
            {
                {"PLACE", ActionEnum.Place},
                {"MOVE", ActionEnum.Move},
                {"REPORT", ActionEnum.Report},
                {"LEFT", ActionEnum.Left}
            };
            var TypeAndOther = line.Split(_separator);
            Action convert = new()
            {
                Type = dictionary[TypeAndOther[0]],
                Position = (0, 0),
                Facing = Direction.North
            };
            return convert;
        }
    }
}