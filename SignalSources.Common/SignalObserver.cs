using SignalSources.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SignalSources.Common
{
    public partial class SignalObserver : ISignalObserver
    {
        public event Action<ISignal> NewSignalsEvent;

        private Dictionary<string, ISignal> signals = new();
        private readonly ISignalIdentifierProvider signalIdentifierProvider;
        private readonly ISignalSourceProvider signalSourceProvider;
        private readonly ISignalSourceConfiguration signalSourceConfiguration;
        private CancellationTokenSource tokenSource;
        private SignalObserver(ISignalIdentifierProvider signalIdentifierProvider, ISignalSourceProvider signalSourceProvider, ISignalSourceConfiguration signalSourceConfiguration)
        {
            this.signalIdentifierProvider = signalIdentifierProvider;
            this.signalSourceProvider = signalSourceProvider;
            this.signalSourceConfiguration = signalSourceConfiguration;
            this.tokenSource = new CancellationTokenSource();
        }

        private async Task BeginObservationAsync(IEnumerable<SourceConfiguration> sourceConfiguration, DateTimeOffset publishedAfter)
        {
            foreach (var source in sourceConfiguration)
            {
                var signals = await this.signalSourceProvider.GetSignalsAsync(source, publishedAfter);
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
        
        public void CancelObservation()
        {
            this.tokenSource.Cancel();
        }
        public async Task BeingObservationAsync()
        {
            var ct = this.tokenSource.Token;
            var task = Task.Run(async () =>
            {
                while (true)
                {
                    ct.ThrowIfCancellationRequested();
                    await this.BeginObservationAsync(this.signalSourceConfiguration.GetSourceConfigurations(), this.signalSourceConfiguration.PublishedAfter);
                    await Task.Delay(this.signalSourceConfiguration.Interval);
                }
            }, this.tokenSource.Token
            );
            await task;
        }
    }
}