using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    internal class VoteMessage : TransactionMessage
    {
        private readonly Wallet wallet;
        private readonly TransactionOption options;
        private readonly VoteProto message;

        public VoteMessage(Vote vote, Wallet wallet, TransactionOption options)
        {
            this.wallet = wallet;
            this.options = options;

            this.message = new VoteProto();
            this.message.ProposalId = vote.ProposalId;
            this.message.Option = vote.Option;
        }
        
        public override string BuildMessageBody()
        {
            this.wallet.EnsureWalletIsReady();
            
            byte[] encodedMessage = base.EncodeMessage<VoteProto>(message, MessagePrefixes.Vote);
            byte[] signedBytes = base.Sign(message, wallet, options);
            byte[] signature = base.EncodeSignature(signedBytes, wallet, options);
            byte[] stdTx = base.EncodeStandardTx(encodedMessage, signature, options);

            this.wallet.IncrementSequence();

            return base.BytesToHex(stdTx);
        }
    }
}
