using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using SignalsSources.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalSources.Youtube
{

    public class YoutubeConnection: IYouTubeSignalProvider
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

        public async Task<IEnumerable<ISignal>> GetSignalsAsync(string channelId, DateTimeOffset publishedAfter)
        {
            List<ISignal> ret = new();
            var searchListRequest = this.youtubeService.Search.List("snippet");
            searchListRequest.PublishedAfter = JsonConvert.SerializeObject(publishedAfter).Replace("\"", "");
            searchListRequest.ChannelId = channelId;
            var response = await searchListRequest.ExecuteAsync();
            foreach (var item in response.Items)
            {
                var details = item.Snippet;
                var signal = new YoutubeSignal(details.PublishedAt ?? DateTime.Now, details.Title, SignalLevel.Mid);
                ret.Add(signal);
            }
            return ret;
        }
    }
}
