using RestSharp;
using SignalSources.Taapi.IndicatorResponse;
using System.Threading.Tasks;
namespace SignalSources.Taapi
{
    public static class Indicators
    {
        public static string CommodityChannelIndex = "cci";
        public static string ChaikinMoneyFlow = "cmf";
        public static string DirectionalMovementIndex = "dmi";
        public static string Doji = "doji";
        public static string ExponentialMovingAverage = "ema";
        public static string FibonacciRetracement = "fibonacciretracement";
        public static string HullMovingAverage = "hma";
        public static string IchimokuCloud = "ichimoku";
    }
    public partial class TaapiConnection
    {
        private RestClient client;
        private string secret;
        public TaapiConnection(TaapiSecrets secret)
        {
            this.client = new RestClient("https://api.taapi.io/");
            this.secret = secret.Secret;
        }

        private async Task<ValueResponse> GetValueResponse(string indicator, string symbol,string interval)
        {
            var request = new RestRequest(indicator)
                .AddParameter("secret", this.secret)
                .AddParameter("exchange", "binance")
                .AddParameter("symbol",symbol)
                .AddParameter("interval", interval);
            var response = await this.client.GetAsync<ValueResponse>(request);
            return response;
        }

        private IRestRequest GetRequest(string indicator, string symbol, string interval)
        {
            var request = new RestRequest(indicator)
                    .AddParameter("secret", this.secret)
                    .AddParameter("exchange", "binance")
                    .AddParameter("symbol", symbol)
                    .AddParameter("interval", interval);
            return request;
        }
        public async Task<ValueResponse> GetCommodityChannelIndex(string symbol, string interval)
        {
            return await this.GetValueResponse(Indicators.CommodityChannelIndex, symbol, interval);
        }
        public async Task<ValueResponse> GetChaikinMoneyFlow(string symbol, string interval)
        {
            return await this.GetValueResponse(Indicators.ChaikinMoneyFlow, symbol, interval);
        }
        public async Task<DMIResponse> DirectionalMovementIndex(string symbol, string interval)
        {
            var request = this.GetRequest(Indicators.DirectionalMovementIndex, symbol, interval);
            return await this.client.GetAsync<DMIResponse>(request);
        }
        public async Task<ValueResponse> GetDoji(string symbol, string interval)
        {
            return await this.GetValueResponse(Indicators.Doji, symbol, interval);
        }
        public async Task<ValueResponse> GetExponentialMovingAverage(string symbol, string interval)
        {
            return await this.GetValueResponse(Indicators.ExponentialMovingAverage, symbol, interval);
        }
        public async Task<FibonacciRetracementResponse> GetFibonacciRetracement(string symbol, string interval)
        {
            var request = this.GetRequest(Indicators.FibonacciRetracement, symbol, interval);
            return await this.client.GetAsync<FibonacciRetracementResponse>(request);
        }
        public async Task<ValueResponse> GetHullMovingAverage(string symbol, string interval, float period)
        {
            var request = this.GetRequest(Indicators.HullMovingAverage, symbol, interval);
            request.AddParameter("period", period);
            return await this.client.GetAsync<ValueResponse>(request);

        }
        public async Task<IchimokuCloudResponse> GetIchimokuCloud(string symbol, string interval)
        {
            var request = this.GetRequest(Indicators.IchimokuCloud, symbol, interval);
            return await this.client.GetAsync<IchimokuCloudResponse>(request);
        }
    }
}
