using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tests
{
    public class Day3Tests
    {
        private readonly IEnumerable<string> _data = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
        };

        [Fact]
        public void SumPriorityTypes_Returns157()
        {
            Day3 d3 = new Day3();
            d3.LoadInputData(_data);
            d3.ProcessData();

            Assert.Equal(157, d3.PrioritySum);
        }

        [Fact]
        public void SumBadgePriorities_Returns70()
        {
            Day3 d3 = new Day3();
            d3.LoadInputData(_data);
            d3.ProcessData();

            Assert.Equal(70, d3.BadgePrioritySum);
        }
    }
}
