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
                {"LEFT", ActionEnum.Left},
                {"RIGHT", ActionEnum.Right}
            };
            var TypeAndOther = line.Split(_separator);

            var action = dictionary[TypeAndOther[0]];
            if (action != ActionEnum.Place)
            {
                return new() {Type = action};
            }

            var other = TypeAndOther[1].Split(",");
            
            return new Action()
            {
                Type = dictionary[TypeAndOther[0]],
                Position = (uint.Parse(other[0]), uint.Parse(other[1])),
                Facing = Direction.North
            };
        }
    }
}