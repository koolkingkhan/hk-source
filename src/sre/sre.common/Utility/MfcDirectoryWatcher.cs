using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.IO;

namespace Ubs.Collateral.Sre.Common.Utility
{
    public class MfcDirectoryWatcher : IMfcDirectoryWatcher
    {
        private readonly FileSystemWatcher _watcher;

        public MfcDirectoryWatcher()
        {
            _watcher = new FileSystemWatcher();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Initialise(string path)
        {
            _watcher.Path = path;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            // Only watch text files.
            _watcher.Filter = "*.txt";
            _watcher.IncludeSubdirectories = true;

            // Add event handlers.
            _watcher.Changed += new FileSystemEventHandler(OnChanged);
            _watcher.Created += new FileSystemEventHandler(OnChanged);
            _watcher.Deleted += new FileSystemEventHandler(OnChanged);
            _watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            _watcher.EnableRaisingEvents = true;
        }

        // Define the event handlers. 
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
