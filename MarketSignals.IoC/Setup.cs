using DryIoc;
using Microsoft.Extensions.Configuration;
using SignalSources.Common;
using SignalSources.Interfaces;
using SignalSources.Taapi;
using SignalSources.Twitter;
using SignalSources.Youtube;
using static SignalSources.Common.DataAccess.SourceConfigurationProvider;
using static SignalSources.Common.SignalObserver;

namespace MarketSignals.IoC
{
    public class Setup
    {
        private Container container = new();
        private const string youtube = "youtube";
        private const string twitter = "twitter";
        public Setup()
        {
            var config = SignalsSecretsProvider.GetConfigurationRoot();
            this.container.RegisterInstance<IConfigurationRoot>(config);
            this.container.Register<TwitterSecrets>();
            this.container.Register<YoutubeSecrets>();
            this.container.Register<TaapiSecrets>();
            this.container.Register<ISignalSourceProvider, TwitterConnection>(serviceKey: twitter);
            this.container.Register<ISignalSourceProvider, YoutubeConnection>(serviceKey: youtube);
            this.container.Register<ISignalIdentifierProvider, SignalIdentifierProvider>();
            this.container.Register<IDataAccess<SourceConfiguration>>(serviceKey: twitter, made: Made.Of(() => SourceConfigurationProviderFactory.GetTwitter()));
            this.container.Register<IDataAccess<SourceConfiguration>>(serviceKey: youtube, made: Made.Of(() => SourceConfigurationProviderFactory.GetYoutube()));
            this.container.Register<ISignalSourceConfiguration, YoutubeSourcesProvider>(serviceKey: youtube,
                made: Made.Of(() => new YoutubeSourcesProvider(Arg.Of<IDataAccess<SourceConfiguration>>(youtube))));
            this.container.Register<ISignalSourceConfiguration, TwitterSourcesProvider>(serviceKey: twitter,
                made: Made.Of(() => new TwitterSourcesProvider(Arg.Of<IDataAccess<SourceConfiguration>>(twitter))));
            this.container.Register<ISignalObserver, SignalObserver>(serviceKey: youtube, 
                made: Made.Of(() => SignalObserverFactory.NewSignalObserver(Arg.Of<ISignalIdentifierProvider>(),Arg.Of<ISignalSourceProvider>(youtube), 
                Arg.Of<ISignalSourceConfiguration>(youtube))));
            this.container.Register<ISignalObserver, SignalObserver>(serviceKey: twitter,
                made: Made.Of(() => SignalObserverFactory.NewSignalObserver(Arg.Of<ISignalIdentifierProvider>(), Arg.Of<ISignalSourceProvider>(twitter), 
                Arg.Of<ISignalSourceConfiguration>(twitter))));
            
        }
        public ISignalObserver ResolveTwitterSignalObserver()
        {
            return this.container.Resolve<ISignalObserver>(serviceKey: twitter);
        }
        public ISignalObserver ResolveYoutubeSignalObserver()
        {
            return this.container.Resolve<ISignalObserver>(serviceKey: youtube);
        }
        public ISignalSourceConfiguration ResolveYoutubeSourceProvider()
        {
            return this.container.Resolve<ISignalSourceConfiguration>(serviceKey: youtube);
        }
        public ISignalSourceConfiguration ResolveTwitterSourceProvider()
        {
            return this.container.Resolve<ISignalSourceConfiguration>(serviceKey: twitter);
        }
        public IDataAccess<SourceConfiguration> ResolveTwitterDataAccess()
        {
            return this.container.Resolve<IDataAccess<SourceConfiguration>>(serviceKey:twitter);
        }
        public IDataAccess<SourceConfiguration> ResolveYoutubeDataAccess()
        {
            return this.container.Resolve<IDataAccess<SourceConfiguration>>(serviceKey: youtube);
        }
    }
}
