using System;
using System.IO;

namespace at.hk.Connector
{
    public class FileConnector : IConnector
    {
        #region Implementation of IConnector

        public void Connect(string url)
        {
            var ms = new MemoryStream();
            {
                using (var fileStream = new FileStream(url, FileMode.Open, FileAccess.Read))
                {
                    fileStream.CopyTo(ms);
                    fileStream.Flush();
                }

                if (DataReceivedHandler != null)
                {
                    DataReceivedHandler(this, new DataReceivedEventArgs(ms));
                }
            }
        }

        public event EventHandler<DataReceivedEventArgs> DataReceivedHandler;

        #endregion
    }
}