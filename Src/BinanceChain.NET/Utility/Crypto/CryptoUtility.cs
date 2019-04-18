using NBitcoin;
using NBitcoin.Crypto;
using NBitcoin.DataEncoders;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace BinanceChain.NET.Utility.Crypto
{
    internal static class CryptoUtility
    {
        //private static final String HD_PATH = "44H/714H/0H/0/0";

        public static string GenerateMnemonicCode()
        {
            Mnemonic mnemo = new Mnemonic(Wordlist.English, WordCount.TwentyFour);
            return mnemo.ToString();
        }

        public static KeyInfo GenerateKey(string password, string hrp)
        {
            Mnemonic mnemonic = new Mnemonic(Wordlist.English, WordCount.TwentyFour);

            ExtKey extKey = mnemonic.DeriveExtKey(password);
            Key privateKey = extKey.PrivateKey;
            PubKey publicKey = privateKey.PubKey;
            string address = GetAddress(publicKey.Hash.ToBytes(), hrp);
            
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.Mnemonic = mnemonic.ToString();
            keyInfo.PrivateKey = EncodeUtils.BytesToHex(privateKey.ToBytes()).ToLower();
            keyInfo.PublicKey = publicKey.ToString();
            keyInfo.Address = address;

            return keyInfo;
        }

        public static KeyInfo GetKeyFromMnemonic(string mnenonicWords, string password, string hrp)
        {
            Mnemonic mnemonic = new Mnemonic(mnenonicWords, Wordlist.English);

            ExtKey extKey = mnemonic.DeriveExtKey(password);
            
            Key privateKey = extKey.PrivateKey;
            PubKey publicKey = privateKey.PubKey;
            string address = GetAddress(publicKey.Hash.ToBytes(), hrp);

            KeyInfo keyInfo = new KeyInfo();
            keyInfo.Mnemonic = mnemonic.ToString();
            keyInfo.PrivateKey = EncodeUtils.BytesToHex(privateKey.ToBytes()).ToLower();
            keyInfo.PublicKey = publicKey.ToString();
            keyInfo.Address = address;

            return keyInfo;
        }

        public static byte[] Sign(object data, Key privateKey)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            return Sign(Encoding.UTF8.GetBytes(serializedData), privateKey);
        }

        public static byte[] Sign(byte[] message, Key privateKey)
        {
            byte[] hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(message);
            }

            ECDSASignature signature = privateKey.Sign(new uint256(hash, true), false);

            byte[] signatureBytes = new byte[64];
            signature.R.ToByteArrayUnsigned().CopyTo(signatureBytes, 0);
            signature.S.ToByteArrayUnsigned().CopyTo(signatureBytes, 32);

            return signatureBytes;
        }

        public static string GetAddress(byte[] addressBytes, string hrp)
        {
            const string pbase32 = "abcdefghijklmnopqrstuvwxyz234567";

            string b32 = Encoders.Base32.EncodeData(addressBytes);
            byte[] address32 = new byte[b32.Length];
            for (int i = 0; i < b32.Length; i++)
            {
                address32[i] = (byte)pbase32.IndexOf(b32[i]);
            }

            Bech32Encoder bech32Encoder = Encoders.Bech32(hrp);
            return bech32Encoder.EncodeData(address32);
        }
    }
}
