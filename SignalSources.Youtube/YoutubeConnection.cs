using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
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
            SearchListResponse response;
            try
            {
                response = await searchListRequest.ExecuteAsync();
            }
            catch (Google.GoogleApiException)
            {
                //TODO recive this error higher and inform user about too many requests
                throw;
            }
            foreach (var item in response.Items)
            {
                var details = item.Snippet;
                var signal = new YoutubeSignal(details.PublishedAt ?? DateTime.Now, details.Title, source.SignalLevel, @"https://www.youtube.com/watch?v="+item.Id,details.ChannelTitle);
                ret.Add(signal);
            }
            return ret;
        }
    }
}
