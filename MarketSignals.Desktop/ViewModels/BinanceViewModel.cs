using Prism.Mvvm;
using SignalSources.Binance;
using System.Collections.ObjectModel;

namespace MarketSignals.Desktop.ViewModels
{
    public class BinanceViewModel : BindableBase
    {
        private int amount;

        public int Amount
        {
            get => this.amount;
            set => this.SetProperty(ref this.amount, value);
        }
        private ObservableCollection<string> cryptoParis;

        public ObservableCollection<string> CryptoPairs
        {
            get => this.cryptoParis;
            set => this.SetProperty(ref this.cryptoParis, value);
        }
        private string selectedCrypto;

        public string SelectedCrypto
        {
            get => this.selectedCrypto;
            set => this.SetProperty(ref this.selectedCrypto, value);
        }

        public BinanceViewModel()
        {
            var binanceConnection = new BinanceConnection();
            binanceConnection.Connect();
            var ret = binanceConnection.GetAllCryptoPairs();
            this.Amount = ret.Count;
            this.CryptoPairs = new ObservableCollection<string>(ret);
        }

    }
}
