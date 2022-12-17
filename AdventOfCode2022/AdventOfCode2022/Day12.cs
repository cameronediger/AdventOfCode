using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2022.Day12;

namespace AdventOfCode2022
{
    public class Day12 : BaseDay
    {
        private char[,] _map = null;
        private int _mapWidth = 0;
        private int _mapHeight = 0;
        private Position _startPos = null;
        private Position _currPos = null;
        private Position _destinationPos = null;

        private IList<Path> _completedPath = new List<Path>();
        private IList<Path> _pendingPath = new List<Path>();

        public override void Run()
        {
            base.Run();
        }

        public override void ProcessData()
        {
            LoadMap();
            CreateStartPaths();
            RunPaths();
        }

        private void CreateStartPaths()
        {
            //Left
            if (_currPos.X != 0)
            {
                var elev = Math.Abs(_map[_currPos.X-1, _currPos.Y] - _currPos.Elevation);
                if (elev == 0 || elev == 1)
                {
                    var path = new Path();
                    path.Positions.Add(_currPos);
                    path.NextDirection = Direction.Left;
                    _pendingPath.Add(path);

                }
            }

            //Right
            if (_currPos.X != _mapWidth - 1)
            {
                var elev = Math.Abs(_map[_currPos.X+1, _currPos.Y] - _currPos.Elevation);
                if (elev == 0 || elev == 1)
                {
                    var path = new Path();
                    path.Positions.Add(_currPos);
                    path.NextDirection = Direction.Right;
                    _pendingPath.Add(path);
                }
            }

            //Top
            if (_currPos.Y != 0)
            {
                var elev = Math.Abs(_map[_currPos.X, _currPos.Y-1] - _currPos.Elevation);
                if (elev == 0 || elev == 1)
                {
                    var path = new Path();
                    path.Positions.Add(_currPos);
                    path.NextDirection = Direction.Up;
                    _pendingPath.Add(path);
                }
            }

            //Down
            if (_currPos.Y != _mapHeight - 1)
            {
                var elev = Math.Abs(_map[_currPos.X, _currPos.Y+1] - _currPos.Elevation);
                if (elev == 0 || elev == 1)
                {
                    var path = new Path();
                    path.Positions.Add(_currPos);
                    path.NextDirection = Direction.Down;
                    _pendingPath.Add(path);
                }
            }
        }

        private void RunPaths()
        {
            foreach(var path in _pendingPath)
            {
                CheckPath(path);
            }
        }

        private void CheckPath(Path path)
        {
            Position pos = new Position { X = _currPos.X, Y = _currPos.Y, Elevation = _currPos.Elevation };
            switch(path.NextDirection)
            {
                case Direction.Up:
                    pos.Y--;
                    break;
                case Direction.Down:
                    pos.Y++;
                    break;
                case Direction.Left:
                    pos.X--;
                    break;
                case Direction.Right:
                    pos.X++;
                    break;
            }
            pos.Elevation = _map[pos.X, pos.Y];

            //Left
            if (pos.X != 0)
            {
                if (_map[pos.X - 1, pos.Y] == 'E')
                    CompletePath(path);

                var elev = Math.Abs(_map[pos.X - 1, pos.Y] - pos.Elevation);
                if (elev == 0 || elev == 1)
                {
                    path.Positions.Add(pos);
                    path.NextDirection = Direction.Left;
                }
            }

            //Right
            if (pos.X != _mapWidth - 1)
            {
                if (_map[pos.X+1, pos.Y] == 'E')
                    CompletePath(path);

                var elev = Math.Abs(_map[pos.X + 1, pos.Y] - pos.Elevation);
                if (elev == 0 || elev == 1)
                {
                    path.Positions.Add(pos);
                    path.NextDirection = Direction.Right;
                }
            }

            //Top
            if (pos.Y != 0)
            {
                if (_map[pos.X, pos.Y-1] == 'E')
                    CompletePath(path);

                var elev = Math.Abs(_map[pos.X, pos.Y - 1] - pos.Elevation);
                if (elev == 0 || elev == 1)
                {
                    path.Positions.Add(pos);
                    path.NextDirection = Direction.Up;
                }
            }

            //Down
            if (pos.Y != _mapHeight - 1)
            {
                if (_map[pos.X, pos.Y+1] == 'E')
                    CompletePath(path);

                var elev = Math.Abs(_map[pos.X, pos.Y + 1] - pos.Elevation);
                if (elev == 0 || elev == 1)
                {
                    path.Positions.Add(pos);
                    path.NextDirection = Direction.Down;
                }
            }
        }

        private void CompletePath(Path path)
        {

        }

        private void LoadMap()
        {
            _mapWidth = _inputData.First().Length;
            _mapHeight = _inputData.Count();

            _map = new char[_mapWidth, _mapHeight];
            var y = 0;
            foreach (var line in _inputData)
            {
                var x = 0;
                foreach (var c in line)
                {
                    _map[x, y] = c;
                    switch (c)
                    {
                        case 'E':
                            _destinationPos = new Position(x, y, 'z');
                            break;
                        case 'S':
                            _startPos = new Position(x, y, 'a');
                            _currPos = new Position(x, y, 'a');
                            break;
                    }
                }
            }
        }

        public class Position
        {
            public Position() { }
            public Position(int x, int y, char elevation)
            {
                X = x;
                Y = y;
                Elevation = elevation;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public char Elevation { get; set; }

            public override bool Equals(object? obj)
            {
                if(obj == null) return false;

                Position pos = (Position)obj;
                return pos.X == this.X && pos.Y == this.Y;
            }
        }

        public class Path
        {
            public List<Position> Positions { get; set; } = new List<Position>();
            public Direction NextDirection { get; set; } = Direction.None;
        }

        public enum Direction
        {
            None,
            Up,
            Down,
            Left,
            Right
        }
    }
}
