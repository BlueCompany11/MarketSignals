using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace SignalSources.Twitter
{
    public class TwitterConnection
    {
        private TwitterClient userClient = new TwitterClient("Gs1aYTFTrPWUR8B1gS6Uzmhxy", "vCCs5dZArd2Su34VXAqeBl49XQLmu33RrMD8XwVJ4R5Pz37ceN",
            "1383430058103115790-Fa3sqoLKttcGCub1Fkr1NQq15U99r3", "1X3QQ8F5gEgTZlWyE72MyIjDwCYyFftTZXTKqdZbHM8Ap");
        public async Task Y()
        {
            try
            {
                // we create a client with your user's credentials


                // request the user's information from Twitter API
                IAuthenticatedUser user = await this.userClient.Users.GetAuthenticatedUserAsync();
                Console.WriteLine("Hello " + user);
                // publish a tweet
                ITweet tweet = await this.userClient.Tweets.PublishTweetAsync("Hello tweetinvi world!");
                Console.WriteLine("You published the tweet : " + tweet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        /// <summary>
        /// zrobic logowanie do twittera i czytanie page z czyjegos konta
        /// </summary>
        /// <returns></returns>
        public async Task X()
        {
            IUser[] users = await this.userClient.Search.SearchUsersAsync("ZssBecker");
            int count = users.Length;
            IUser user = users[0];
            Tweetinvi.Models.V2.SearchTweetsV2Response tweets = await this.userClient.SearchV2.SearchTweetsAsync("ZssBecker");
            int len = tweets.Tweets.Length;
            var t = tweets.Tweets.Where(
                x => x.CreatedAt > DateTimeOffset.UtcNow.AddDays(-1)
            && string.IsNullOrEmpty(x.InReplyToUserId)
            && x?.ReferencedTweets[0]?.Type != "retweeted"
            && x?.ReferencedTweets[0]?.Type != "replied_to").ToList();
            /*var timelineTweets = new List<ITweet>();
            Tweetinvi.Iterators.ITwitterIterator<ITweet, long?> timelineIterator = appClient.Timelines.GetHomeTimelineIterator();

            Tweetinvi.Iterators.ITwitterIteratorPage<ITweet, long?> page = await timelineIterator.NextPageAsync();
            timelineTweets.AddRange(page);*/

        }

        public async Task<List<ITweet>> ReadPage()
        {
            var timelineTweets = new List<ITweet>();
            Tweetinvi.Iterators.ITwitterIterator<ITweet, long?> timelineIterator = this.userClient.Timelines.GetHomeTimelineIterator();

            Tweetinvi.Iterators.ITwitterIteratorPage<ITweet, long?> page = await timelineIterator.NextPageAsync();
            timelineTweets.AddRange(page);
            return timelineTweets;
        }
    }
}
