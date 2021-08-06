using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Threading.Tasks;
namespace SignalSources.Taapi
{
    public class TaapiSecrets
    {
        public string Secret { get; init; }
        public TaapiSecrets(IConfigurationRoot configuration)
        {
            this.Secret = configuration.GetSection("TaapiSecrets:secret").Value;
        }
    }
    public class TaapiConnection
    {
        private class Response1
        {
            public string value { get; set; }
        }

        private RestClient client;
        private string secret;
        public TaapiConnection(TaapiSecrets secret)
        {
            this.client = new RestClient("https://api.taapi.io/");
            this.secret = secret.Secret;
        }
        public async Task Connect()
        {
            var request = new RestRequest("rsi")
                .AddParameter("secret", this.secret)
                .AddParameter("exchange", "binance")
                .AddParameter("symbol", "BTC/USDT")
                .AddParameter("interval", "1d");
            var response = await this.client.GetAsync<Response1>(request);
        }

        public async Task Get(string indicator, string symbol,string interval)
        {
            var request = new RestRequest(indicator)
                .AddParameter("secret", this.secret)
                .AddParameter("exchange", symbol)
                .AddParameter("interval", interval);
            var response = await this.client.GetAsync<Response1>(request);
        }
    }
}
