using System;

namespace SignalsSources.Interfaces
{
    public interface ISignal
    {
        DateTime Date { get; }
        string Text { get; }
        SignalLevel Level { get; }
        string From { get; }
    }
}
