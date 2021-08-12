using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalSources.Interfaces
{
    public interface ISignalSourceProvider
    {
        Task<IEnumerable<ISignal>> GetSignalsAsync(SourceConfiguration source, DateTimeOffset publishedAfter);
    }
}
