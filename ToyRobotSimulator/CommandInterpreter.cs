using System.Collections.Generic;

namespace ToyRobotSimulator
{
    public class CommandInterpreter : IInterpreter
    {
        public Action Convert(string placeNorth)
        {
            Dictionary<string, ActionEnum> dictionary = new Dictionary<string, ActionEnum>
            {
                {"PLACE", ActionEnum.Place},
                {"MOVE", ActionEnum.Move},
                {"REPORT", ActionEnum.Report}
            };
            var TypeAndOther = placeNorth.Split(" ");
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