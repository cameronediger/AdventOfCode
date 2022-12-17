namespace AdventOfCode2022.Tests
{
    public class Day9Tests
    {
        private readonly IEnumerable<string> _data = new List<string>
        {
            "R 4",
            "U 4",
            "L 3",
            "D 1",
            "R 4",
            "D 1",
            "L 5",
            "R 2"
        };

        private readonly IEnumerable<string> _data2 = new List<string>
        {
            "R 5",
            "U 8",
            "L 8",
            "D 3",
            "R 17",
            "D 10",
            "L 25",
            "U 20"
        };

        [Fact]
        public void GetTailPositionsVisited_Returns13()
        {
            Day9 day = new Day9(2);
            day.LoadInputData(_data);
            day.ProcessData();
            
            Assert.Equal(13, day.GetTailPositionsVisited());
        }

        [Fact]
        public void GetTailPositionsVisited_Returns36()
        {
            Day9 day = new Day9(10);
            day.LoadInputData(_data2);
            day.ProcessData();

            Assert.Equal(36, day.GetTailPositionsVisited());
        }
    }
}
