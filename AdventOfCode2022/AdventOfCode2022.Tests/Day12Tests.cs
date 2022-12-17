namespace AdventOfCode2022.Tests
{
    public class Day12Tests
    {
        private readonly IEnumerable<string> _data = new List<string>
        {
            "Sabqponm",
            "abcryxxl",
            "accszExk",
            "acctuvwj",
            "abdefghi"
        };

        [Fact]
        public void GetMonkeyBusiness_0_Returns10605()
        {
            Day12 day = new Day12();
            day.LoadInputData(_data);
            day.ProcessData();

            //Assert.Equal(10605, day.GetMonkeyBusinessNumber());
        }
    }
}
