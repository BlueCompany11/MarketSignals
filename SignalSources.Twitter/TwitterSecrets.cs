
using Microsoft.Extensions.Configuration;

namespace SignalSources.Twitter
{
    public class TwitterSecrets
    {
        public string ConsumerKey { get; init; }
        public string ConsumerSecret { get; init; }
        public string AccessToken { get; init; }
        public string AccessSecret { get; init; }

        public TwitterSecrets(IConfigurationRoot configuration)
        {
            this.ConsumerKey = configuration.GetSection("TwitterSecrets:consumerKey").Value;
            this.ConsumerSecret = configuration.GetSection("TwitterSecrets:consumerSecret").Value;
            this.AccessToken = configuration.GetSection("TwitterSecrets:accessToken").Value;
            this.AccessSecret = configuration.GetSection("TwitterSecrets:accessSecret").Value;
        }
    }
}
