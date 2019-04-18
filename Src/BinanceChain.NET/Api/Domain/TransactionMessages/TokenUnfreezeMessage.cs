using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    internal class TokenUnfreezeMessage : TransactionMessage
    {
        private readonly Wallet wallet;
        private readonly TransactionOption options;
        private readonly TokenUnfreezeProto message;

        public TokenUnfreezeMessage(TokenUnfreeze tokenUnfreeze, Wallet wallet, TransactionOption options)
        {
            this.wallet = wallet;
            this.options = options;

            this.message = new TokenUnfreezeProto();
            this.message.From = wallet.Address;
            this.message.Symbol = tokenUnfreeze.Symbol;
            this.message.Amount = StringDecimalToLong(tokenUnfreeze.Amount);
        }

        public override string BuildMessageBody()
        {
            this.wallet.EnsureWalletIsReady();

            byte[] encodedMessage = base.EncodeMessage<TokenUnfreezeProto>(message, MessagePrefixes.Vote);
            byte[] signedBytes = base.Sign(message, wallet, options);
            byte[] signature = base.EncodeSignature(signedBytes, wallet, options);
            byte[] stdTx = base.EncodeStandardTx(encodedMessage, signature, options);

            this.wallet.IncrementSequence();

            return base.BytesToHex(stdTx);
        }
    }
}
