using SignalsSources.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalSources.Twitter
{
    public class TwitterObserver: ITwitterSignalObserver
    {
        public event Action<ISignal> NewSignalsEvent;

        private Dictionary<string, ISignal> signals = new();
        private readonly ITwitterSignalProvider twitterSignalProvider;
        private readonly ISignalIdentifierProvider signalIdentifierProvider;
        public IEnumerable<ISignal> CurrentSignals => this.signals.Values;

        public TwitterObserver(ITwitterSignalProvider twitterSignalProvider, ISignalIdentifierProvider signalIdentifierProvider)
        {
            this.twitterSignalProvider = twitterSignalProvider;
            this.signalIdentifierProvider = signalIdentifierProvider;
        }
        public async Task BeginObservationAsync(IEnumerable<string> profileName, DateTimeOffset publishedAfter)
        {
            foreach (string name in profileName)
            {
                var signals = await this.twitterSignalProvider.GetSignalsAsync(name, publishedAfter);
                foreach (var item in signals)
                {
                    string id = this.signalIdentifierProvider.GetSignalIdentify(item);
                    if (!this.signals.ContainsKey(id))
                    {
                        this.signals.Add(id, item);
                        NewSignalsEvent?.Invoke(item);
                    }
                }
            }
            
        }
    }
}
