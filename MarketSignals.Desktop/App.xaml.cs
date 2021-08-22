using MarketSignals.Desktop.Utilities;
using MarketSignals.Desktop.Utilities.Interfaces;
using MarketSignals.Desktop.ViewModels;
using MarketSignals.Desktop.Views;
using MarketSignals.IoC;
using Prism.Ioc;
using Prism.Regions;
using SignalSources.Interfaces;
using SignalSources.Taapi;
using System.Collections.Generic;
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
            regionManager.RegisterViewWithRegion("SideMainMenu", typeof(MenuView));
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var setup = new Setup();
            containerRegistry.Register<ISoundSignal, SoundSignal>();
            containerRegistry.Register<IAlarmSignal, AlarmSignal>();
            containerRegistry.Register<TaapiConnection>();
            containerRegistry.Register<IndicatorsConfigurationViewModel>(() => new IndicatorsConfigurationViewModel(setup.ResolveTaapiConnection(),setup.ResolveTaapiOrchestrator(),setup.ResolveITaapiInfo()));
            containerRegistry.RegisterInstance(new List<ISignalObserver> { setup.ResolveTwitterSignalObserver(), setup.ResolveYoutubeSignalObserver() });
            containerRegistry.Register<TwitterConfigurationViewModel>(()=>new TwitterConfigurationViewModel(setup.ResolveTwitterSourceProvider(), setup.ResolveTwitterDataAccess()));
            containerRegistry.Register<YoutubeConfigurationViewModel>(() => new YoutubeConfigurationViewModel(setup.ResolveYoutubeSourceProvider(),setup.ResolveYoutubeDataAccess()));
            containerRegistry.RegisterForNavigation<SignalsDashboardView>();
            containerRegistry.RegisterForNavigation<YoutubeConfigurationView>();
            containerRegistry.RegisterForNavigation<TwitterConfigurationView>();
            containerRegistry.RegisterForNavigation<IndicatorsConfigurationView>();
        }
    }
}
