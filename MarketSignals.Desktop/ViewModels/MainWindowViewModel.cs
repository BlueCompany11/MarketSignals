using Prism.Mvvm;

namespace MarketSignals.Desktop.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Market Signals";
        public string Title
        {
            get => this._title;
            set => this.SetProperty(ref this._title, value);
        }

        public MainWindowViewModel()
        {

        }
    }
}
