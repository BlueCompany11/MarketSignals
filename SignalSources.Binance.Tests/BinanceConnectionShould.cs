using Binance.Net.Enums;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;
namespace SignalSources.Binance.Tests
{
    public class BinanceConnectionShould
    {
        [Fact]
        public void Connect()
        {
            var sut = new BinanceConnection().Connect();
        }

        [Fact]
        public void GetAllBinanceSymbolsForFuturesMarket()
        {
            var sut = new BinanceConnection().Connect();
            var ret = sut.GetAllCryptoPairs();
            ret.Should().OnlyHaveUniqueItems().And.Contain("BTCUSDT", because: "BTC cannot be delisted").And.HaveCountGreaterThan(1);
        }
        [Fact]
        public void GetBTCUSDTChartForLastTwoDaysInSixHourIntervals()
        {
            var sut = new BinanceConnection().Connect();
            var ret = sut.GetMarketChart("BTCUSDT", KlineInterval.SixHour, DateTime.Today.AddDays(-2), DateTime.Today);
            ret.Should().HaveCount(9,because:"This is amount of 6 hour intervals in 2 days is 8 and 1 extra for current time");
        }
        [Fact]
        public void GetBTCData()
        {
            var sut = new BinanceConnection().Connect();
            var klines = sut.GetMarketChart("BTCUSDT", KlineInterval.SixHour, DateTime.Today.AddDays(-2), DateTime.Today);
            var marketBars = sut.GetMarketBars(klines);
            marketBars.Should().HaveCount(klines.ToList().Count).And.OnlyHaveUniqueItems(x=>x.OpenTime);
        }
    }
}
