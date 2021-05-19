using System.IO;
using Moq;
using NUnit.Framework;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTests
{
    public class ToyRobotSimulatorAcceptances
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AcceptanceExampleATest()
        {
            var mock = new Mock<IMyOutput>();
            ITableTop tabletop = new TableTop(Mock.Of<IRobotFactory>());
            IReader reader = new FileReader();
            IInterpreter interpreter = new CommandInterpreter();
            IToyRobotSimulator trs = new ToyRobotSimulator.ToyRobotSimulator(mock.Object, reader, tabletop, interpreter);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ExampleA.txt");
            
            trs.Command(filePath);
            
            mock.Verify(x => x.Print("0,1,NORTH"));
        }
    }
}