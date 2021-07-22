using SignalSources.Binance;
using System.Collections.Generic;

namespace MarketSignals.Pages
{
    public partial class BinanceView
    {
        //[Inject]
        //public IBinanceService BinanceMarket { get; set; }

        private List<string> Symbols { get; set; } = new();
        private string CurrentSymbol { get; set; }

        public BinanceView()
        {
            
        }

        private void In()
        {
            
            var x = new BinanceConnection().Connect();
            this.Symbols = x.GetAllCryptoPairs();
        }
    }
}
