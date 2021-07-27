using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SignalSources.Binance;
using System.Threading.Tasks;

namespace MarketSignals.Serverless
{
    public static class Function1
    {
        [Function("Function1")]
        public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Function1");
            logger.LogInformation("C# HTTP trigger function processed a request.");
            var response = req.CreateResponse();
            var binanceConnection = new BinanceConnection();
            binanceConnection.Connect();
            var ret = binanceConnection.GetAllCryptoPairs();
            await response.WriteAsJsonAsync(ret);

            return response;
        }
    }
}
