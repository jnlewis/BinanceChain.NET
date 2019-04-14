using ProtoBuf;
using System.Collections.Generic;

namespace BinanceChain.NET.Api.Domain.TransactionMessages.Proto
{
    internal class InputOutputProto : ProtoMessage
    {
        public InputOutputProto()
        {
            Coins = new List<TokenProto>();
        }

        [ProtoMember(1)]
        public string Address { get; set; }

        [ProtoMember(2)]
        public List<TokenProto> Coins { get; private set; }
    }
}
