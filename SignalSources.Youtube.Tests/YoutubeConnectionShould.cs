using FluentAssertions;
using SignalSources.Common;
using SignalSources.Interfaces;
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
            var sourceConfig = new SourceConfiguration { Id = "UCqK_GSMbpiV8spgD3ZGloSw"};
            var sut = new YoutubeConnection(this.youtubeSecrets);
            var ret = await sut.GetSignalsAsync(sourceConfig, DateTime.Today.AddDays(-40));
            ret.Should().HaveCountGreaterThan(0);
        }
    }
}
