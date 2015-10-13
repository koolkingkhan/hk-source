using System;

namespace at.hk.Connector
{
    public interface IConnector
    {
        void Connect(string url);

        event EventHandler<DataReceivedEventArgs> DataReceivedHandler;
    }
}