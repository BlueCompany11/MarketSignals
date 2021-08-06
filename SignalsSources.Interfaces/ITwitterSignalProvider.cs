using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalsSources.Interfaces
{
    public interface ITwitterSignalProvider
    {
        Task<IEnumerable<ISignal>> GetSignalsAsync(string profileName, DateTimeOffset publishedAfter);
    }
}
