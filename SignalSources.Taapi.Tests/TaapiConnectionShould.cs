using FluentAssertions;
using SignalSources.Common;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SignalSources.Taapi.Tests
{
    /// <summary>
    /// Beware amount of tests run per 15 sec. Free API key allows only for 1 request.
    /// </summary>
    public class TaapiConnectionShould:IDisposable
    {
        private TaapiSecrets taapiSecrets = new TaapiSecrets(SignalsSecretsProvider.GetConfigurationRoot());
        private string symbol = "BTC/USDT";
        private string interval = Intervals.OneHour;
        private TaapiConnection sut;
        public TaapiConnectionShould()
        {
            this.sut = new TaapiConnection(this.taapiSecrets);
        }
        [Fact]
        public async Task GetCommodityChannelIndex()
        {
            var ret = await this.sut.GetCommodityChannelIndex(this.symbol, this.interval);
            ret.Value.Should().BeInRange(-400, 400);
        }
        [Fact]
        public async Task GetChaikinMoneyFlow()
        {
            var ret = await this.sut.GetChaikinMoneyFlow(this.symbol, this.interval);
            ret.Value.Should().BeInRange(-1, 1);
        }
        [Fact]
        public async Task GetDoji()
        {
            var ret = await this.sut.GetDoji(this.symbol, this.interval);
            ret.Value.Should().BeOneOf(0, 100);
        }
        [Fact]
        public async Task GetExponentialMovingAverage()
        {
            var ret = await this.sut.GetExponentialMovingAverage(this.symbol, this.interval);
            ret.Value.Should().BeGreaterThan(0);
        }
        [Fact]
        public async Task GetFibonacciRetracement()
        {
            var ret = await this.sut.GetFibonacciRetracement(this.symbol, this.interval);
            ret.Value.Should().BeGreaterThan(0);
            ret.Trend.Should().BeOneOf("DOWNTREND", "UPTREND");
            ret.StartPrice.Should().BeGreaterThan(0);
            ret.EndPrice.Should().BeGreaterThan(0);
            //TODO fix when end of the year
            ret.StartTimestamp.Should().HaveYear(DateTime.Now.Year);
            ret.EndTimestamp.Should().HaveYear(DateTime.Now.Year);
        }
        [Fact]
        public async Task GetHullMovingAverage()
        {
            var ret = await this.sut.GetHullMovingAverage(this.symbol, this.interval,50);
            ret.Value.Should().BeGreaterThan(0);
        }
        [Fact]
        public async Task GetIchimokuCloud()
        {
            var ret = await this.sut.GetIchimokuCloud(this.symbol, this.interval);
            ret.Conversion.Should().BeGreaterThan(0);
            ret.Base.Should().BeGreaterThan(0);
            ret.SpanA.Should().BeGreaterThan(0);
            ret.SpanB.Should().BeGreaterThan(0);
            ret.CurrentSpanA.Should().BeGreaterThan(0);
            ret.CurrentSpanB.Should().BeGreaterThan(0);
            ret.LaggingSpanA.Should().BeGreaterThan(0);
            ret.LaggingSpanB.Should().BeGreaterThan(0);
        }

        public void Dispose()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(16));
        }
    }
}
