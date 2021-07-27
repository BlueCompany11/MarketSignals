using MarketSignals.Interfaces;
using MarketSignals.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SignalSources.Binance;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarketSignals
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            //http://localhost:7071/api/
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7071/api/") });
            
            builder.Services.AddTransient<IBinanceService>(x=>new BinanceService(BinanceConnection.Factory.NewBinanceConnection()));
            await builder.Build().RunAsync();
        }
    }
}
