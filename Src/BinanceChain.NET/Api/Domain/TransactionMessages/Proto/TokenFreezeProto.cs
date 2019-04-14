using ProtoBuf;
using System.Collections.Generic;

namespace BinanceChain.NET.Api.Domain.TransactionMessages.Proto
{
    internal class TokenFreezeProto : ProtoMessage
    {
        [ProtoMember(1)]
        public string From { get; set; }

        [ProtoMember(2)]
        public string Symbol { get; set; }

        [ProtoMember(3)]
        public long Amount { get; set; }
    }
}
