using MarketSignals.Desktop.Utilities.Interfaces;
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
        private readonly ISoundSignal soundSignal;
        private readonly IAlarmSignal alarmSignal;

        public ObservableCollection<ISignal> Signals
        {
            get => this.signals;
            set => this.SetProperty(ref this.signals, value);
        }

        public SignalsDashboardViewModel(List<ISignalObserver> signalObservers, ISoundSignal soundSignal, IAlarmSignal alarmSignal)
        {
            this.signalObservers = signalObservers;
            this.soundSignal = soundSignal;
            this.alarmSignal = alarmSignal;
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
            if (this.alarmSignal.CallAlarm(signal))
            {
                this.soundSignal.Play();
            }
        }
    }
}
