
using BinanceChain.NET.Utility.Crypto;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    public static class MessagePrefixes
    {
        public static byte[] CancelOrder { get { return EncodeUtils.HexToBytes("166E681B"); } }
        public static byte[] NewOrder { get { return EncodeUtils.HexToBytes("CE6DC043"); } }
        public static byte[] TokenFreeze { get { return EncodeUtils.HexToBytes("E774B32D"); } }
        public static byte[] TokenUnfreeze { get { return EncodeUtils.HexToBytes("6515FF0D"); } }
        public static byte[] Transfer { get { return EncodeUtils.HexToBytes("2A2C87FA"); } }
        public static byte[] Vote { get { return EncodeUtils.HexToBytes("A1CADD36"); } }
        public static byte[] PubKey { get { return EncodeUtils.HexToBytes("EB5AE987"); } }
        public static byte[] StdSignature { get { return EncodeUtils.HexToBytes(""); } }
        public static byte[] StdTx { get { return new byte[0]; } }
    }
}
