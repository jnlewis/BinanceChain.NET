using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    internal class TokenFreezeMessage : TransactionMessage
    {
        private readonly Wallet wallet;
        private readonly TransactionOption options;
        private readonly TokenFreezeProto proto;

        public TokenFreezeMessage(TokenFreeze tokenFreeze, Wallet wallet, TransactionOption options)
        {
            this.wallet = wallet;
            this.options = options;

            this.proto = new TokenFreezeProto();
            this.proto.From = wallet.Address;
            this.proto.Symbol = tokenFreeze.Symbol;
            this.proto.Amount = StringDecimalToLong(tokenFreeze.Amount);
        }
        
        public override RequestBody ToRequest()
        {
            byte[] message = base.Encode<TokenFreezeProto>(proto);
            byte[] signature = base.GetSignatureBytes(proto, wallet, options);
            byte[] stdTx = base.GetStandardTxBytes(message, signature, options);

            return new RequestBody() { Data = stdTx };
        }
    }
}
