namespace ToyRobotSimulator
{
    public record Action
    {
        public ActionEnum Type { get; init; }
        public Direction Facing { get; init; }
        public (int X, int Y) Position { get; init; }
    }
}