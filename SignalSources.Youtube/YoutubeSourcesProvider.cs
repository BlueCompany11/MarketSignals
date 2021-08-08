using SignalSources.Interfaces;
using System;
using System.Collections.Generic;

namespace SignalSources.Youtube
{
    public class YoutubeSourcesProvider : ISignalSourceConfiguration
    {
        public TimeSpan Interval => TimeSpan.FromMinutes(5);

        public DateTimeOffset PublishedAfter => DateTimeOffset.Now.AddDays(-1);

        public List<SourceConfiguration> GetSourceConfigurations()
        {
            var ret = new List<SourceConfiguration>
            {
                new SourceConfiguration { Id = "UCqK_GSMbpiV8spgD3ZGloSw", SignalLevel = SignalLevel.Mid }
            };
            return ret;
        }
    }
}
