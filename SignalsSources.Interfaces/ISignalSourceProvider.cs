using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalsSources.Interfaces
{
    public interface ISignalSourceProvider
    {
        Task<IEnumerable<ISignal>> GetSignalsAsync(string channelId, DateTimeOffset publishedAfter);
    }
}
