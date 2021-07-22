using System.Collections.Generic;

namespace MarketSignals.Interfaces
{
    public interface IBinanceService
    {
        List<string> GetListOfSymbols();
    }
}
