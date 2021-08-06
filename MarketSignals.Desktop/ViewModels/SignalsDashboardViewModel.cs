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
        private readonly ITwitterSignalObserver twitterSignalObserver;
        private readonly IYouTubeSignalProvider youTubeSignalProvider;

        public ObservableCollection<ISignal> Signals
        {
            get => this.signals;
            set => this.SetProperty(ref this.signals, value);
        }
        public SignalsDashboardViewModel(ITwitterSignalObserver twitterSignalObserver, IYouTubeSignalProvider youTubeSignalProvider)
        {
            this.twitterSignalObserver = twitterSignalObserver;
            this.youTubeSignalProvider = youTubeSignalProvider;
            this.Signals = new ObservableCollection<ISignal>();
            this.twitterSignalObserver.NewSignalsEvent += this.TwitterSignalObserver_NewSignalsEvent;
            this.twitterSignalObserver.BeginObservationAsync(new List<string> { "PiotrOstapowicz" }, System.DateTimeOffset.Now.AddDays(-1));
        }

        private void TwitterSignalObserver_NewSignalsEvent(ISignal signal)
        {
            this.Signals = new ObservableCollection<ISignal>(this.Signals.Prepend(signal));
        }
    }
}
