using SignalSources.Interfaces;

namespace SignalSources.Common
{
    public partial class SignalObserver
    {
        public static class SignalObserverFactory
        {
            public static SignalObserver NewSignalObserver(ISignalIdentifierProvider signalIdentifierProvider, ISignalSourceProvider signalSourceProvider, ISignalSourceConfiguration signalSourceConfiguration)
            {
                return new SignalObserver(signalIdentifierProvider, signalSourceProvider, signalSourceConfiguration);
            }
        }
    }
}
