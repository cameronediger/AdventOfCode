namespace AdventOfCode2022
{
    public class Day10 : BaseDay
    {
        private const int _strengthCycleStart = 20;
        private const int _strengthCycle = 40;
        private const int _crtWidth = 40;   //0-39

        private int _xValue = 1;
        private Dictionary<int, int> _signalStrengths = new Dictionary<int, int>();
        public int SignalStrengthSum { get { return _signalStrengths.Sum(s => s.Value); } }
        public IList<string> _pixels = new List<string>();

        private IList<Job> _jobs = new List<Job>();

        public override void Run()
        {
            base.Run();

            Console.WriteLine($"Day 10 - Signal Strength Sum: {SignalStrengthSum}");
            DisplayCRT();
        }

        public override void ProcessData()
        {
            int cycleCount = 0;
            foreach (var line in _inputData)
            {
                cycleCount++;

                var command = line.Split(" ");
                _jobs.Add(new Job
                {
                    Name = command[0],
                    Value = (command.Count() == 2 ? Convert.ToInt32(command[1]) : 0),
                    CyclesRunning = 0
                });

                ProcessJobs(cycleCount);
            }

            while (_jobs.Count > 0)
            {
                cycleCount++;
                ProcessJobs(cycleCount);
            }

            DisplayCRT();
        }

        private void ProcessJobs(int cycleCount)
        {
            if (cycleCount == 20 || ((cycleCount - _strengthCycleStart) % 40) == 0)
            {
                _signalStrengths.Add(cycleCount, (cycleCount * _xValue));
            }

            DrawPixel();

            var job = _jobs[0];
            job.CyclesRunning++;

            if (job.Name == "noop")
            {
                CalculateXValue(job, cycleCount);
                _jobs.Remove(job);
            }
            else if (job.Name == "addx")
            {
                if (job.CyclesRunning == 2)
                {
                    CalculateXValue(job, cycleCount);
                    _jobs.Remove(job);
                }
            }
            /*
                        IList<Job> jobsToRemove = new List<Job>();
                        foreach(var job in _jobs)
                        {
                            job.CyclesRunning++;

                            if(job.Name == "noop")
                            {
                                CalculateXValue(job, cycleCount);
                                jobsToRemove.Add(job);
                            }
                            else if(job.Name == "addx")
                            {
                                if (job.CyclesRunning == 2)
                                {
                                    CalculateXValue(job, cycleCount);
                                    jobsToRemove.Add(job);
                                }
                            }
                        }

                        foreach(var jtr in jobsToRemove)
                        {
                            _jobs.Remove(jtr);
                        }*/
        }

        private void CalculateXValue(Job job, int cycleCount)
        {
            if (job.Name == "addx")
                _xValue += job.Value;
        }

        private void DrawPixel()
        {
            if (_pixels.Count == 0) _pixels.Add("");

            var rowIndex = _pixels.Count - 1;
            if (_pixels[rowIndex].Length >= _crtWidth)
            {
                _pixels.Add("");
                rowIndex++;
            }

            var min = _xValue - 1;
            var max = _xValue + 1;
            if (_pixels[rowIndex].Length >= min && _pixels[rowIndex].Length <= max)
                _pixels[rowIndex] += "#";
            else
                _pixels[rowIndex] += ".";
        }

        private void DisplayCRT()
        {
            foreach (var row in _pixels)
            {
                System.Diagnostics.Debug.WriteLine(row);
                Console.WriteLine(row);
            }
        }

        public class Job
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public int CyclesRunning { get; set; }
        }
    }
}
