using SignalSources.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;

namespace SignalSources.Twitter
{
    public class TwitterConnection: ISignalSourceProvider
    {
        private TwitterClient userClient;
        public TwitterConnection(TwitterSecrets secrets)
        {
            this.userClient = new(secrets.ConsumerKey, secrets.ConsumerSecret, secrets.AccessToken, secrets.AccessSecret);
        }
        public async Task<IEnumerable<ISignal>> GetSignalsAsync(SourceConfiguration source, DateTimeOffset publishedAfter)
        {
            List<ISignal> ret = new();
            var timeline = await this.userClient.Timelines.GetUserTimelineAsync(source.Id);
            foreach (var tweet in timeline.Where(x => x.CreatedAt >= publishedAfter))
            {
                var hashTags = tweet.Hashtags.Select(x => x.Text).ToList();
                ret.Add(new TwitterSignal(tweet.CreatedAt.DateTime, tweet.Text, source.SignalLevel, tweet.CreatedBy.Name, hashTags, tweet.Url));
            }
            return ret;
        }
    }
}
