using SignalsSources.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalSources.Twitter
{
    public class TwitterSignalObserver : ITwitterSignalObserver, ISignalObserver
    {
        private readonly ISignalObserver signalObserver;

        public IEnumerable<ISignal> CurrentSignals => this.signalObserver.CurrentSignals;

        public event Action<ISignal> NewSignalsEvent;
        public ISignalSourceProvider SignalSourceProvider { private get; set; }

        public TwitterSignalObserver(ISignalObserver signalObserver, ITwitterSignalProvider twitterSignalProvider)
        {
            this.SignalSourceProvider = twitterSignalProvider;
            this.signalObserver = signalObserver;
            this.signalObserver.SignalSourceProvider = this.SignalSourceProvider;
            this.signalObserver.NewSignalsEvent += this.SignalObserver_NewSignalsEvent;
        }

        private void SignalObserver_NewSignalsEvent(ISignal obj)
        {
            NewSignalsEvent?.Invoke(obj);
        }

        public async Task BeginObservationAsync(IEnumerable<string> profileName, DateTimeOffset publishedAfter)
        {
            await this.signalObserver.BeginObservationAsync(profileName, publishedAfter);
        }
    }
}
