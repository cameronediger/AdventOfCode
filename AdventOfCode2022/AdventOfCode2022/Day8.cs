namespace AdventOfCode2022
{
    public class Day8 : BaseDay
    {
        private IList<TreeRow> _treeArray = new List<TreeRow>();
        public override void Run()
        {
            base.Run();

            Console.WriteLine($"Day8 - Visible Tree Count: {GetVisibleTreeCount()} ");
            Console.WriteLine($"Day8 - Max Scenic Score: {GetMaxScenicScore()} ");
        }

        public override void ProcessData()
        {
            LoadTreeArray();
            ProcessTrees();
        }

        private void LoadTreeArray()
        {
            int rowCount = _inputData.Count();
            int rowIndex = 0;
            foreach(var row in _inputData)
            {
                int colIndex = 0;
                var treeRow = new TreeRow();
                foreach(var t in row)
                {
                    var v = (rowIndex == 0 || rowIndex == rowCount-1 || colIndex == 0 || colIndex == row.Count() - 1) ? TreeVisible.Visible : TreeVisible.Unknown;
                    treeRow.Trees.Add(new Tree(colIndex, rowIndex, Convert.ToInt32(t.ToString()), v));
                    colIndex++;
                }

                _treeArray.Add(treeRow);
                rowIndex++;
            }
        }

        private void ProcessTrees()
        {
            for(var row=1; row < _treeArray.Count(); row++)
            {
                for(var col=1; col < _treeArray[row].Trees.Count(); col++)
                {
                    _treeArray[row].Trees[col].Visible = CheckTree(row, col);
                    _treeArray[row].Trees[col].ScenicScore = CalculateScenicScore(row, col);
                }
            }
        }

        private TreeVisible CheckTree(int row, int col)
        {
            Tree tree = _treeArray[row].Trees[col];

            //Check Row
            var rowVisible = TreeVisible.Visible;
            var tr = _treeArray[row].Trees.Where(t => t.Height >= tree.Height);
            if(tr.Any(t => t.X < tree.X) && tr.Any(t => t.X > tree.X))
            {
                rowVisible = TreeVisible.NotVisible;
            }
            
            //Check Column
            var colVisible = TreeVisible.Visible;
            var tc = _treeArray.Where(t => t.Trees[col].Height >= tree.Height);
            if(tc.Any(t => t.Trees[col].Y < tree.Y) && tc.Any(t => t.Trees[col].Y > tree.Y))
            {
                colVisible = TreeVisible.NotVisible;
            }

            return (colVisible == TreeVisible.NotVisible && rowVisible == TreeVisible.NotVisible) ? TreeVisible.NotVisible : TreeVisible.Visible;
        }

        private int CalculateScenicScore(int row, int col)
        {
            Tree tree = _treeArray[row].Trees[col];

            //Check Left
            int leftCount = 0;
            for(var n=col-1; n >= 0; n--)
            {
                leftCount++;   

                if (_treeArray[row].Trees[n].Height >= tree.Height)
                    break;
            }

            //Check Right
            int rightCount = 0;
            for(var n=col+1; n < _treeArray[row].Trees.Count; n++)
            {
                rightCount++;

                if (_treeArray[row].Trees[n].Height >= tree.Height)
                    break;
            }

            //Check Up
            int upCount = 0;
            for(var n=row-1; n >= 0; n--)
            {
                upCount++;
                
                if (_treeArray[n].Trees[col].Height >= tree.Height)
                    break;
            }

            //Check Down
            int downCount = 0;
            for(var n=row+1; n < _treeArray.Count(); n++)
            {
                downCount++;

                if (_treeArray[n].Trees[col].Height >= tree.Height)
                    break;
            }

            return (leftCount*rightCount*upCount*downCount);
        }

        public int GetVisibleTreeCount()
        {
            int count = 0;
            foreach(var row in _treeArray)
            {
                count += row.Trees.Count(t => t.Visible == TreeVisible.Visible);
            }

            return count;
        }

        public int GetMaxScenicScore()
        {
            return _treeArray.Max(tr => tr.Trees.Max(t => t.ScenicScore));
        }

        public class TreeRow
        {
            public IList<Tree> Trees { get; set; } = new List<Tree>();
        }

        public class Tree
        {
            public Tree(int x, int y, int height, TreeVisible visible=TreeVisible.Unknown)
            {
                X = x;
                Y = y;
                Height = height;
                Visible = visible;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Height { get; set; }
            public TreeVisible Visible { get; set; }
            public int ScenicScore { get; set; }
        }

        public enum TreeVisible
        {
            Unknown = -1,
            NotVisible = 0,
            Visible = 1
        }
    }
}
