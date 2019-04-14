using ProtoBuf;

namespace BinanceChain.NET.Api.Domain.TransactionMessages.Proto
{
    internal class StdTxProto  : ProtoMessage
    {
        [ProtoMember(1)]
        public byte[] Msgs { get; set; }

        [ProtoMember(2)]
        public byte[] Signatures { get; set; }

        [ProtoMember(3)]
        public string Memo { get; set; }

        [ProtoMember(4)]
        public long Source { get; set; }

        [ProtoMember(5)]
        public byte[] Data { get; set; }
    }
}
