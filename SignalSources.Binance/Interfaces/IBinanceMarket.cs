using Binance.Net.Enums;
using Binance.Net.Interfaces;
using System;
using System.Collections.Generic;

namespace SignalSources.Binance.Interfaces
{
    public interface IBinanceMarket
    {
        List<string> GetAllCryptoPairs();
        IEnumerable<IBinanceKline> GetMarketChart(string symbol, KlineInterval interval, DateTime start, DateTime end);
        IEnumerable<MarketBar> GetMarketBars(IEnumerable<IBinanceKline> klines);
    }
}
