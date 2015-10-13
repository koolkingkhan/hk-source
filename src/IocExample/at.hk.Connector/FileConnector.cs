using System;
using System.IO;
using System.Linq;

namespace at.hk.Connector
{
    public class FileConnector : IConnector
    {
        #region Implementation of IConnector

        public void Connect(string url)
        {
            MemoryStream ms = new MemoryStream();
            {
                using (FileStream fileStream = new FileStream(url, FileMode.Open, FileAccess.Read))
                {
                    fileStream.CopyTo(ms);
                    fileStream.Flush();
                }

                if (DataReceivedHandler != null)
                {
                    DataReceivedHandler(this,new DataReceivedEventArgs(ms));
                }
            }
        }

        public event EventHandler<DataReceivedEventArgs> DataReceivedHandler;

        #endregion
    }
}