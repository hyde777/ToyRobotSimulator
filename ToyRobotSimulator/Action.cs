namespace ToyRobotSimulator
{

    public record Action
    {
        public ActionType ActionType { get; init; }
        public Direction Facing { get; init; }
        public (uint X, uint Y) Position { get; init; }
    }
}