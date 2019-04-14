using BinanceChain.NET.Api;
using BinanceChain.NET.Tests.Mocks;
using BinanceChain.NET.Utility.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinanceChain.NET.Tests
{
    [TestClass]
    public class BinanceChainApiClientTests
    {
        [TestMethod]
        public void GetTimeTest()
        {
            IHttpClient httpClient = new MockHttpClient();

            BinanceChainApiClient client = new BinanceChainApiClient("http://localhost/testapi", httpClient);
            var time = client.GetTime();

            Assert.IsTrue(time.BlockTime != null);
        }
    }
}
