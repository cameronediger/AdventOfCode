namespace AdventOfCode2022
{
    public abstract class BaseDayOld
    {
        protected readonly string _inputDataPath = @"C:\reposCE\AdventOfCode2022\AdventOfCode2022\InputData\";
        protected IEnumerable<string> _inputData = null;

        public abstract void Run();
        public abstract void ProcessData();

        protected void LoadInputData(string filename)
        {
            _inputData = File.ReadLines(_inputDataPath + filename);
        }

        public void LoadInputData(IEnumerable<string> inputData)
        {
            _inputData = inputData;
        }
    }
}
