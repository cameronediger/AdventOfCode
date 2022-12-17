namespace AdventOfCode2022.Tests
{
    public class Day5Tests
    {
        private readonly IEnumerable<string> _data = new List<string>
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 ",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
        };

        [Fact]
        public void AfterMoveSequence_ReturnsTopCratesCMZ()
        {
            Day5 d5 = new Day5();
            d5.LoadInputData(_data);
            d5.ProcessData();

            Assert.Equal("CMZ", d5.GetTopCrates());
        }

        [Fact]
        public void NewCrane_AfterMoveSequence_ReturnsTopCratesMCD()
        {
            Day5 d5 = new Day5(1);
            d5.LoadInputData(_data);
            d5.ProcessData();

            Assert.Equal("MCD", d5.GetTopCrates());
        }
    }
}
