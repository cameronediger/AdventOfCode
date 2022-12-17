namespace AdventOfCode2022.Tests
{
    public class Day4Tests
    {
        private readonly IEnumerable<string> _data = new List<string>
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8"
        };

        [Fact]
        public void UselessPairCount_Returns2()
        {
            Day4 d4 = new Day4();
            d4.LoadInputData(_data);
            d4.ProcessData();

            Assert.Equal(2, d4.UselessPairCount);
        }

        [Fact]
        public void PairOverlapCount_Returns4()
        {
            Day4 d4 = new Day4();
            d4.LoadInputData(_data);
            d4.ProcessData();

            Assert.Equal(4, d4.PairOverlapCount);
        }
    }
}
