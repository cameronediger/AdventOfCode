using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    public class Day5 : BaseDay
    {
        private readonly int _craneType;
        private Dictionary<int, ContainerStack> _containerStacks = new Dictionary<int, ContainerStack>();

        public Day5(int craneType = 0)
        {
            _craneType = craneType;
        }

        public override void Run()
        {
            base.Run();

            Console.WriteLine($"Top Crates: {GetTopCrates()}");
        }

        public override void ProcessData()
        {
            var dataList = _inputData.ToList();
            var stackList = dataList.First(d => d.StartsWith(" 1   2 "));
            var stackListRow = dataList.IndexOf(stackList);
            for (var n = stackListRow - 1; n >= 0; n--)
            {
                LoadContainers(dataList[n]);
            }

            foreach (var line in _inputData.Where(d => d.StartsWith("move ")))
            {
                ProcessMove(line);
            }
        }

        private void LoadContainers(string containerLine)
        {
            int start = 0;
            int stackNbr = 1;
            while (start < containerLine.Length)
            {
                var value = containerLine.Substring(start, Math.Min(4, (containerLine.Length - start)));
                value = value.Trim().TrimStart('[').TrimEnd(']');
                if (!string.IsNullOrEmpty(value))
                {
                    if (_containerStacks.ContainsKey(stackNbr))
                        _containerStacks[stackNbr].Containers.Push(value);
                    else
                        _containerStacks.Add(stackNbr, new ContainerStack(stackNbr, value));
                }

                start += 4;
                stackNbr++;
            }
        }

        private void ProcessMove(string moveLine)
        {
            Regex movePattern = new Regex("move (.*) from (.*) to (.*)");
            var m = movePattern.Match(moveLine);
            var count = Convert.ToInt32(m.Groups[1].Value);
            var fromStack = Convert.ToInt32(m.Groups[2].Value);
            var toStack = Convert.ToInt32(m.Groups[3].Value);

            if (_craneType == 0)
            {
                for (var n = 0; n < count; n++)
                {
                    var container = _containerStacks[fromStack].Containers.Pop();
                    _containerStacks[toStack].Containers.Push(container);
                }
            }
            else
            {
                Stack<string> moveStack = new Stack<string>();
                for (var n = 0; n < count; n++)
                {
                    var container = _containerStacks[fromStack].Containers.Pop();
                    moveStack.Push(container);
                }

                for (var n = 0; n < count; n++)
                {
                    var container = moveStack.Pop();
                    _containerStacks[toStack].Containers.Push(container);
                }
            }
        }

        public string GetTopCrates()
        {
            string result = string.Empty;
            foreach (var stack in _containerStacks)
            {
                result += stack.Value.Containers.Peek();
            }

            return result;
        }

        public class ContainerStack
        {
            public int StackNumber { get; set; }
            public Stack<string> Containers { get; set; }

            public ContainerStack()
            {
                Containers = new Stack<string>();
            }

            public ContainerStack(int stackNumber, string container)
            {
                StackNumber = stackNumber;
                Containers = new Stack<string>();
                Containers.Push(container);
            }
        }
    }
}
