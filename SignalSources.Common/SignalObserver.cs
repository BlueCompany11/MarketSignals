using SignalsSources.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalSources.Common
{
    public class SignalObserver: ISignalObserver 
    {
        public event Action<ISignal> NewSignalsEvent;

        private Dictionary<string, ISignal> signals = new();
        private readonly ISignalIdentifierProvider signalIdentifierProvider;
        public IEnumerable<ISignal> CurrentSignals => this.signals.Values;

        public ISignalSourceProvider SignalSourceProvider { private get; set; }

        public SignalObserver(ISignalIdentifierProvider signalIdentifierProvider)
        {
            this.signalIdentifierProvider = signalIdentifierProvider;
        }

        public async Task BeginObservationAsync(IEnumerable<string> profileName, DateTimeOffset publishedAfter)
        {
            //TODO check if SignalSourceProvider is not null
            foreach (string name in profileName)
            {
                var signals = await this.SignalSourceProvider.GetSignalsAsync(name, publishedAfter);
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
