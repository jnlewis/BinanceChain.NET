using ProtoBuf;

namespace BinanceChain.NET.Api.Domain.TransactionMessages.Proto
{
    internal class VoteProto : ProtoMessage
    {
        [ProtoMember(1)]
        public long ProposalId { get; set; }

        [ProtoMember(2)]
        public int Option { get; set; }
    }
}
