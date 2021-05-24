namespace ToyRobotSimulator
{

    public record Action
    {
        public ActionType ActionType { get; init; }
        public IOrientation Facing { get; init; }
        public (uint X, uint Y) Position { get; init; }
    }
}