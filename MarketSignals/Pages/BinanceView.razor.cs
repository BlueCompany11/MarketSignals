using Microsoft.AspNetCore.Components;
using SignalSources.Binance;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MarketSignals.Pages
{
    public partial class BinanceView
    {
        //[Inject]
        //public IBinanceService BinanceMarket { get; set; }
        [Inject]
        private HttpClient httpClient { get; set; }
        private List<string> Symbols { get; set; } = new();
        private string CurrentSymbol { get; set; }

        public BinanceView()
        {
            
        }
        protected override async Task OnInitializedAsync()
        {
            //this.Symbols = await this.httpClient.GetFromJsonAsync<List<string>>("Function1");
            try
            {
                string z = await this.httpClient.GetFromJsonAsync<string>("Function2");
                this.Symbols.Add(z);
            }
            catch(Exception ex)
            {
                var e = ex;
            }


        }
        private void In()
        {
            
            var x = new BinanceConnection().Connect();
            this.Symbols = x.GetAllCryptoPairs();
        }
    }
}
