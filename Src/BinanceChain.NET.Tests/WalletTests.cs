using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinanceChain.NET.Tests
{
    [TestClass]
    public class WalletTests
    {
        [TestMethod]
        public void CreateTest()
        {
            Wallet wallet = Wallet.Create("testpassword", EnvironmentInfo.FAKE);

            Assert.IsTrue(wallet != null);
        }
    }
}
