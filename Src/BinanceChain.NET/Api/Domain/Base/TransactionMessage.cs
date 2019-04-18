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
        public abstract string BuildMessageBody();

        public long StringDecimalToLong(string value)
        {
            decimal MULTIPLY_FACTOR = 1e8M;
            decimal encodeValue = decimal.Multiply(Convert.ToDecimal(value), MULTIPLY_FACTOR);
            if (encodeValue.CompareTo(decimal.Zero) <= 0)
            {
                throw new ArgumentException(value + " is less or equal to zero.");
            }
            if (encodeValue.CompareTo(long.MaxValue) > 0)
            {
                throw new ArgumentException(value + " is too large.");
            }
            return decimal.ToInt64(encodeValue);
        }
        
        public string BytesToHex(byte[] bytes)
        {
            return EncodeUtils.BytesToHex(bytes);
        }

        public byte[] Sign(ProtoMessage message, Wallet wallet, TransactionOption options)
        {
            SignData signData = new SignData();
            signData.ChainId = wallet.ChainId;
            signData.AccountNumber = wallet.AccountNumber.ToString();
            signData.Sequence = wallet.Sequence.ToString();
            signData.Msgs = new List<ProtoMessage>() { message };
            signData.Memo = options.Memo;
            signData.Source = options.Source;
            signData.Data = options.Data;

            return CryptoUtility.Sign(signData, wallet.EcKey);
        }

        public byte[] EncodeSignature(byte[] signature, Wallet wallet, TransactionOption options)
        {
            StdSignatureProto stdSignature = new StdSignatureProto
            {
                PubKey = wallet.PubKeyForSign,
                Signature = signature,
                AccountNumber = wallet.AccountNumber.Value,
                Sequence = wallet.Sequence.Value
            };
            
            return EncodeMessage<StdSignatureProto>(stdSignature, MessagePrefixes.StdSignature);
        }

        public byte[] EncodeStandardTx(byte[] message, byte[] signature, TransactionOption options)
        {
            StdTxProto stdTx = new StdTxProto()
            {
                Msgs = message,
                Signatures = signature,
                Memo = options.Memo,
                Source = options.Source,
                Data = options.Data != null ? options.Data : null
            };
            
            return EncodeMessage<StdTxProto>(stdTx, MessagePrefixes.StdTx);
        }

        public byte[] EncodeMessage<T>(T message, byte[] prefix) where T : class
        {
            return EncodeUtils.AminoWrap(this.ProtoSerialize<T>(message), prefix, false);
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
