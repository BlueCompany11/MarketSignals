using SignalSources.Interfaces;

namespace MarketSignals.Desktop.Utilities.Interfaces
{
    public interface IAlarmSignal
    {
        bool CallAlarm(ISignal signal);
    }
}
