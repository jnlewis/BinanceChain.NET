using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    internal class TokenFreezeMessage : TransactionMessage
    {
        private readonly Wallet wallet;
        private readonly TransactionOption options;
        private readonly TokenFreezeProto message;

        public TokenFreezeMessage(TokenFreeze tokenFreeze, Wallet wallet, TransactionOption options)
        {
            this.wallet = wallet;
            this.options = options;

            this.message = new TokenFreezeProto();
            this.message.From = wallet.Address;
            this.message.Symbol = tokenFreeze.Symbol;
            this.message.Amount = StringDecimalToLong(tokenFreeze.Amount);
        }

        public override string BuildMessageBody()
        {
            this.wallet.EnsureWalletIsReady();

            byte[] encodedMessage = base.EncodeMessage<TokenFreezeProto>(message, MessagePrefixes.Vote);
            byte[] signedBytes = base.Sign(message, wallet, options);
            byte[] signature = base.EncodeSignature(signedBytes, wallet, options);
            byte[] stdTx = base.EncodeStandardTx(encodedMessage, signature, options);

            return base.BytesToHex(stdTx);
        }
    }
}
