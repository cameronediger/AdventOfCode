namespace AdventOfCode2022
{
    public class Day9 : BaseDay
    {
        private const int gridSize= 1000;
        private readonly int _knotCount;
        private IList<Location> _knotLocations = new List<Location>();

        private Location[,] _gameGrid { get; set; } = new Location[gridSize,gridSize];

        public Day9(int knotCount)
        {
            _knotCount = knotCount;
        }

        public override void Run()
        {
            base.Run();

            Console.WriteLine($"Day9 - Tail Positions: {GetTailPositionsVisited()}");
        }

        public override void ProcessData()
        {
            InitializeGameGrid();

            foreach(var line in _inputData)
            {
                var move = line.Split();
                MoveHead(move[0], Convert.ToInt32(move[1]));
            }
        }

        public int GetTailPositionsVisited()
        {
            var headCount = 0;
            var tailCount = 0;
            for(var y=0; y < gridSize; y++)
            {
                for(var x=0; x < gridSize; x++)
                {
                    if (_gameGrid[x,y].HeadVisited)
                        headCount++;

                    if (_gameGrid[x, y].TailVisited)
                        tailCount++;
                }
            }

            return tailCount;
        }

        private void InitializeGameGrid()
        {
            for(var y=0; y < gridSize; y++)
            {
                for(var x=0; x < gridSize; x++)
                {
                    _gameGrid[x,y] = new Location
                    {
                        X = x,
                        Y = y,
                        HeadVisited = false,
                        TailVisited = false
                    };
                }
            }

            for(var n=0; n < _knotCount; n++)
            {
                _knotLocations.Add(_gameGrid[gridSize/2, gridSize/2]);
            }
        }
        private void MoveHead(string direction, int count)
        {
            for (var n = 0; n < count; n++)
            {
                switch (direction)
                {
                    case "R":
                        _knotLocations[0] = _gameGrid[_knotLocations[0].X + 1, _knotLocations[0].Y];
                        break;
                    case "L":
                        _knotLocations[0] = _gameGrid[_knotLocations[0].X-1, _knotLocations[0].Y];
                        break;
                    case "U":
                        _knotLocations[0] = _gameGrid[_knotLocations[0].X, _knotLocations[0].Y-1];
                        break;
                    case "D":
                        _knotLocations[0] = _gameGrid[_knotLocations[0].X, _knotLocations[0].Y+1];
                        break;
                }
                
                _knotLocations[0].HeadVisited = true;
                for(var i=1; i < _knotLocations.Count(); i++)
                {
                    _knotLocations[i] = MoveKnot(_knotLocations[i-1], _knotLocations[i]);
                    if (i == (_knotCount - 1)) _knotLocations[i].TailVisited = true;
                }

                //DisplayGrid($"{direction} {count}");
            }
        }

        private Location MoveKnot(Location precedingKnot, Location currentKnot) 
        {
            var tx = currentKnot.X;
            var ty = currentKnot.Y;

            var xDiff = precedingKnot.X - currentKnot.X;
            var yDiff = precedingKnot.Y - currentKnot.Y;

            if (xDiff >= 2 || (xDiff == 1 && Math.Abs(yDiff) >= 2)) tx++;
            if (xDiff <= -2 || (xDiff == -1 && Math.Abs(yDiff) >= 2)) tx--;

            if (yDiff >= 2 || (yDiff == 1 && Math.Abs(xDiff) >= 2)) ty++;
            if (yDiff <= -2 || (yDiff == -1 && Math.Abs(xDiff) >= 2)) ty--;

            currentKnot = _gameGrid[tx, ty];
            return currentKnot;
        }

        private void DisplayGrid(string move)
        {
            System.Diagnostics.Debug.WriteLine($"===== {move} ======");
            for (var y = 0; y < gridSize; y++)
            {
                for (var x = 0; x < gridSize; x++)
                {
                    var c = ".";
                    for(var k=0; k < _knotLocations.Count; k++)
                    {
                        if (_knotLocations[k].X == x && _knotLocations[k].Y == y)
                            c = k.ToString();
                    }

                    if (_knotLocations[0].X == x && _knotLocations[0].Y == y)
                        c = "H";

                    if (x == gridSize - 1)
                        System.Diagnostics.Debug.WriteLine($"{c} ");
                    else
                        System.Diagnostics.Debug.Write($"{c} ");
                }
            }
        }

        public class Location
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool HeadVisited { get; set; }
            public bool TailVisited { get; set; }
        }
    }
}
