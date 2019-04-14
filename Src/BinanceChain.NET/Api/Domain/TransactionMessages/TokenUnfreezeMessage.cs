using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    internal class TokenUnfreezeMessage : TransactionMessage
    {
        private readonly Wallet wallet;
        private readonly TransactionOption options;
        private readonly TokenUnfreezeProto proto;

        public TokenUnfreezeMessage(TokenUnfreeze tokenUnfreeze, Wallet wallet, TransactionOption options)
        {
            this.wallet = wallet;
            this.options = options;

            this.proto = new TokenUnfreezeProto();
            this.proto.From = wallet.Address;
            this.proto.Symbol = tokenUnfreeze.Symbol;
            this.proto.Amount = StringDecimalToLong(tokenUnfreeze.Amount);
        }
        
        public override RequestBody ToRequest()
        {
            byte[] message = base.Encode<TokenUnfreezeProto>(proto);
            byte[] signature = base.GetSignatureBytes(proto, wallet, options);
            byte[] stdTx = base.GetStandardTxBytes(message, signature, options);

            return new RequestBody() { Data = stdTx };
        }
    }
}
