using System;
using System.Threading.Tasks;
using ToyRobotSimulator;

namespace ToyRobotSimulatorConsole
{
    public class MyConsoleOutput : IMyOutput
    {
        public async Task Print(string text)
        {
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
}