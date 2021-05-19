namespace ToyRobotSimulator
{
    public class CommandInterpreter : IInterpreter
    {
        public Action Convert(string placeNorth)
        {
            return new()
            {
                Type = ActionEnum.Place,
                Position = (0, 0),
                Facing = Direction.North
            };
        }
    }
}