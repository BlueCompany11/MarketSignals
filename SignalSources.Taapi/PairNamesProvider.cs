using SignalSources.Binance;
using SignalSources.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SignalSources.Taapi
{
    public class PairNamesProvider : IPairNamesProvider
    {
        private readonly BinanceConnection binanceConnection;

        public PairNamesProvider(BinanceConnection binanceConnection)
        {
            this.binanceConnection = binanceConnection.Connect();
        }
        public List<string> GetPairNames()
        {
            var ret = this.binanceConnection.GetAllCryptoPairs();
            for (int i = 0; i < ret.Count; i++)
            {
                ret[i] = ret[i].Replace("USDT", "/USDT");
                ret[i] = ret[i].Replace("BUSD", "/BUSD");
            }
            ret = ret.Where(x => !x.Contains('_')).ToList();
            //TODO temp restriction for free api
            //ret = ret.Where(x => x == "BTC/USDT").ToList();
            return ret;
        }
    }
}
