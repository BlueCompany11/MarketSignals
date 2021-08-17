using FluentAssertions;
using SignalSources.Common;
using SignalSources.Interfaces;
using SignalSources.Twitter;
using System;
using System.Threading.Tasks;
using Xunit;
namespace SignnalSources.Twitter.Tests
{
    public class TwitterConnectionShould
    {
        private TwitterSecrets twitterSecrets = new TwitterSecrets(SignalsSecretsProvider.GetConfigurationRoot());
        [Fact]
        public async Task Connect()
        {
            var sourceConfig = new SourceConfiguration { Id = "elonmusk"};
            var sut = new TwitterConnection(this.twitterSecrets);
            var signals = await sut.GetSignalsAsync(sourceConfig, DateTimeOffset.Now.AddDays(-40));
            signals.Should().HaveCountGreaterThan(0);
        }
    }
}
