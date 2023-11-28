namespace AdventOfCode2023.Tests
{
    public class Day1Tests
    {
        private readonly IEnumerable<string> _data = new List<string>()
        {
        };

        [Fact]
        public void Day1_Part1_Returns()
        {
            Day1 day = new Day1();
            day.LoadInputData(_data);
            day.ProcessData(DayPart.Part1);

            //TODO: Assert
        }

        [Fact]
        public void Day1_Part2_Returns()
        {
            Day1 day = new Day1();
            day.LoadInputData(_data);
            day.ProcessData(DayPart.Part2);

            //TODO: Assert
        }
    }
}