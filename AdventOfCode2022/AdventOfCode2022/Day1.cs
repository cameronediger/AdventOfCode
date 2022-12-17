namespace AdventOfCode2022
{
    public class Day1 : BaseDay
    {
        private Dictionary<string, int> _elfCalories = new Dictionary<string, int>();

        public override void Run()
        {
            base.Run();

            Console.WriteLine($"Top Elf: {GetTopElfTotal()} Calories");
            Console.WriteLine($"Top Threee Elves: {GetTopThreeElfTotal()} Calories");
        }

        public override void ProcessData()
        {
            int index = 1;
            int elfTotal = 0;
            foreach (var d in _inputData)
            {
                if (!string.IsNullOrEmpty(d))
                {
                    elfTotal += Int32.Parse(d);
                }
                else
                {
                    _elfCalories.Add($"elf{index}", elfTotal);
                    index++;
                    elfTotal = 0;
                }
            }
        }

        public int GetTopElfTotal()
        {
            return _elfCalories.Max(d => d.Value);
        }

        public int GetTopThreeElfTotal()
        {
            return _elfCalories.OrderByDescending(d => d.Value).Take(3).Sum(d => d.Value);
        }
    }
}
