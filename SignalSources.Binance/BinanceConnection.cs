using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Interfaces;
using SignalSources.Binance.Interfaces;
using System;
using System.Collections.Generic;

namespace SignalSources.Binance
{
    public class BinanceConnection: IBinanceMarket
    {
        public static class Factory
        {
            public static BinanceConnection NewBinanceConnection()
            {
                return new BinanceConnection().Connect();
            }
        }
        private BinanceClient client;
        public BinanceConnection Connect()
        {
            this.client = new BinanceClient();
            return this;
        }
        public List<string> GetAllCryptoPairs()
        {
            var data = this.client.FuturesUsdt.Market.Get24HPrices();
            var ret = new List<string>();
            foreach (var item in data.Data)
            {
                ret.Add(item.Symbol);
            }
            return ret;
        }
        public IEnumerable<IBinanceKline> GetMarketChart(string symbol, KlineInterval interval, DateTime start, DateTime end)
        {
            var ret = this.client.FuturesUsdt.Market.GetKlines(symbol, interval, start, end);
            return ret.Data;
        }
        public IEnumerable<MarketBar> GetMarketBars(IEnumerable<IBinanceKline> klines)
        {
            var ret = new List<MarketBar>();
            foreach (var item in klines)
            {
                ret.Add(new MarketBar { Close = item.Close, OpenTime = item.OpenTime });
            }
            return ret;
        }
    }
}
