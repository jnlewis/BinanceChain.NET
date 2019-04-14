using ProtoBuf;

namespace BinanceChain.NET.Api.Domain.TransactionMessages.Proto
{
    internal class CancelOrderProto : ProtoMessage
    {
        [ProtoMember(1)]
        public string Symbol { get; set; }

        [ProtoMember(2)]
        public string RefId { get; set; }
    }
}
