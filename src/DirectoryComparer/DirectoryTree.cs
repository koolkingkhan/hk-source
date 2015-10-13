using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace hk.DirectoryComparer
{
    internal class DirectoryTree
    {
        private const int BASELEVEL = 0;

        private readonly DirectoryInfo _topLevelDirectory;
        private Dictionary<int, List<DirectoryInfo>> _directoryStructure;

        public DirectoryTree(string directoryPath)
        {
            _topLevelDirectory = new DirectoryInfo(directoryPath);
        }

        public void CreateDirectoryTree()
        {
            InitialiseDictionary();

            try
            {
                DirectoryInfo[] directories = _topLevelDirectory.GetDirectories("*", SearchOption.AllDirectories);

                foreach (var directoryInfo in directories)
                {
                    int directoryLevel = DistanceFromParent(directoryInfo, _directoryStructure.First().Key);
                    if (_directoryStructure.ContainsKey(directoryLevel))
                    {
                        _directoryStructure[directoryLevel].Add(directoryInfo);
                    }
                    else
                    {
                        _directoryStructure.Add(directoryLevel, new List<DirectoryInfo> { directoryInfo });
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Cannot access some directories, just continue
            }
        }

        internal List<DirectoryInfo> this[int nestingLevel]
        {
            get
            {
                List<DirectoryInfo> list;
                
                return _directoryStructure.TryGetValue(nestingLevel, out list) ? list : new List<DirectoryInfo>();
            }
        }

        internal int Count
        {
            get
            {
                return null != _directoryStructure ? _directoryStructure.Count : 0;
            }
        }

        internal bool TryGetValue(int folderLevel, out List<DirectoryInfo> list)
        {
            return _directoryStructure.TryGetValue(folderLevel, out list);
        }

        private void InitialiseDictionary()
        {
            if (null != _directoryStructure)
            {
                return;
            }

            _directoryStructure = new Dictionary<int, List<DirectoryInfo>>();
            _directoryStructure.Add(BASELEVEL, new List<DirectoryInfo> { _topLevelDirectory });
        }

        private int DistanceFromParent(DirectoryInfo parentDirectoryInfo, int nestingLevel)
        {
            nestingLevel++;

            if (parentDirectoryInfo.Parent.FullName.Equals(_topLevelDirectory.FullName, StringComparison.OrdinalIgnoreCase))
                return nestingLevel;

            return DistanceFromParent(parentDirectoryInfo.Parent, nestingLevel);
        }
    }
}
