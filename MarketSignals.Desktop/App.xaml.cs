using MarketSignals.Desktop.Utilities;
using MarketSignals.Desktop.Utilities.Interfaces;
using MarketSignals.Desktop.Views;
using MarketSignals.IoC;
using Prism.Ioc;
using Prism.Regions;
using SignalSources.Interfaces;
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
            base.OnInitialized();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var setup = new Setup();
            containerRegistry.Register<ISoundSignal, SoundSignal>();
            containerRegistry.Register<IAlarmSignal, AlarmSignal>();
            containerRegistry.RegisterInstance(new List<ISignalObserver> { setup.ResolveTwitterSignalObserver(), setup.ResolveYoutubeSignalObserver() });
        }
    }
}
