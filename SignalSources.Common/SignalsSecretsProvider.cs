using Microsoft.Extensions.Configuration;

namespace SignalSources.Common
{
    public class SignalsSecretsProvider
    {
        public static IConfigurationRoot GetConfigurationRoot(string path)
        {
            return new ConfigurationBuilder()
                  .AddJsonFile(path, optional: false, reloadOnChange: true)
                  .Build();
        }
        public static IConfigurationRoot GetConfigurationRoot()
        {
            return new ConfigurationBuilder()
                    .AddJsonFile("Credentials.json", optional: false, reloadOnChange: true)
                    .Build();
        }
    }
}
