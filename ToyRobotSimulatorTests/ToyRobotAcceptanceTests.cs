using System.IO;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTests
{
    public class ToyRobotSimulatorAcceptances
    {
        public ToyRobotSimulatorAcceptances()
        {
            _valueTuple = (5,5);
        }

        private (uint X, uint Y) _valueTuple;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task AcceptanceExampleATest()
        {
            var mock = new Mock<IMyOutput>();
            ITableTop tabletop = new TableTop(new RobotFactory(), _valueTuple, mock.Object);
            IReader reader = new FileReader();
            IInterpreter interpreter = new CommandInterpreter();
            IToyRobotSimulator trs = new ToyRobotSimulator.ToyRobotSimulator(reader, tabletop, interpreter);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ExampleA.txt");
            
            await trs.Command(filePath);
            
            mock.Verify(x => x.Print("0,1,NORTH"));
        }
        
        [Test]
        public async Task AcceptanceExampleBTest()
        {
            var mock = new Mock<IMyOutput>();
            ITableTop tabletop = new TableTop(new RobotFactory(), _valueTuple, mock.Object);
            IReader reader = new FileReader();
            IInterpreter interpreter = new CommandInterpreter();
            IToyRobotSimulator trs = new ToyRobotSimulator.ToyRobotSimulator(reader, tabletop, interpreter);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ExampleB.txt");
            
            await trs.Command(filePath);
            
            mock.Verify(x => x.Print("0,0,WEST"));
        }
    }
}