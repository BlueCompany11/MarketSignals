using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalSources.Interfaces
{
    public interface ISignalObserver
    {
        event Action<ISignal> NewSignalsEvent;
        Task BeingObservationAsync();
        void CancelObservation();
    }
}
