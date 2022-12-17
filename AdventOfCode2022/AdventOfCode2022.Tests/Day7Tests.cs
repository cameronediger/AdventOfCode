namespace AdventOfCode2022.Tests
{
    public class Day7Tests
    {
        private readonly IEnumerable<string> _data = new List<string>
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k"
        };

        [Fact]
        public void SumDirectoriesAtMost10000_Returns95437()
        {
            Day7 day = new Day7();
            day.LoadInputData(_data);
            day.ProcessData();
            
            Assert.Equal(95437, day.DirectorySum);
        }

        [Fact]
        public void GetFolderToDelete_Returns24933642()
        {
            Day7 day = new Day7();
            day.LoadInputData(_data);
            day.ProcessData();

            Assert.Equal(24933642, day.GetFolderToDeleteSize());
        }
    }
}
