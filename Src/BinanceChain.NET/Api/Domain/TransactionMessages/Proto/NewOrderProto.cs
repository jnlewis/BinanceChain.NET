using ProtoBuf;

namespace BinanceChain.NET.Api.Domain.TransactionMessages.Proto
{
    internal class NewOrderProto  : ProtoMessage
    {
        [ProtoMember(1)]
        public string Sender { get; set; }

        [ProtoMember(2)]
        public string Id { get; set; }

        [ProtoMember(3)]
        public string Symbol { get; set; }

        [ProtoMember(4)]
        public int OrderType { get; set; }

        [ProtoMember(5)]
        public int Side { get; set; }

        [ProtoMember(6)]
        public long Price { get; set; }

        [ProtoMember(7)]
        public long Quantity { get; set; }

        [ProtoMember(8)]
        public int TimeInForce { get; set; }
    }
}
