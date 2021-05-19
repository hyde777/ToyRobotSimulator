using System.Collections.Generic;

namespace ToyRobotSimulator
{
    public interface IReader
    {
        IAsyncEnumerable<string> ReadFromFile(string filePath);
    }
}