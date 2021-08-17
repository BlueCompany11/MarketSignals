using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace MarketSignals.Desktop.ViewModels
{
    public class MenuViewModel:BindableBase
    {
        private readonly IRegionManager regionManager;

        public DelegateCommand<string> NavigateCommand { get; set; }
        public MenuViewModel(IRegionManager regionManager)
        {
            this.NavigateCommand = new DelegateCommand<string>(this.Navigate);
            this.regionManager = regionManager;
        }

        private void Navigate(string uri)
        {
            this.regionManager.RequestNavigate("Dashboard", uri);
        }
    }
}
