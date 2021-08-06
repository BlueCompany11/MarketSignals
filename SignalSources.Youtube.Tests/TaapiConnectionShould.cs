using SignalSources.Common;
using SignalSources.Taapi;
using System.Threading.Tasks;
using Xunit;

namespace SignalSources.Youtube.Tests
{
    public class TaapiConnectionShould
    {
        private TaapiSecrets taapiSecrets = new TaapiSecrets(SignalsSecretsProvider.GetConfigurationRoot());
        [Fact]
        public async Task Connect()
        {
            var sut = new TaapiConnection(this.taapiSecrets);
            await sut.Connect();
        }
    }
}
