using Microsoft.Extensions.Configuration;
namespace SignalSources.Taapi
{
    public class TaapiSecrets
    {
        public string Secret { get; init; }
        public TaapiSecrets(IConfigurationRoot configuration)
        {
            this.Secret = configuration.GetSection("TaapiSecrets:secret").Value;
        }
    }
}
