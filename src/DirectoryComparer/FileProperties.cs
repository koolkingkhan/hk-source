using System.IO;

namespace hk.DirectoryComparer
{
    public class FileProperties
    {
        private FileInfo _fileNameInDirectory1;
        private FileInfo _fileNameInDirectory2;

        private bool? _identical;

        public string FileNameInDirectory1
        {
            get { return null != _fileNameInDirectory1 ? _fileNameInDirectory1.FullName : null; }
            set { _fileNameInDirectory1 = !string.IsNullOrEmpty(value) ? new FileInfo(value) : null; }
        }

        public string FileNameInDirectory2
        {
            get { return null != _fileNameInDirectory2 ? _fileNameInDirectory2.FullName : null; }
            set { _fileNameInDirectory2 = !string.IsNullOrEmpty(value) ? new FileInfo(value) : null; }
        }


        public bool? Identical
        {
            get
            {
                if (!(string.IsNullOrEmpty(FileNameInDirectory1) || string.IsNullOrEmpty(FileNameInDirectory2)))
                {
                    _identical = _fileNameInDirectory1.Length == _fileNameInDirectory2.Length;
                }

                return _identical;
            }
        }

        public string LatestFile
        {
            get
            {
                if (Identical.HasValue)
                {
                    return _fileNameInDirectory1.LastWriteTime > _fileNameInDirectory2.LastWriteTime
                        ? FileNameInDirectory1
                        : FileNameInDirectory2;
                }

                if (null != _fileNameInDirectory1)
                {
                    return _fileNameInDirectory1.FullName;
                }

                return null != _fileNameInDirectory2 ? _fileNameInDirectory2.FullName : null;
            }
        }
    }
}