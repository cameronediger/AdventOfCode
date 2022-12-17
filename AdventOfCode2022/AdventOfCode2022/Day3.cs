namespace AdventOfCode2022
{
    public class Day3 : BaseDay
    {
        private int _prioritySum = 0;
        public int PrioritySum { get { return _prioritySum; } }

        private int _badgePrioritySum = 0;
        public int BadgePrioritySum { get { return _badgePrioritySum; } }

        public override void Run()
        {
            base.Run();

            Console.WriteLine($"Rucksack Priority Sum: {PrioritySum}");
            Console.WriteLine($"Badge Priority Sum: {BadgePrioritySum}");
        }

        public override void ProcessData()
        {
            IList<ElfRucksack> elfGroup = new List<ElfRucksack>();
            foreach (string rucksack in _inputData)
            {
                var elfRucksack = new ElfRucksack(rucksack);
                elfGroup.Add(elfRucksack);

                var dup = elfRucksack.FindDuplicateItem();
                if (!string.IsNullOrEmpty(dup))
                {
                    _prioritySum += GetPriority(dup);
                }

                if (elfGroup.Count == 3)
                {
                    var badge = GetGroupBadge(elfGroup);
                    if (!string.IsNullOrEmpty(badge))
                    {
                        _badgePrioritySum += GetPriority(badge);
                    }

                    elfGroup.Clear();
                }
            }
        }

        public string GetGroupBadge(IEnumerable<ElfRucksack> elfGroup)
        {
            string resultBadge = string.Empty;
            var list = elfGroup.ToList();

            foreach (var c in elfGroup.First().TotalItems)
            {
                if (list[1].TotalItems.Contains(c) && list[2].TotalItems.Contains(c))
                {
                    resultBadge = c.ToString();
                    break;
                }
            }

            return resultBadge;
        }

        private int GetPriority(string str)
        {
            int result = 0;

            if (str[0] >= 97)
            {
                // a-z => 1-26
                result = str[0] - 96;
            }
            else
            {
                // A-Z => 27-63
                result = str[0] - 64 + 26;
            }

            return result;
        }
    }

    public class ElfRucksack
    {
        public ElfRucksack() { }
        public ElfRucksack(string items)
        {
            var midloc = (items.Length / 2);
            Compartment1 = items.Substring(0, midloc);
            Compartment2 = items.Substring(midloc);
        }

        public string Compartment1 { get; set; }
        public string Compartment2 { get; set; }
        public string TotalItems { get { return Compartment1 + Compartment2; } }

        public string FindDuplicateItem()
        {
            foreach (var c in Compartment1)
            {
                if (Compartment2.Contains(c))
                {
                    return c.ToString();
                }
            }

            return string.Empty;
        }
    }
}
