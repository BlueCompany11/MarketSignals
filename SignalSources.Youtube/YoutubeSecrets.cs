using Microsoft.Extensions.Configuration;

namespace SignalSources.Youtube
{
    public class YoutubeSecrets
    {
        public string ApiKey { get; init; }
        public YoutubeSecrets(IConfigurationRoot configuration)
        {
            this.ApiKey = configuration.GetSection("YoutubeSecrets:apiKey").Value;
        }
    }
}
