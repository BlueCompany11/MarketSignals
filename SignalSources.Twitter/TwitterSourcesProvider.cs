using SignalSources.Interfaces;
using System;
using System.Collections.Generic;

namespace SignalSources.Twitter
{
    public class TwitterSourcesProvider : ISignalSourceConfiguration
    {
        public TimeSpan Interval => TimeSpan.FromSeconds(10);

        public DateTimeOffset PublishedAfter => DateTimeOffset.Now.AddDays(-1);

        public List<SourceConfiguration> GetSourceConfigurations()
        {
            var ret = new List<SourceConfiguration>
            {
                new SourceConfiguration { Id = "PiotrOstapowicz", SignalLevel = SignalLevel.Mid },
                new SourceConfiguration { Id = "ZssBecker", SignalLevel = SignalLevel.Mid },
                new SourceConfiguration { Id = "intocryptoverse", SignalLevel = SignalLevel.High },
                new SourceConfiguration { Id = "elonmusk", SignalLevel = SignalLevel.Critical }
            };
            return ret;
        }
    }
}
