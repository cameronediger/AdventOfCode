namespace AdventOfCode2022.Tests
{
    public class Day2Tests
    {
        private readonly IEnumerable<string> _data = new List<string>
        {
            "A Y",
            "B X",
            "C Z"
        };

        [Fact]
        public void GameMode0_MyScore_Returns15()
        {
            Day2 d2 = new Day2(0);
            d2.LoadInputData(_data);
            d2.ProcessData();

            Assert.Equal(15, d2.MyTotalScore);
        }

        [Fact]
        public void GameMode1_MyScore_Returns12()
        {
            Day2 d2 = new Day2(1);
            d2.LoadInputData(_data);
            d2.ProcessData();

            Assert.Equal(12, d2.MyTotalScore);
        }
    }
}