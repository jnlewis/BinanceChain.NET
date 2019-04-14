using ProtoBuf;
using System.Collections.Generic;

namespace BinanceChain.NET.Api.Domain.TransactionMessages.Proto
{
    internal class TokenProto : ProtoMessage
    {
        [ProtoMember(1)]
        public string Denom { get; set; }

        [ProtoMember(2)]
        public long Amount { get; set; }
    }
}
