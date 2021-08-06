using FluentAssertions;
using SignalSources.Common;
using System;
using System.Threading.Tasks;
using Xunit;
namespace SignalSources.Youtube.Tests
{
    public class YoutubeConnectionShould
    {
        private YoutubeSecrets youtubeSecrets = new YoutubeSecrets(SignalsSecretsProvider.GetConfigurationRoot());
        [Fact]
        public async Task Connect()
        {
            var sut = new YoutubeConnection(this.youtubeSecrets);
            var ret = await sut.GetSignalsAsync("UCqK_GSMbpiV8spgD3ZGloSw", DateTime.Today.AddDays(-40));
            ret.Should().HaveCountGreaterThan(0);
        }
    }
}
