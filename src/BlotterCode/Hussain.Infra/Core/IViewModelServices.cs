using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading;
using Hussain.Infra.Model;

namespace Hussain.Infra.Core
{
    public interface IViewModelServices
    {
        IObservable<IList<IBlotterData>> BlotterData { get; }


        IObservable<Timestamped<long>> DateTimeTicker { get; }

        void ContinuouslyReadPricesAsync(CancellationToken token);
    }
}