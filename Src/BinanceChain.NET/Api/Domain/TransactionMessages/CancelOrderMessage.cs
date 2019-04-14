using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    internal class CancelOrderMessage : TransactionMessage
    {
        private readonly Wallet wallet;
        private readonly TransactionOption options;
        private readonly CancelOrderProto proto;

        public CancelOrderMessage(CancelOrder cancelOrder, Wallet wallet, TransactionOption options)
        {
            this.wallet = wallet;
            this.options = options;
            
            this.proto = new CancelOrderProto();
            this.proto.Symbol = cancelOrder.Symbol;
            this.proto.RefId = cancelOrder.RefId;
        }
        
        public override RequestBody ToRequest()
        {
            byte[] message = base.Encode<CancelOrderProto>(proto);
            byte[] signature = base.GetSignatureBytes(proto, wallet, options);
            byte[] stdTx = base.GetStandardTxBytes(message, signature, options);

            return new RequestBody() { Data = stdTx };
        }
    }
}
