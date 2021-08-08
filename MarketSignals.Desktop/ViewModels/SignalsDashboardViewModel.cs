using Prism.Mvvm;
using SignalSources.Interfaces;
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
        public SignalsDashboardViewModel(List<ISignalObserver> signalObservers)
        {
            this.signalObservers = signalObservers;
            this.Signals = new ObservableCollection<ISignal>();
            foreach (var observer in this.signalObservers)
            {
                observer.NewSignalsEvent += this.SignalObserver_NewSignalsEvent;
                observer.BeingObservationAsync();
            }
        }

        private void SignalObserver_NewSignalsEvent(ISignal signal)
        {
            this.Signals = new ObservableCollection<ISignal>(this.Signals.Prepend(signal));
        }
    }
}
