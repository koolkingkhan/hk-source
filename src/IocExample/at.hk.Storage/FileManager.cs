using System;
using System.IO;

namespace at.hk.Storage
{
    public class FileManager : IDisposable
    {
        private const string DefaultFolder = "Home";
        private readonly string _fileName;

        private string _fullName;

        private bool _disposed;

        public FileManager(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new ArgumentException(file);

            _fileName = Path.ChangeExtension(file, ".xml");
        }

        internal virtual string CreateHomeDirectory()
        {
            string currentDir = Environment.CurrentDirectory;

            if (string.IsNullOrEmpty(currentDir))
            {
                throw new DirectoryNotFoundException(currentDir);
            }

            string defaultDir = Path.Combine(currentDir, DefaultFolder);

            if (!Directory.Exists(defaultDir))
            {
                Directory.CreateDirectory(defaultDir);
            }

            return defaultDir;                
        }

        internal string FullName 
        {
          get
          {
              if (string.IsNullOrEmpty(_fullName))
              {
                  string defaultDir = CreateHomeDirectory();
                  _fullName = Path.Combine(defaultDir, _fileName);
              }

              return _fullName;
          }
        } 

        internal bool CleanUp { get; set; }

        internal virtual Stream GetStream(FileMode fileMode)
        {
            return new FileStream(FullName, fileMode);
        }

        internal virtual bool FileExists
        {
            get
            {
                return File.Exists(FullName);   
            }
        }

        internal virtual bool DirectoryExists
        {
            get
            {
                string directory = Path.GetDirectoryName(FullName);

                return !string.IsNullOrEmpty(directory) && Directory.Exists(directory);   
            }
        }

        internal void DeleteFiles()
        {
            if (CleanUp && File.Exists(FullName))
            {
                File.Delete(FullName);
            }
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                DeleteFiles();

                _disposed = true;
            }
        }

        #endregion
    }
}
