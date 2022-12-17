namespace AdventOfCode2022
{
    public abstract class BaseDay
    {
        protected readonly string _inputDataPath = @"C:\reposCE\AdventOfCode2022\AdventOfCode2022\InputData\";
        protected IEnumerable<string> _inputData = null;
        protected string _dataFile;

        protected BaseDay()
        {
            _dataFile = $"{this.GetType().Name.ToLower()}.txt";
        }

        public virtual void Run()
        {    
            LoadInputData(_dataFile);
            ProcessData();
        }

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
