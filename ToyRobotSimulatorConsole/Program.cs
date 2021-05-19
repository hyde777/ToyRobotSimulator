using System;
using ToyRobotSimulator;
using ToyRobotSimulatorConsole;


(uint X, uint Y) dimension = (5, 5);
IMyOutput consoleOutput = new MyConsoleOutput();
ITableTop tabletop = new TableTop(new RobotFactory(), dimension, consoleOutput);
IReader reader = new FileReader();
IInterpreter interpreter = new CommandInterpreter();
try
{
    IToyRobotSimulator trs = new ToyRobotSimulator.ToyRobotSimulator(reader, tabletop, interpreter);
    string filepath = args[0];
    trs.Command(filepath);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}