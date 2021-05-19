using System.Collections.Generic;

namespace ToyRobotSimulator
{
    public class CommandInterpreter : IInterpreter
    {
        private const string PlaceSeparator = ",";
        private readonly string _separator;

        public CommandInterpreter()
        {
            _separator = " ";
        }

        public Action Convert(string line)
        {
            Dictionary<string, ActionType> actionTypes = new Dictionary<string, ActionType>
            {
                {"PLACE", ActionType.Place},
                {"MOVE", ActionType.Move},
                {"REPORT", ActionType.Report},
                {"LEFT", ActionType.Left},
                {"RIGHT", ActionType.Right}
            };
            var TypeAndOther = line.Split(_separator);
            var type = actionTypes[TypeAndOther[0]];
            if (type != ActionType.Place)
            {
                return new() {ActionType = type};
            }

            var other = TypeAndOther[1].Split(PlaceSeparator);
            var rawDirection = other[2];
            Dictionary<string, Direction> directions = new()
            {
                {"NORTH", Direction.North},
                {"SOUTH", Direction.South},
                {"WEST", Direction.West},
                {"EAST", Direction.East},
            };
            return new Action()
            {
                ActionType = actionTypes[TypeAndOther[0]],
                Position = (uint.Parse(other[0]), uint.Parse(other[1])),
                Facing = directions[rawDirection]
            };
        }
    }
}