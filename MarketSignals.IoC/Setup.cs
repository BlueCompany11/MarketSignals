namespace MarketSignals.IoC
{
    /*    public class Setup: IContainerExtension<IScope>, IContainerInfo
        {
            private IContainer container;
            public Setup()
            {
                this.container = new Container();
                this.container.Register<ITwitterSignalProvider, TwitterConnection>();
                this.container.Register<IYouTubeSignalProvider, YoutubeConnection>();
                this.container.Register<ISignalIdentifierProvider, SignalIdentifierProvider>();
                this.container.Register<ITwitterSignalObserver, TwitterObserver>();
            }

            public IScopedProvider CurrentScope => throw new NotImplementedException();

            public static IContainer C()
            {
                var container = new Container();
                container.Register<ITwitterSignalProvider, TwitterConnection>();
                container.Register<IYouTubeSignalProvider, YoutubeConnection>();
                container.Register<ISignalIdentifierProvider, SignalIdentifierProvider>();
                container.Register<ITwitterSignalObserver, TwitterObserver>();
                return container;
            }
        }*/
}
