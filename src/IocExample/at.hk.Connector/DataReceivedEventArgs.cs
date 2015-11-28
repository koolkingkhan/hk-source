using System;
using System.IO;

namespace at.hk.Connector
{
    public class DataReceivedEventArgs : EventArgs
    {
        public DataReceivedEventArgs(MemoryStream data)
        {
            Data = data;
        }

        public MemoryStream Data { get; set; }
    }
}