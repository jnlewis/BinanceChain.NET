using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Utility.Crypto
{
    internal class KeyInfo
    {
        public string Mnemonic { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        public string Address { get; set; }
    }
}
