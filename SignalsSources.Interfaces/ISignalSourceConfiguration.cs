using System;
using System.Collections.Generic;

namespace SignalSources.Interfaces
{
    public interface ISignalSourceConfiguration
    {
        List<SourceConfiguration> GetSourceConfigurations();
        TimeSpan Interval { get; }
        DateTimeOffset PublishedAfter { get; }
    }    
}

