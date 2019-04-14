using BinanceChain.NET.Utility.Crypto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinanceChain.NET.Tests.Utility.Crypto
{
    [TestClass]
    public class CryptoUtilityTests
    {
        [TestMethod]
        public void GenerateMnemonicCodeTest()
        {
            CryptoUtility util = new CryptoUtility();
            string mnemonicCodes = util.GenerateMnemonicCode();

            Assert.IsTrue(!string.IsNullOrEmpty(mnemonicCodes));
        }
    }
}
