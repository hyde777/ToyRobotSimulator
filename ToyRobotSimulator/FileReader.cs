using System.Collections.Generic;
using System.IO;

namespace ToyRobotSimulator
{
    public class FileReader : IReader
    {
        public async IAsyncEnumerable<string> ReadFromFile(string filePath)
        {
            using var fileStream = File.OpenRead(filePath);
            using var reader = new StreamReader(fileStream);

            while (!reader.EndOfStream)
            {
                yield return await reader.ReadLineAsync();
            }
        }
    }
}