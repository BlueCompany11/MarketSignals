using SignalSources.Interfaces;
using System;
using System.Collections.Generic;

namespace SignalSources.Youtube
{
    public class YoutubeSourcesProvider : ISignalSourceConfiguration
    {
        private readonly IDataAccess<SourceConfiguration> dataAccess;

        public TimeSpan Interval => TimeSpan.FromMinutes(5);

        public DateTimeOffset PublishedAfter => DateTimeOffset.Now.AddDays(-1);
         
        public YoutubeSourcesProvider(IDataAccess<SourceConfiguration> dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public List<SourceConfiguration> GetSourceConfigurations()
        {
            return new List<SourceConfiguration>(this.dataAccess.GetSourceConfigurations());
/*            var ret = new List<SourceConfiguration>
            {
                new SourceConfiguration { Id = "UCqK_GSMbpiV8spgD3ZGloSw", SignalLevel = SignalLevel.Critical },
                new SourceConfiguration { Id = "UCiSNk7mzA3cQ3UQEcP_AsYA", SignalLevel = SignalLevel.Mid },
                new SourceConfiguration { Id = "UClf1NZB9mFLnMDiwVWsBi9w", SignalLevel = SignalLevel.Mid },
                new SourceConfiguration { Id = "UC7ndkZ4vViKiM7kVEgdrlZQ", SignalLevel = SignalLevel.Mid },
                new SourceConfiguration { Id = "UCXasJkcS9vY8X4HgzReo10A", SignalLevel = SignalLevel.Mid },
                new SourceConfiguration { Id = "UCKQvGU-qtjEthINeViNbn6A", SignalLevel = SignalLevel.Mid },
                new SourceConfiguration { Id = "UCCatR7nWbYrkVXdxXb4cGXw", SignalLevel = SignalLevel.Mid }
            };
            return ret;*/
        }
    }
}
