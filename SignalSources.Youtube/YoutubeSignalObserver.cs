using SignalsSources.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalSources.Youtube
{
    public class YoutubeSignalObserver : IYoutubeSignalObserver, ISignalObserver
    {
        private readonly ISignalObserver signalObserver;

        public IEnumerable<ISignal> CurrentSignals => this.signalObserver.CurrentSignals;

        public ISignalSourceProvider SignalSourceProvider { private get;  set; }

        public event Action<ISignal> NewSignalsEvent;
        
        public YoutubeSignalObserver(ISignalObserver signalObserver, IYouTubeSignalProvider youTubeSignalProvider)
        {
            this.SignalSourceProvider = youTubeSignalProvider;
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
