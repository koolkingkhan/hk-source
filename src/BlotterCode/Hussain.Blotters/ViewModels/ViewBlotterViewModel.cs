using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Data;
using Hussain.Blotters.TemplateSelectors;
using Hussain.Infra.Core;
using Hussain.Infra.Events;
using Hussain.Infra.Model;
using Hussain.Infra.Utility;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace Hussain.Blotters.ViewModels
{
    public class ViewBlotterViewModel : BindableBase, IViewBlotterViewModel, IInteractionRequestAware
    {
        private const int MaxPricesToKeep = 10;
        private readonly SynchronizationContext _ctx;

        private ObservableCollection<IBlotterData> _data;
        private ObservableCollection<IBlotterDataLatestPrices> _dataLatestPrices;
        private readonly IEventAggregator _eventAgg;

        private PriceColourSelector _previousSelector;

        private IBlotterData _selectedRow;
        private readonly IViewModelServices _services;

        private PriceColourSelector _templateSelector;

        private ICollectionView _viewLatestPrices;

        private readonly CancellationTokenSource cToken = new CancellationTokenSource();

        public ViewBlotterViewModel(IEventAggregator evt, IViewModelServices services)
        {
            _ctx = SynchronizationContext.Current;
            _services = services;
            _eventAgg = evt;

            Data = new ObservableCollection<IBlotterData>();
            DataLatestPrices = new ObservableCollection<IBlotterDataLatestPrices>();
            ViewLatestPrices = CollectionViewSource.GetDefaultView(DataLatestPrices);

            ViewLatestPrices.SortDescriptions.Add(new SortDescription("TimeStamp", ListSortDirection.Ascending));

            ViewLatestPrices.Filter +=
                o =>
                {
                    return SelectedRow != null && ((IBlotterDataLatestPrices) o).TickerCode == SelectedRow.TickerCode;
                };

            CloseCommand = new DelegateCommand(DoClose, () => { return true; });
            ExitCommand = new DelegateCommand(DoExit, () => { return true; });
            ViewCommand = new DelegateCommand(DoView, () => { return SelectedRow != null; });
            ConfirmExitRequest = new InteractionRequest<Confirmation>();
            ViewLatestPricesRequest = new InteractionRequest<Notification>();

            GlobalCommands.GlobalExitCommand.RegisterCommand(ExitCommand);
            GlobalCommands.GlobalViewCommand.RegisterCommand(ViewCommand);
            _eventAgg.GetEvent<FileReadCompleteEvent>()
                .Subscribe(i => { _eventAgg.GetEvent<ExitEvent>().Publish(EventArgs.Empty); });


            var els = new EventLoopScheduler();


            var obs =
                services.BlotterData
                    .SubscribeOn(Scheduler.Default)
                    .Subscribe(item =>
                    {
                        foreach (var i in item)
                        {
                            Console.WriteLine("ID={0}, Ticker={1}, Price={2}", i.Id, i.TickerCode, i.TickerPrice);

                            UpdateLatestPrices(i);
                            var avgPrice = GetAvgPrice(i);
                            if (Data.Contains(i))
                            {
                                var pos = Data.IndexOf(i);
                                UpdateTicker(pos, i.TickerPrice, avgPrice);


                                _ctx.Post(
                                    o =>
                                    {
                                        _eventAgg.GetEvent<StatusEvent>()
                                            .Publish(string.Format("Update: TickerCode [{0}] with price {1}",
                                                i.TickerCode, i.TickerPrice));
                                    }, null);
                            }
                            else
                            {
                                InsertTicker(i);
                                _ctx.Send(
                                    o =>
                                    {
                                        _eventAgg.GetEvent<StatusEvent>()
                                            .Publish(string.Format("Insert: TickerCode [{0}] with price {1}",
                                                i.TickerCode, i.TickerPrice));
                                    }, null);
                            }
                        }
                    });


            _services.ContinuouslyReadPricesAsync(cToken.Token);
        }

        public PriceColourSelector PreviousTemplateSelector
        {
            get { return _previousSelector; }
            set { SetProperty(ref _previousSelector, value); }
        }

        public PriceColourSelector TemplateSelector
        {
            get { return _templateSelector; }
            set { SetProperty(ref _templateSelector, value); }
        }


        public DelegateCommand CloseCommand { get; set; }

        private ObservableCollection<IBlotterDataLatestPrices> DataLatestPrices
        {
            get { return _dataLatestPrices; }
            set { SetProperty(ref _dataLatestPrices, value); }
        }

        public ICollectionView ViewLatestPrices
        {
            get { return _viewLatestPrices; }
            set { SetProperty(ref _viewLatestPrices, value); }
        }

        public ObservableCollection<IBlotterData> Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        public IBlotterData SelectedRow
        {
            get { return _selectedRow; }
            set
            {
                SetProperty(ref _selectedRow, value);
                ViewCommand.RaiseCanExecuteChanged();
                ViewLatestPrices.Refresh();
            }
        }

        private DelegateCommand ExitCommand { get; set; }
        private DelegateCommand ViewCommand { get; set; }
        public InteractionRequest<Confirmation> ConfirmExitRequest { get; set; }
        public InteractionRequest<Notification> ViewLatestPricesRequest { get; set; }


        public Action FinishInteraction { get; set; }


        public INotification Notification { get; set; }

        private void RefreshSelector()
        {
            TemplateSelector = new PriceColourSelector();
        }

        private void RefreshPreviousSelector()
        {
            PreviousTemplateSelector = new PriceColourSelector();
        }

        private void ProcessData(IList<IBlotterData> data)
        {
            var s = new List<string>();

            foreach (var i in data)
            {
                Console.WriteLine("{0}  {1}", i.TickerCode, i.TickerPrice);
            }
        }

        private bool DoFilter(object o)
        {
            return true;
        }


        private void UpdateTicker(int pos, double price, double avgPrice)
        {
            _ctx.Send(UpdateCallback, new {Postion = pos, TickerPrice = price, AvgPrice = avgPrice});
        }

        private void InsertTicker(IBlotterData item)
        {
            _ctx.Send(InsertCallback, item);
        }

        private void InsertCallback(object o)
        {
            Data.Add((IBlotterData) o);
        }

        private void UpdateCallback(object o)
        {
            var arg = Anonymous.Cast(o, new {Postion = 0, TickerPrice = 0.0, AvgPrice = 0.0});

            Data[arg.Postion].TickerPreviousPrice = Data[arg.Postion].TickerPrice;
            Data[arg.Postion].TickerPrice = arg.TickerPrice;
            Data[arg.Postion].TickerAvgPrice = arg.AvgPrice;
            RefreshSelector();
        }

        private void DoClose()
        {
            FinishInteraction();
        }

        private void DoView()
        {
            ViewLatestPricesRequest.Raise(new Notification {Content = this, Title = "Latest prices"});
        }

        private double GetAvgPrice(IBlotterData data)
        {
            var now = DateTime.Now;
            var recs = from r in DataLatestPrices
                where r.TickerCode == data.TickerCode && r.TimeStamp <= now
                select r;

            var firstFive = recs.Take(5);
            var agg = from a in firstFive
                group a by a.TickerCode
                into newgroup
                select new {AvgPrice = newgroup.Average(i => i.TickerPrice)};

            if (firstFive.Count() == 5)
            {
                var f = agg.FirstOrDefault();
                return f.AvgPrice;
            }
            return 0.0;
        }

        private void UpdateLatestPrices(IBlotterData data)
        {
            if (data == null)
            {
                return;
            }
            var now = DateTime.Now;
            var recs = from r in DataLatestPrices
                where r.TickerCode == data.TickerCode && r.TimeStamp <= now
                orderby r.TimeStamp ascending
                select r;

            if (recs.Count() < MaxPricesToKeep)
            {
                _ctx.Send(
                    o =>
                    {
                        DataLatestPrices.Add(new BlotterDataLatestPrices
                        {
                            TickerCode = data.TickerCode,
                            TickerPrice = data.TickerPrice,
                            TimeStamp = now
                        });
                    }, null);
            }
            else if (recs.Count() == MaxPricesToKeep)
            {
                var toSwapOut = recs.First();
                toSwapOut.TickerPreviousPrice = toSwapOut.TickerPrice;
                toSwapOut.TickerPrice = data.TickerPrice;
                toSwapOut.TimeStamp = now;
                RefreshPreviousSelector();
            }
            else
            {
                throw new ApplicationException("Uncatered option - Count is" + recs.Count());
            }
        }

        private void DoExit()
        {
            ConfirmExitRequest.Raise(
                new Confirmation {Content = "Are you sure you wish to exit ?", Title = "Exit Application ?"},
                conf =>
                {
                    if (conf.Confirmed)
                    {
                        cToken.Cancel();
                    }
                });
        }
    }
}