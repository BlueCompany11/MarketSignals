using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalsSources.Interfaces
{
    public interface ISignalObserver
    {
        event Action<ISignal> NewSignalsEvent;
        IEnumerable<ISignal> CurrentSignals { get; }
        Task BeginObservationAsync(IEnumerable<string> profileName, DateTimeOffset publishedAfter);
        public ISignalSourceProvider SignalSourceProvider { set; }
    }
}
