using System;
using at.hk.Connector;
using at.hk.IocContainer;
using at.hk.Parser;
using at.hk.Storage;

namespace at.hk.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var resolver = new Resolver();
            resolver.Register<IConnector, FileConnector>();
            resolver.Register<IParser<Tweet>, TwitterParser>();
            resolver.Register<IStorageManager, FileStorageManager>();

            var connector = resolver.Resolve<IConnector>();
            var parser = resolver.Resolve<IParser<Tweet>>();
            var storageManager = resolver.Resolve<IStorageManager>();

            connector.DataReceivedHandler += (sender, eventArgs) => parser.Parse(eventArgs.Data);
            parser.DataExtractedHandler += (sender, eventArgs) => storageManager.Save("TestFile", eventArgs.Data);

            connector.Connect(@"..\..\..\Samples\tweets.txt");

            Console.Read();
        }
    }
}