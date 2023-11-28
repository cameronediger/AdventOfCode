namespace AdventOfCode2023
{
    public abstract class BaseDay
    {
        protected readonly string _inputDataPath = "../../../InputData/";
        protected IEnumerable<string> _inputData = null;

        protected BaseDay()
        {
        }

        public virtual void Run(DayPart part)
        {
            var dataFile = $"{this.GetType().Name.ToLower()}_part{(int)part}.txt";

            LoadInputData(dataFile);
            ProcessData(part);
        }

        public void ProcessData(DayPart part)
        {
            switch (part)
            {
                case DayPart.Part1:
                    ProcessDataPart1();
                    break;
                case DayPart.Part2:
                    ProcessDataPart2();
                    break;
            }
        }
        protected abstract void ProcessDataPart1();
        protected abstract void ProcessDataPart2();

        protected void LoadInputData(string filename)
        {
            _inputData = File.ReadLines(_inputDataPath + filename);
        }

        public void LoadInputData(IEnumerable<string> inputData)
        {
            _inputData = inputData;
        }
    }

    public enum DayPart
    {
        Part1 = 1,
        Part2 = 2
    }
}
