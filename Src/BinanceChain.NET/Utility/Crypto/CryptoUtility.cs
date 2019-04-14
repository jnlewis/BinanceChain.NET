using NBitcoin;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Utility.Crypto
{
    internal class CryptoUtility
    {
        //private static final String HD_PATH = "44H/714H/0H/0/0";

        public string GenerateMnemonicCode()
        {
            Mnemonic mnemo = new Mnemonic(Wordlist.English, WordCount.TwentyFour);
            return mnemo.ToString();
        }

        public KeyInfo GenerateKey(string password)
        {
            Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.TwentyFour);

            ExtKey extKey = mnemonic.DeriveExtKey(password);

            // Private Key
            Key privateKey = extKey.PrivateKey;

            // Public Key
            PubKey publicKey = privateKey.PubKey;

            // Address
            var address = publicKey.GetAddress(NBitcoin.Network.TestNet);

            KeyInfo keyInfo = new KeyInfo();
            keyInfo.Mnemonic = mnemonic.ToString();
            keyInfo.PrivateKey = privateKey.ToString(NBitcoin.Network.TestNet);
            keyInfo.PublicKey = publicKey.ToString();
            keyInfo.Address = address.ToString();

            return keyInfo;
        }

        public KeyInfo GetKeyFromMnemonic(string mnenonicWords, string password)
        {
            Mnemonic mnemonic = new Mnemonic(mnenonicWords, Wordlist.English);

            ExtKey extKey = mnemonic.DeriveExtKey(password);

            // Private Key
            Key privateKey = extKey.PrivateKey;

            // Public Key
            PubKey publicKey = privateKey.PubKey;

            // Address
            var address = publicKey.GetAddress(NBitcoin.Network.TestNet);

            KeyInfo keyInfo = new KeyInfo();
            keyInfo.Mnemonic = mnemonic.ToString();
            keyInfo.PrivateKey = privateKey.ToString(NBitcoin.Network.TestNet);
            keyInfo.PublicKey = publicKey.ToString();
            keyInfo.Address = address.ToString();

            return keyInfo;
        }

        public byte[] Sign(byte[] message, string privateKey)
        {
            //TODO: Implement
            return null;
        }

        //public string GetAddress()
        //{
        //    Key privateKey = new Key(); // generate a random private key
        //    BitcoinSecret bitcoinSecret = privateKey.GetWif(Network.Main); // L5B67zvrndS5c71EjkrTJZ99UaoVbMUAK58GKdQUfYCpAa6jypvn
        //    Key samePrivateKey = bitcoinSecret.PrivateKey;
        //    Console.WriteLine(samePrivateKey == privateKey); // True
        //}
    }
}
