using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    internal class VoteMessage : TransactionMessage
    {
        private readonly Wallet wallet;
        private readonly TransactionOption options;
        private readonly VoteProto proto;

        public VoteMessage(Vote vote, Wallet wallet, TransactionOption options)
        {
            this.wallet = wallet;
            this.options = options;

            this.proto = new VoteProto();
            this.proto.ProposalId = vote.ProposalId;
            this.proto.Option = vote.Option;
        }
        
        public override RequestBody ToRequest()
        {
            byte[] message = base.Encode<VoteProto>(proto);
            byte[] signature = base.GetSignatureBytes(proto, wallet, options);
            byte[] stdTx = base.GetStandardTxBytes(message, signature, options);

            return new RequestBody() { Data = stdTx };
        }
    }
}
