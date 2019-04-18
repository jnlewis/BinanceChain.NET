using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinanceChain.NET.Tests
{
    [TestClass]
    public class WalletTests
    {
        [TestMethod]
        public void NewWallet_Test()
        {
            Wallet wallet = Wallet.NewWallet("testpassword", EnvironmentInfo.TESTNET);
            
            Assert.IsTrue(wallet != null);
        }
    }
}
