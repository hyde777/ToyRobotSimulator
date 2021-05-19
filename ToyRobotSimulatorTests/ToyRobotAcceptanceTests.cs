using System.IO;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

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
            ITableTop tabletop = new TableTop();
            IReader reader = new FileReader();
            IToyRobotSimulator trs = new ToyRobotSimulator(mock.Object, reader, tabletop);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ExampleA.txt");
            
            trs.Command(filePath);
            
            mock.Verify(x => x.Print("0,1,NORTH"));
        }
    }

    public class FileReader : IReader
    {
    }

    public class TableTop : ITableTop
    {
    }

    public interface ITableTop
    {
    }

    public interface IReader
    {
    }

    public class ToyRobotSimulator : IToyRobotSimulator
    {
        public ToyRobotSimulator(IMyOutput mockObject, IReader mock1Object, ITableTop tableTop)
        {
            throw new System.NotImplementedException();
        }

        public void Command(string filePath)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IToyRobotSimulator
    {
        void Command(string filePath);
    }

    public interface IMyOutput
    {
        Task Print(string text);
    }
}