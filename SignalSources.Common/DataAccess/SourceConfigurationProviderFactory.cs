using SignalSources.Interfaces;

namespace SignalSources.Common.DataAccess
{
    public partial class SourceConfigurationProvider
    {
        public static class SourceConfigurationProviderFactory
        {
            public static IDataAccess<SourceConfiguration> GetYoutube()
            {
                return new SourceConfigurationProvider("youtube.json");
            }
            public static IDataAccess<SourceConfiguration> GetTwitter()
            {
                return new SourceConfigurationProvider("twitter.json");
            }
        }
    }
    
}
