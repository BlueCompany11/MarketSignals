using MarketSignals.Desktop.Views;
using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Regions;
using SignalSources.Common;
using SignalSources.Taapi;
using SignalSources.Twitter;
using SignalSources.Youtube;
using SignalsSources.Interfaces;
using System.Windows;

namespace MarketSignals.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return this.Container.Resolve<MainWindow>();
        }
        protected override void OnInitialized()
        {
            var regionManager = this.Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("Dashboard", typeof(SignalsDashboardView));
            base.OnInitialized();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //TODO Raise exception when file not found
            var config = SignalsSecretsProvider.GetConfigurationRoot();


            containerRegistry.RegisterInstance<IConfigurationRoot>(config);

            containerRegistry.RegisterSingleton<TwitterSecrets>();
            containerRegistry.RegisterSingleton<YoutubeSecrets>();
            containerRegistry.RegisterSingleton<TaapiSecrets>();

            containerRegistry.Register<ITwitterSignalProvider, TwitterConnection>();
            containerRegistry.Register<IYouTubeSignalProvider, YoutubeConnection>();
            containerRegistry.Register<ISignalIdentifierProvider, SignalIdentifierProvider>();
            containerRegistry.Register<ITwitterSignalObserver, TwitterObserver>();
            
        }
/*        public static IConfigurationRoot CredentialsConfig()
        {
            return new ConfigurationBuilder()
                    .AddJsonFile("Credentials.json", optional: false, reloadOnChange: true)
                    .Build();
        }*/
    }
}
