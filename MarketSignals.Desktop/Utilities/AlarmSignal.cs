using MarketSignals.Desktop.Utilities.Interfaces;
using SignalSources.Interfaces;
using System;

namespace MarketSignals.Desktop.Utilities
{
    public class AlarmSignal : IAlarmSignal
    {
        public bool CallAlarm(ISignal signal)
        {
            return signal.Level == SignalLevel.Critical && signal.Date > DateTime.Now.AddHours(-1);
        }
    }
}
