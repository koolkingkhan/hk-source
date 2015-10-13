using System.Collections.Generic;
using System.IO;

namespace hk.DirectoryComparer
{
    public class Comparer
    {
        private enum Directories
        {
            Directory1 = 1, Directory2
        }

        public Comparer()
            : this(string.Empty, string.Empty)
        { }

        public List<FileProperties> Files { get; set; }

        public Comparer(string path1, string path2)
        {
            DirectoryPath1 = path1;
            DirectoryPath2 = path2;

            Files = new List<FileProperties>();
        }

        public string DirectoryPath1 { get; set; }

        public string DirectoryPath2 { get; set; }

        public void Compare()
        {
            if (string.IsNullOrEmpty(DirectoryPath1) || string.IsNullOrEmpty(DirectoryPath2))
                return;

            DirectoryTree directory1 = new DirectoryTree(DirectoryPath1);
            directory1.CreateDirectoryTree();

            DirectoryTree directory2 = new DirectoryTree(DirectoryPath2);
            directory2.CreateDirectoryTree();

            CompareDirectories(directory1, directory2);
        }

        private void CompareDirectories(DirectoryTree directoryTree1, DirectoryTree directoryTree2)
        {
            //Iterate through the various folder levels from the initial directory supplied
            for (int folderLevel = 0; folderLevel < directoryTree1.Count; folderLevel++)
            {
                List<DirectoryInfo> listDirectory1, listDirectory2;
                if (!directoryTree2.TryGetValue(folderLevel, out listDirectory2) || !directoryTree1.TryGetValue(folderLevel, out listDirectory1))
                {
                    //Continue if current folder level doesn't exist, as we only wish to compare files that share the same hierarchy
                    continue;
                }

                foreach (DirectoryInfo directoryInfo1 in listDirectory1)
                {
                    foreach (DirectoryInfo directoryInfo2 in listDirectory2)
                    {
                        if (FolderHierarchyMatch(directoryInfo2, directoryInfo1))
                        {
                            CompareFilesInDirectories(directoryInfo1, directoryInfo2);
                        }
                    }
                }
            }
        }

        private bool FolderHierarchyMatch(DirectoryInfo directoriesFromDirectoryPath1, DirectoryInfo directoriesFromDirectoryPath2)
        {
            //string path1 = GetPathWithoutRootComparisonFolder(directoriesFromDirectoryPath1.FullName);
            //string path2 = GetPathWithoutRootComparisonFolder(directoriesFromDirectoryPath2.FullName);

            //return path1.Equals(path2, StringComparison.OrdinalIgnoreCase);
            return true;
        }

        private string GetPathWithoutRootComparisonFolder(string p)
        {
            if (p.Contains(DirectoryPath1))
                return p.Remove(0, DirectoryPath1.Length);

            if (p.Contains(DirectoryPath2))
                return p.Remove(0, DirectoryPath2.Length);

            return p;
        }

        private void CompareFilesInDirectories(DirectoryInfo directoryInfo1, DirectoryInfo directoryInfo2)
        {
            FileInfo[] files = directoryInfo1.GetFiles("*", SearchOption.AllDirectories);

            SearchForFilesInDirectory(files, directoryInfo2, Directories.Directory1);
        }

        private void SearchForFilesInDirectory(IEnumerable<FileInfo> files, DirectoryInfo directoryInfo, Directories directories)
        {
            foreach (FileInfo file in files)
            {
                string fileNameInCompareDirectory;
                if (TryFindFile(file.Name, directoryInfo, out fileNameInCompareDirectory))
                {
                    AddFiles(file.FullName, fileNameInCompareDirectory);
                }
                else
                {
                    //TODO: fix for added files
                    AddFiles(file.FullName, string.Empty);
                }
            }
        }

        private void AddFiles(string fileNameInDirectory1, string fileNameInDirectory2)
        {
                Files.Add(new FileProperties
                                {
                                    FileNameInDirectory1 = fileNameInDirectory1,
                                    FileNameInDirectory2 = fileNameInDirectory2
                                });
        }

        private string GetCommonFolderName(string fileNameInDirectory1, string fileNameInDirectory2)
        {
            string commonName = fileNameInDirectory1.Remove(0, DirectoryPath1.Length);

            //TODO: Fix
            //if (!fileNameInDirectory2.EndsWith(commonName))
            //    throw new ApplicationException("Could not find common hierarchy");

            return commonName;
        }

        private static bool TryFindFile(string searchPattern, DirectoryInfo directoryInfo, out string fileNameInDirectory2)
        {
            fileNameInDirectory2 = string.Empty;

            FileInfo[] fileInfo = directoryInfo.GetFiles(searchPattern, SearchOption.AllDirectories);
            if (fileInfo.Length > 0)
            {
                fileNameInDirectory2 = fileInfo[0].FullName;
            }

            return !string.IsNullOrEmpty(fileNameInDirectory2);
        }

        private static string FileInfoToFullName(FileInfo fileInfo)
        {
            return fileInfo.FullName;
        }
    }
}
