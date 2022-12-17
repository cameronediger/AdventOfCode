namespace AdventOfCode2022.Tests
{
    public class Day1Tests
    {
        private readonly IEnumerable<string> _data = new List<string>
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000",
            ""
        };

        [Fact]
        public void TopElfCalories_Returns24K()
        {
            Day1 d1 = new Day1();
            d1.LoadInputData(_data);
            d1.ProcessData();

            Assert.Equal(24000, d1.GetTopElfTotal());
        }

        [Fact]
        public void TopThreeElfCalories_Returns45K()
        {
            Day1 d1 = new Day1();
            d1.LoadInputData(_data);
            d1.ProcessData();

            Assert.Equal(45000, d1.GetTopThreeElfTotal());
        }
    }
}
