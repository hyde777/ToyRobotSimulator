using System.IO;
using Moq;
using NUnit.Framework;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTests
{
    public class ToyRobotSimulatorAcceptances
    {
        public ToyRobotSimulatorAcceptances((uint X, uint Y) valueTuple)
        {
            _valueTuple = valueTuple;
        }

        private (uint X, uint Y) _valueTuple;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AcceptanceExampleATest()
        {
            var mock = new Mock<IMyOutput>();
            ITableTop tabletop = new TableTop(Mock.Of<IRobotFactory>(), _valueTuple);
            IReader reader = new FileReader();
            IInterpreter interpreter = new CommandInterpreter();
            IToyRobotSimulator trs = new ToyRobotSimulator.ToyRobotSimulator(mock.Object, reader, tabletop, interpreter);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ExampleA.txt");
            
            trs.Command(filePath);
            
            mock.Verify(x => x.Print("0,1,NORTH"));
        }
    }
}