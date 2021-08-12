using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using SignalSources.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalSources.Youtube
{

    public class YoutubeConnection: ISignalSourceProvider
    {

        private YouTubeService youtubeService;
        public YoutubeConnection(YoutubeSecrets secrets)
        {
            this.youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = secrets.ApiKey,
                ApplicationName = "Market Signals"
            });
        }

        public async Task<IEnumerable<ISignal>> GetSignalsAsync(SourceConfiguration source, DateTimeOffset publishedAfter)
        {
            List<ISignal> ret = new();
            var searchListRequest = this.youtubeService.Search.List("snippet");
            searchListRequest.PublishedAfter = JsonConvert.SerializeObject(publishedAfter).Replace("\"", "");
            searchListRequest.ChannelId = source.Id;
            var response = await searchListRequest.ExecuteAsync();
            foreach (var item in response.Items)
            {
                var details = item.Snippet;
                var signal = new YoutubeSignal(details.PublishedAt ?? DateTime.Now, details.Title, source.SignalLevel);
                ret.Add(signal);
            }
            return ret;
        }
    }
}
