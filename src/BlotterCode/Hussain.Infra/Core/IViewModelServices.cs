using System.Reactive.Linq;
using System.Reactive.Linq;
using Hussain.Infra.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hussain.Infra.Core
{
    public interface IViewModelServices
    {
        IObservable<IList<IBlotterData>> BlotterData { get; }

         

        IObservable<Timestamped<long>> DateTimeTicker { get; }

        void ContinuouslyReadPricesAsync(CancellationToken token);     
    }
}
