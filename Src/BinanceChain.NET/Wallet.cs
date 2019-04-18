using BinanceChain.NET.Api.Domain.TransactionMessages;
using BinanceChain.NET.Utility.Crypto;
using NBitcoin;
using System;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace BinanceChain.NET
{
    public class Wallet
    {
        public bool IsOpen { get; private set; }
        public string PrivateKey { get; private set; }
        public string MnemonicWords { get; private set; }
        public string Address { get; private set; }
        public Key EcKey { get; private set; }
        public byte[] AddressBytes { get; private set; }
        public byte[] PubKeyForSign { get; private set; }
        public long? AccountNumber { get; private set; }
        public long? Sequence { get; private set; }
        public EnvironmentInfo Environment { get; private set; }
        public string ChainId { get; private set; }
        
        public Wallet(){}

        public override string ToString()
        {
            return new StringBuilder()
                .Append($"IsOpen:{IsOpen};")
                .Append($"PrivateKey:{PrivateKey};")
                .Append($"Address:{Address};")
                .Append($"MnemonicWords:{MnemonicWords};")
                .Append($"Environment:{Environment};")
                .Append($"AccountNumber:{AccountNumber};")
                .Append($"Sequence:{Sequence};")
                .Append($"ChainId:{ChainId};")
                .ToString();
        }

        #region Static Methods

        public static Wallet NewWallet(string password, EnvironmentInfo environment)
        {
            var key = CryptoUtility.GenerateKey(password, environment.Hrp);
            
            Wallet wallet = new Wallet();
            wallet.IsOpen = true;
            wallet.PrivateKey = key.PrivateKey;
            wallet.Environment = environment;
            wallet.Address = key.Address;
            wallet.MnemonicWords = key.Mnemonic;
            wallet.EcKey = GetECKey(wallet.PrivateKey);
            wallet.AddressBytes = wallet.EcKey.PubKey.Hash.ToBytes();
            wallet.PubKeyForSign = GetPubKeyForSign(wallet.EcKey.PubKey.ToBytes());

            return wallet;
        }

        public static Wallet Open(string mnemonicWords, string password, EnvironmentInfo environment)
        {
            var key = CryptoUtility.GetKeyFromMnemonic(mnemonicWords, password, environment.Hrp);

            Wallet wallet = new Wallet();
            wallet.IsOpen = true;
            wallet.PrivateKey = key.PrivateKey;
            wallet.Environment = environment;
            wallet.EcKey = GetECKey(key.PrivateKey);
            wallet.AddressBytes = wallet.EcKey.PubKey.Hash.ToBytes();
            wallet.Address = CryptoUtility.GetAddress(wallet.AddressBytes, environment.Hrp);
            wallet.PubKeyForSign = GetPubKeyForSign(wallet.EcKey.PubKey.ToBytes());
            wallet.MnemonicWords = mnemonicWords;

            return wallet;
        }

        public static Wallet Open(string privateKey, EnvironmentInfo environment)
        {
            Wallet wallet = new Wallet();
            wallet.IsOpen = true;
            wallet.PrivateKey = privateKey;
            wallet.Environment = environment;
            wallet.EcKey = GetECKey(privateKey);
            wallet.AddressBytes = wallet.EcKey.PubKey.Hash.ToBytes();
            wallet.Address = CryptoUtility.GetAddress(wallet.AddressBytes, environment.Hrp);
            wallet.PubKeyForSign = GetPubKeyForSign(wallet.EcKey.PubKey.ToBytes());
            wallet.MnemonicWords = "";

            return wallet;
        }

        #endregion

        #region Instance Methods

        public void Close()
        {
            this.IsOpen = false;
            this.PrivateKey = null;
            this.Address = null;
            this.MnemonicWords = null;
            this.Environment = null;
            this.Sequence = -1;
        }

        public void IncrementSequence()
        {
            this.Sequence++;
        }

        public void EnsureWalletIsReady()
        {
            if (this.AccountNumber == null || this.Sequence == null)
            {
                InitAccount();
            }

            if (this.ChainId == null)
            {
                InitChainId();
            }
        }

        private void InitAccount()
        {
            var api = BinanceApiFactory.CreateApiClient(this.Environment);

            var account = api.GetAccount(this.Address);
            if (account != null)
            {
                this.AccountNumber = account.AccountNumber;
                this.Sequence = account.Sequence;
            }
            else
            {
                throw new NullReferenceException("Cannot get account information for address " + this.Address);
            }
        }

        private void InitChainId()
        {
            var api = BinanceApiFactory.CreateApiClient(this.Environment);

            var nodeInfo = api.GetNodeInfo();
            if (nodeInfo != null)
            {
                this.ChainId = nodeInfo.NodeInfo.Network;
            }
            else
            {
                throw new NullReferenceException("Cannot get chain ID");
            }
        }

        #endregion
        
        #region Static Private

        private static Key GetECKey(string privateKey)
        {
            BigInteger privateKeyBigInteger = BigInteger.Parse("0" + privateKey, NumberStyles.HexNumber);
            return new Key(privateKeyBigInteger.ToByteArray());
        }
        
        private static byte[] GetPubKeyForSign(byte[] ecKeyBytes)
        {
            //Reference: https://github.com/binance-chain/java-sdk/blob/master/src/main/java/com/binance/dex/api/client/Wallet.java

            byte[] pubKey = ecKeyBytes;
            byte[] pubKeyPrefix = MessagePrefixes.PubKey;

            byte[] pubKeyForSign = new byte[pubKey.Length + pubKeyPrefix.Length + 1];
            pubKeyPrefix.CopyTo(pubKeyForSign, 0);
            pubKeyForSign[pubKeyPrefix.Length] = 33;
            pubKey.CopyTo(pubKeyForSign, pubKeyPrefix.Length + 1);

            return pubKeyForSign;
        }

        #endregion
        
    }
}
