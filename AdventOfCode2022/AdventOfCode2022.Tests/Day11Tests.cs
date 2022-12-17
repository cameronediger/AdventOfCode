namespace AdventOfCode2022.Tests
{
    public class Day11Tests
    {
        private readonly IEnumerable<string> _data = new List<string>
        {
            "Monkey 0:",
            "  Starting items: 79, 98",
            "  Operation: new = old * 19",
            "  Test: divisible by 23",
            "    If true: throw to monkey 2",
            "    If false: throw to monkey 3",
            "          ",
            "Monkey 1:",
            "  Starting items: 54, 65, 75, 74",
            "  Operation: new = old + 6",
            "  Test: divisible by 19",
            "    If true: throw to monkey 2",
            "    If false: throw to monkey 0",
            "            ",
            "Monkey 2:",
            "  Starting items: 79, 60, 97",
            "  Operation: new = old * old",
            "  Test: divisible by 13",
            "    If true: throw to monkey 1",
            "    If false: throw to monkey 3",
            "            ",
            "Monkey 3:",
            "  Starting items: 74",
            "  Operation: new = old + 3",
            "  Test: divisible by 17",
            "    If true: throw to monkey 0",
            "    If false: throw to monkey 1"
        };

        [Fact]
        public void GetMonkeyBusiness_0_Returns10605()
        {
            Day11 day = new Day11(0);
            day.LoadInputData(_data);
            day.ProcessData();

            Assert.Equal(10605, day.GetMonkeyBusinessNumber());
        }

        [Fact]
        public void GetMonkeyBusiness_1_Returns2713310158()
        {
            Day11 day = new Day11(1);
            day.LoadInputData(_data);
            day.ProcessData();

            Assert.Equal(2713310158, day.GetMonkeyBusinessNumber());
        }
    }
}
