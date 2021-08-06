namespace SignalsSources.Interfaces
{
    public interface ISignalIdentifierProvider
    {
        string GetSignalIdentify(ISignal signal);
    }
}
