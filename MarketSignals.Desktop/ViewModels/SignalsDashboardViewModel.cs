using Prism.Mvvm;
using SignalsSources.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MarketSignals.Desktop.ViewModels
{
    public class SignalsDashboardViewModel : BindableBase
    {
        private ObservableCollection<ISignal> signals;
        private List<ISignalObserver> signalObservers = new();

        public ObservableCollection<ISignal> Signals
        {
            get => this.signals;
            set => this.SetProperty(ref this.signals, value);
        }
        public SignalsDashboardViewModel(ITwitterSignalObserver twitterSignalObserver, IYoutubeSignalObserver youTubeSignalObserver)
        {
            this.signalObservers.Add(twitterSignalObserver);
            this.signalObservers.Add(youTubeSignalObserver);
            this.Signals = new ObservableCollection<ISignal>();
            foreach (var observer in this.signalObservers)
            {
                observer.NewSignalsEvent += this.SignalObserver_NewSignalsEvent;
            }
            twitterSignalObserver.BeginObservationAsync(new List<string> { "PiotrOstapowicz" }, System.DateTimeOffset.Now.AddDays(-1));
            youTubeSignalObserver.BeginObservationAsync(new List<string> { "UCqK_GSMbpiV8spgD3ZGloSw" }, System.DateTimeOffset.Now.AddDays(-40));
        }

        private void SignalObserver_NewSignalsEvent(ISignal signal)
        {
            this.Signals = new ObservableCollection<ISignal>(this.Signals.Prepend(signal));
        }
    }
}
