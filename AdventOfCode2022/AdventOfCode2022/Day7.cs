namespace AdventOfCode2022
{
    public class Day7 : BaseDay
    {
        private const long TotalDiskSpace = 70000000;
        private const long NeededAvailable = 30000000;

        public long DirectorySum 
        { 
            get 
            {
                return _dirSizes.Where(s => s <= 100000).Sum(); 
            } 
        }

        private Directory _fileSystem;
        private List<string> _currPath = new List<string>();
        private List<long> _dirSizes = new List<long>();

        public override void Run()
        {
            base.Run();

            Console.WriteLine($"Day8 - {this.GetType().Name.ToLower()}");
            Console.WriteLine($"Day7 - Directory Sum: {DirectorySum}");
            Console.WriteLine($"Day7 - Folder Size To Delete: {GetFolderToDeleteSize()}");
        }

        public long GetFolderToDeleteSize()
        {
            var availSpace = TotalDiskSpace - _fileSystem.GetSize();
            var toClear = NeededAvailable - availSpace;

            return _dirSizes.Where(s => s >= toClear).Min();
        }

        public override void ProcessData()
        {
            Directory currDir = null;
            foreach(var line in _inputData)
            {
                var split = line.Split(' ');
                if(split[0] == "$")
                {
                    if (split[1] == "cd")
                    {
                        if (split[2] == "..")
                        {
                            _currPath.RemoveAt(_currPath.Count-1);
                            currDir = GetCurrentDirectory();
                        }
                        else
                        {
                            if (_fileSystem == null && currDir == null)
                            {
                                _fileSystem = new Directory(split[2], 0);
                                currDir = _fileSystem;
                            }
                            else
                            {
                                _currPath.Add(split[2]);
                                currDir = GetCurrentDirectory();
                            }
                        }
                    }
                    else if (split[1] == "ls")
                    {
                    }
                }
                else
                {
                    if (split[0] == "dir")
                    {
                        currDir.Add(new Directory(split[1], 0));
                    }
                    else
                    {
                        currDir.Add(new File(split[1], Convert.ToInt64(split[0])));
                    }
                }
            }

            foreach (var dir in _fileSystem.Items.OfType<Directory>())
            {
                ProcessDirectory(dir);
            }
        }

        public Directory GetCurrentDirectory()
        {
            Directory result = null;
            foreach(var dir in _currPath)
            {
                if (result == null)
                    result = (Directory)_fileSystem.Items.First(d => d.Name.Equals(dir));
                else
                    result = (Directory)result.Items.First(d => d.Name.Equals(dir));
            }

            return result;
        }

        private void ProcessDirectory(Directory dir)
        {
            var size = dir.GetSize();
            _dirSizes.Add(size);

            foreach (var d in dir.Items.OfType<Directory>())
            {
                ProcessDirectory(d);
            }
        }

        public abstract class FileSystemItem
        {
            public string Name { get; set; }
            public abstract long GetSize();

            protected FileSystemItem(string name)
            {
                Name = name;
            }
        }

        public class File : FileSystemItem
        {
            private readonly long _size;
            public File(string name, long size) : base(name)
            {
                _size = size;
            }

            public override long GetSize()
            {
                return _size;
            }
        }

        public class Directory : FileSystemItem
        {
            private long _size;
            public List<FileSystemItem> Items { get; set; } = new List<FileSystemItem>();

            public Directory(string name, long size) : base(name)
            {
                _size = size;
            }

            public void Add(FileSystemItem item)
            {
                Items.Add(item);
            }

            public override long GetSize()
            {
                var result = _size;
                foreach(var item in Items)
                {
                    result += item.GetSize();
                }

                return result;
            }
        }
    }
}
