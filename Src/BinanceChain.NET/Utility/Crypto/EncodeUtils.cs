/*
 Reference: 
 https://github.com/binance-chain/java-sdk/blob/master/src/main/java/com/binance/dex/api/client/encoding/EncodeUtils.java
 */
using Google.Protobuf;
using System;
using System.Linq;

namespace BinanceChain.NET.Utility.Crypto
{
    public static class EncodeUtils
    {
        public static byte[] HexToBytes(string hex)
        {
            // Ref: https://stackoverflow.com/questions/321370/how-can-i-convert-a-hex-string-to-a-byte-array

            return Enumerable.Range(0, hex.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                     .ToArray();
        }

        public static string BytesToHex(byte[] bytes)
        {
            // Ref: https://stackoverflow.com/questions/311165/how-do-you-convert-a-byte-array-to-a-hexadecimal-string-and-vice-versa

            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public static byte[] AminoWrap(byte[] raw, byte[] typePrefix, bool isPrefixLength)
        {
            //Ref: https://github.com/binance-chain/java-sdk/blob/master/src/main/java/com/binance/dex/api/client/encoding/EncodeUtils.java

            int totalLen = raw.Length + typePrefix.Length;
            if (isPrefixLength)
                totalLen += CodedOutputStream.ComputeUInt64Size((ulong)totalLen);
            
            byte[] msg = new byte[totalLen];
            CodedOutputStream cos = new CodedOutputStream(msg);
            if (isPrefixLength)
                cos.WriteUInt64((ulong)(raw.Length + typePrefix.Length));
            
            for (int i = 0; i < typePrefix.Length; i++)
            {
                cos.WriteRawTag(typePrefix[i]);
            }
            for (int i = 0; i < raw.Length; i++)
            {
                cos.WriteRawTag(raw[i]);
            }
            cos.Flush();
            return msg;
        }
    }
}
