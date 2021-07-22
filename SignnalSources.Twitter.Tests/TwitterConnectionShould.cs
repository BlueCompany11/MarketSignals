using SignalSources.Twitter;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SignnalSources.Twitter.Tests
{
    public class TwitterConnectionShould
    {
        [Fact]
        public async Task Test1()
        {
            var sut = new TwitterConnection();
            await sut.X();
        }
        [Fact]
        public void Test2()
        {
            var a = DateTimeOffset.Now;
            var b = DateTimeOffset.Now.AddHours(-1);
            Assert.True(a > b);
        }
    }
}
