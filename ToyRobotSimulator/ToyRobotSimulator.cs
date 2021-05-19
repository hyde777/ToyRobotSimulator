namespace ToyRobotSimulator
{
    public class ToyRobotSimulator : IToyRobotSimulator
    {
        private readonly IReader _reader;
        private readonly ITableTop _tableTop;
        private readonly IInterpreter _interpreter;

        public ToyRobotSimulator(IReader reader, 
            ITableTop tableTop,
            IInterpreter interpreter)
        {
            _reader = reader;
            _tableTop = tableTop;
            _interpreter = interpreter;
        }

        public async void Command(string filePath)
        {
            var readFromFile = _reader.ReadFromFile(filePath);
            await foreach (var line in readFromFile)
            {
                var action = _interpreter.Convert(line);
                await _tableTop.Execute(action);
            }
        }
    }
}