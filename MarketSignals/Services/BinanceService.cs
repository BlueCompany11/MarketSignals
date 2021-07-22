using MarketSignals.Interfaces;
using SignalSources.Binance.Interfaces;
using System.Collections.Generic;

namespace MarketSignals.Services
{
    public class BinanceService:IBinanceService
    {
        private readonly IBinanceMarket binanceMarket;

        public BinanceService(IBinanceMarket binanceMarket)
        {
            this.binanceMarket = binanceMarket;
        }
        public List<string> GetListOfSymbols()
        {
            return this.binanceMarket.GetAllCryptoPairs();
        }
    }
}
