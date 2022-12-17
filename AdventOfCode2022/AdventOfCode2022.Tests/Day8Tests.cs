namespace AdventOfCode2022.Tests
{
    public class Day8Tests
    {
        private readonly IEnumerable<string> _data = new List<string>
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390"
        };

        [Fact]
        public void GetVisibleTreeCount_Returns21()
        {
            Day8 day = new Day8();
            day.LoadInputData(_data);
            day.ProcessData();
            
            Assert.Equal(21, day.GetVisibleTreeCount());
        }

        [Fact]
        public void GetHighestScenicScore_Returns8()
        {
            Day8 day = new Day8();
            day.LoadInputData(_data);
            day.ProcessData();

            Assert.Equal(8, day.GetMaxScenicScore());
        }
    }
}
