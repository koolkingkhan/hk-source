using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace at.hk.Connector
{
    public class DataReceivedEventArgs : EventArgs
    {
        public MemoryStream Data { get; set; }

        public DataReceivedEventArgs(MemoryStream data)
        {
            Data = data;
        }
    }
}
