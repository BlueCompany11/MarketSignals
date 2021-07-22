using System.Collections.Generic;

namespace SignalSources.Binance
{
    public static class BinanceCommon {
        public static Dictionary<CryptoPairs, string> CryptoParis { get; } = new()
        {
            { CryptoPairs.BTCUSDT, "BTCUSDT" },
            { CryptoPairs.ETHUSDT, "ETHUSDT" },
            { CryptoPairs.BNBUSDT, "BNBUSDT" }
        };
    }
}
