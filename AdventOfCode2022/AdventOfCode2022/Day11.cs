namespace AdventOfCode2022
{
    public class Day11 : BaseDay
    {
        private readonly int _gameMode = 0;
        private readonly int _inspectionRounds = 20;
        private IList<Monkey> _monkeyList = new List<Monkey>();

        public Day11(int gameMode)
        {
            _gameMode = gameMode;
            if (_gameMode == 0)
                _inspectionRounds = 20;
            else if (_gameMode == 1)
                _inspectionRounds = 10000;
        }

        public override void Run()
        {
            base.Run();

            Console.WriteLine($"Day 11 - Monkey Business: {GetMonkeyBusinessNumber()}");
        }

        public override void ProcessData()
        {
            int monkeyIndex = 0;
            foreach (var line in _inputData)
            {
                if (line.StartsWith("Monkey"))
                {
                    var str = line.Replace("Monkey", "");
                    monkeyIndex = Convert.ToInt32(str.TrimEnd(':'));
                    _monkeyList.Add(new Monkey());
                }
                else if (line.Contains("Starting items:"))
                {
                    var str = line.Replace("Starting items:", "").Trim();
                    var items = str.Split(',');
                    foreach (var i in items)
                    {
                        _monkeyList[monkeyIndex].Items.Add(Convert.ToInt32(i));
                    }
                }
                else if (line.Contains("Operation:"))
                {
                    var str = line.Replace("Operation:", "").Trim();
                    _monkeyList[monkeyIndex].Operation = str;
                }
                else if (line.Contains("Test:"))
                {
                    var str = line.Replace("Test: divisible by ", "").Trim();
                    _monkeyList[monkeyIndex].DivisibleBy = Convert.ToInt32(str);
                }
                else if (line.Contains("If true:"))
                {
                    var str = line.Replace("If true: throw to monkey", "").Trim();
                    _monkeyList[monkeyIndex].MonkeyIndexTrue = Convert.ToInt32(str);
                }
                else if (line.Contains("If false:"))
                {
                    var str = line.Replace("If false: throw to monkey", "").Trim();
                    _monkeyList[monkeyIndex].MonkeyIndexFalse = Convert.ToInt32(str);
                }
            }

            //Monkey Inspection
            for (int n = 0; n < _inspectionRounds; n++)
            {
                MonkeyInspectionRound();
                DisplayRoundResults(n);
            }
        }

        public long GetMonkeyBusinessNumber()
        {
            var monkeysSorted = _monkeyList.OrderByDescending(m => m.ItemsInspected).Take(2).ToList();
            return monkeysSorted[0].ItemsInspected * monkeysSorted[1].ItemsInspected;
        }

        private void DisplayRoundResults(int round)
        {
            round++;
            if (round == 1 || round == 20 || round == 1000 || round == 2000 || round == 9000 || round == 10000)
            //if(round == 18 || round == 19 || round == 20 || round == 21 || round == 22)
            {
                System.Diagnostics.Debug.WriteLine($"=== Round: {round} ==================================================");
                int n = 0;
                foreach (var monkey in _monkeyList)
                {
                    System.Diagnostics.Debug.WriteLine($"Monkey[{n}]: {string.Join(",", monkey.Items)}");
                    System.Diagnostics.Debug.WriteLine($"Monkey[{n}]: {monkey.ItemsInspected}");
                    n++;
                }
            }
        }

        private void MonkeyInspectionRound()
        {
            var commonDevisor = 1;
            foreach (var nbr in _monkeyList.Select(m => m.DivisibleBy))
                commonDevisor *= nbr;

            foreach (var monkey in _monkeyList)
            {
                var itemsToRemove = new List<long>();
                foreach (var item in monkey.Items)
                {
                    var calcItem = PerformOperation(monkey.Operation, item);
                    if (_gameMode == 0)
                        calcItem /= 3;
                    else
                        calcItem = calcItem % commonDevisor;

                    if (monkey.Test(calcItem))
                    {
                        _monkeyList[monkey.MonkeyIndexTrue].Items.Add(calcItem);
                    }
                    else
                    {
                        _monkeyList[monkey.MonkeyIndexFalse].Items.Add(calcItem);
                    }
                    itemsToRemove.Add(item);
                    monkey.ItemsInspected++;
                }

                foreach (var item in itemsToRemove)
                {
                    monkey.Items.Remove(item);
                }
            }
        }

        private long PerformOperation(string operation, long item)
        {
            long result = 0;

            var op = operation.Replace("new = ", "").Trim();
            if (op.Contains("old + "))
            {
                var nbr = Convert.ToInt32(op.Replace("old + ", "").Trim());
                result = item + nbr;

            }
            else if (op.Contains("old *"))
            {
                long nbr = 0;
                if (op.Contains("old * old"))
                {
                    nbr = item;
                }
                else
                {
                    nbr = Convert.ToInt32(op.Replace("old * ", "").Trim());
                }

                result = item * nbr;
            }

            return result;
        }

        public class Monkey
        {
            public IList<long> Items { get; set; } = new List<long>();
            public string Operation { get; set; }
            public int DivisibleBy { get; set; }
            public int MonkeyIndexTrue { get; set; }
            public int MonkeyIndexFalse { get; set; }
            public long ItemsInspected { get; set; }

            public bool Test(long calcItem)
            {
                return (calcItem % DivisibleBy == 0);
            }
        }
    }
}
