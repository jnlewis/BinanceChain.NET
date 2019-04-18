using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    internal class CancelOrderMessage : TransactionMessage
    {
        private readonly Wallet wallet;
        private readonly TransactionOption options;
        private readonly CancelOrderProto message;

        public CancelOrderMessage(CancelOrder cancelOrder, Wallet wallet, TransactionOption options)
        {
            this.wallet = wallet;
            this.options = options;
            
            this.message = new CancelOrderProto();
            this.message.Symbol = cancelOrder.Symbol;
            this.message.RefId = cancelOrder.RefId;
        }

        public override string BuildMessageBody()
        {
            this.wallet.EnsureWalletIsReady();

            byte[] encodedMessage = base.EncodeMessage<CancelOrderProto>(message, MessagePrefixes.Vote);
            byte[] signedBytes = base.Sign(message, wallet, options);
            byte[] signature = base.EncodeSignature(signedBytes, wallet, options);
            byte[] stdTx = base.EncodeStandardTx(encodedMessage, signature, options);

            return base.BytesToHex(stdTx);
        }
    }
}
