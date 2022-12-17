namespace AdventOfCode2022
{
    public class Day4 : BaseDay
    {
        private int _uselessPairCount = 0;
        public int UselessPairCount { get { return _uselessPairCount; } }

        private int _pairOverlapCount = 0;
        public int PairOverlapCount { get { return _pairOverlapCount; } }

        public override void Run()
        {
            base.Run();

            Console.WriteLine($"Fully Contained Pairs: {UselessPairCount}");
            Console.WriteLine($"Pair Overlap Count: {PairOverlapCount}");
        }

        public override void ProcessData()
        {
            foreach(var pair in _inputData)
            {
                var pairAssignments = pair.Split(',');
                var elfGroupAssignments = new ElfGroupAssignments(pairAssignments[0], pairAssignments[1]);

                if(CheckAssignmentsForOverlap(elfGroupAssignments))
                    _pairOverlapCount++;
                if(CheckAssignmentsForAllOverlap(elfGroupAssignments))
                    _uselessPairCount++;
            }
        }

        private bool CheckAssignmentsForAllOverlap(ElfGroupAssignments ga)
        {
            if (ga.Elf1.Count() <= ga.Elf2.Count())
            {
                return ga.Elf1.All(a => ga.Elf2.Contains(a));
            }
            else
            {
                return ga.Elf2.All(a => ga.Elf1.Contains(a));
            }
        }

        private bool CheckAssignmentsForOverlap(ElfGroupAssignments ga)
        {
            return ga.Elf1.Any(a => ga.Elf2.Contains(a));
        }

        public class ElfGroupAssignments 
        {
            public ElfGroupAssignments() 
            {
                Elf1 = new List<int>();
                Elf2 = new List<int>();
            }

            public ElfGroupAssignments(string elf1, string elf2)
            {
                Elf1 = GetAssignments(elf1);
                Elf2 = GetAssignments(elf2);
            }

            public IEnumerable<int> Elf1;
            public IEnumerable<int> Elf2;

            private IEnumerable<int> GetAssignments(string str)
            {
                List<int> result = new List<int>();

                var split = str.Split('-');
                var first = Convert.ToInt32(split[0]);
                var last = Convert.ToInt32(split[1]);

                for(var n = first; n <= last; n++)
                {
                    result.Add(n);
                }

                return result;
            }
        }
    }

}
