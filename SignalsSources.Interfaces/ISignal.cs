using System;

namespace SignalSources.Interfaces
{
    public interface ISignal
    {
        DateTime Date { get; }
        string Text { get; }
        SignalLevel Level { get; }
        string From { get; }
    }
}
