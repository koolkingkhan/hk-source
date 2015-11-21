using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hussain.Infra.Core;
using Hussain.Infra.Events;
using Hussain.Infra.Model;
using Prism.Events;

namespace Hussain.Services.Utility
{
    public class ViewModelServices : IViewModelServices
    {
        public const string DataFile = @"X:\Work\SOURCE\src\BlotterCode\data.txt";

        private readonly char[] Delimiter = {':'};
        private readonly IEventAggregator _eventAgg;

        public ViewModelServices(IEventAggregator evt)
        {
            _eventAgg = evt;
        }

        public IObservable<Timestamped<long>> DateTimeTicker
        {
            get { return Observable.Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1)).Timestamp(); }
        }

        public IObservable<IList<IBlotterData>> BlotterData
        {
            get
            {
                return
                    Observable.FromEventPattern<IBlotterData>(
                        evt => BlotterEvent += evt,
                        evt => BlotterEvent -= evt
                        ).
                        Select(i => i.EventArgs).AsObservable()
                        .Do(a => { })
                        .DistinctUntilChanged()
                        .Buffer(TimeSpan.FromSeconds(20.87), 1000);
            }
        }


        public void ContinuouslyReadPricesAsync(CancellationToken token)
        {
            double id = 0;
            Task.Factory.StartNew(() =>
            {
                if (File.Exists(DataFile))
                {
                    using (var reader = new BinaryReader(File.Open(DataFile, FileMode.Open, FileAccess.Read)))
                    {
                        var ms = new MemoryStream();
                        var sb = new StringBuilder();
                        while (true)
                        {
                            if (token.IsCancellationRequested)
                            {
                                NotifyFileReadingComplete();
                                break;
                            }

                            sb.Clear();
                            if (reader.PeekChar() == -1)
                            {
                                if (ms.Length > 0)
                                {
                                    var outBuffer = ms.GetBuffer();
                                    var size = (int) ms.Length;

                                    sb.Append(Encoding.ASCII.GetString(outBuffer, 0, size));

                                    id = GetAndPublishData(sb.ToString(), id);
                                    ms.SetLength(0);
                                    sb.Clear();
                                }
                                reader.BaseStream.Seek(0L, SeekOrigin.Begin);
                            }
                            var aByte = reader.ReadBytes(1);

                            if (aByte[0] == 10)
                            {
                                sb.Clear();
                                var outBuffer = ms.GetBuffer();
                                var size = (int) ms.Length;
                                sb.Append(Encoding.ASCII.GetString(outBuffer, 0, size));
                                id = GetAndPublishData(sb.ToString(), id);

                                ms.SetLength(0);
                                sb.Clear();
                            }
                            else
                            {
                                ms.Write(aByte, 0, 1);
                            }
                        }
                    }
                }
                else
                {
                    throw new FileNotFoundException(DataFile);
                }
            }, token);
        }

        private event EventHandler<IBlotterData> BlotterEvent = delegate { };


        private void NotifyFileReadingComplete()
        {
            _eventAgg.GetEvent<FileReadCompleteEvent>().Publish(EventArgs.Empty);
        }

        private double GetAndPublishData(string tickerLine, double id)
        {
            id = id + 1;

            var items = tickerLine.Split(Delimiter, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length != 2)
            {
                throw new ArgumentException("malformed ticker data !");
            }

            double price = 0;
            if (double.TryParse(items[1], out price))
            {
                BlotterEvent(this, new BlotterData {TickerPrice = price, TickerCode = items[0], Id = id});
            }
            else
            {
                throw new ApplicationException(string.Format("Unable to parse {0} as a price ", items[1]));
            }
            return id;
        }
    }
}