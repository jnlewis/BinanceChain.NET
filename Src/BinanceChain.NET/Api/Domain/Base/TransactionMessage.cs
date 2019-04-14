using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;
using BinanceChain.NET.Utility.Crypto;
using BinanceChain.NET.Api.Domain.TransactionMessages;

namespace BinanceChain.NET.Api.Domain
{
    internal abstract class TransactionMessage
    {
        public abstract RequestBody ToRequest();

        public long StringDecimalToLong(string value)
        {
            return Convert.ToInt64(value);  //TODO: format decimals
        }

        public byte[] Encode<T>(T message) where T : class
        {
            return this.ProtoSerialize<T>(message);
        }

        public byte[] GetSignatureBytes(ProtoMessage message, Wallet wallet, TransactionOption options)
        {
            return Encode<byte[]>(Sign(message, wallet, options));
        }

        public byte[] Sign(ProtoMessage message, Wallet wallet, TransactionOption options)
        {
            SignData sd = new SignData();
            //sd.ChainId = wallet.ChainId;    //TODO:
            //sd.AccountNumber = wallet.AccountNumber;    //TODO:
            sd.Sequence = wallet.Sequence.ToString();
            sd.Msgs = new List<ProtoMessage>() { message };
            sd.Memo = options.Memo;
            sd.Source = options.Source;
            sd.Data = options.Data;

            //byte[] sdBytes = JsonConvert.SerializeObject(sd).ToByteArray(); //TODO:
            byte[] sdBytes = null;

            CryptoUtility util = new CryptoUtility();
            return util.Sign(sdBytes, wallet.PrivateKey);
        }

        public byte[] GetStandardTxBytes(byte[] message, byte[] signature, TransactionOption options)
        {
            return Encode<StdTxProto>(BuildStandardTx(message, signature, options));
        }

        public StdTxProto BuildStandardTx(byte[] message, byte[] signature, TransactionOption options)
        {
            StdTxProto stdTx = new StdTxProto();
            stdTx.Msgs = message;
            stdTx.Signatures = signature;
            stdTx.Memo = options.Memo;
            stdTx.Source = options.Source;
            stdTx.Data = options.Data != null ? options.Data : null;

            return stdTx;
        }

        private byte[] ProtoSerialize<T>(T record) where T : class
        {
            if (record == null)
                return null;

            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, record);
                return stream.ToArray();
            }
        }

        private T ProtoDeserialize<T>(byte[] data) where T : class
        {
            if (data == null)
                return null;

            using (var stream = new MemoryStream(data))
            {
                return Serializer.Deserialize<T>(stream);
            }
        }
        
    }
}
