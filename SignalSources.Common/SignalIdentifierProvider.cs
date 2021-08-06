using SignalsSources.Interfaces;

namespace SignalSources.Common
{
    public class SignalIdentifierProvider : ISignalIdentifierProvider
    {
        public string GetSignalIdentify(ISignal signal)
        {
            return signal.Date + " " + signal.From;
        }
    }
}
