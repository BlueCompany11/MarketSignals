namespace SignalSources.Interfaces
{
    public interface ISignalIdentifierProvider
    {
        string GetSignalIdentify(ISignal signal);
    }
}
