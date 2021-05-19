namespace ToyRobotSimulator
{
    public record Action
    {
        public ActionEnum Type { get; init; }
        public Direction Facing { get; init; }
        public (uint X, uint Y) Position { get; init; }
    }
}