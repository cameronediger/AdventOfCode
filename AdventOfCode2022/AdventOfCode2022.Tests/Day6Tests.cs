namespace AdventOfCode2022.Tests
{
    public class Day6Tests
    {
        private readonly IEnumerable<string> _data = new List<string>
        {
        };

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void FindStartOfPacket_ReturnsMarkerLocation(string data, int expectedMarker)
        {
            Day6 day = new Day6();
            day.LoadInputData(new List<string> { data });
            day.ProcessData();
            
            Assert.Equal(expectedMarker, day.PacketLocation);
        }

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void FindMessage_ReturnsMarkerLocation(string data, int expectedMarker)
        {
            Day6 day = new Day6();
            day.LoadInputData(new List<string> { data });
            day.ProcessData();

            Assert.Equal(expectedMarker, day.MessageLocation);
        }
    }
}
