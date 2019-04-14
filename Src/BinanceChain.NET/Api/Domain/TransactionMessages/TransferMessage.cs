using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    internal class TransferMessage : TransactionMessage
    {
        private readonly Wallet wallet;
        private readonly TransactionOption options;
        private readonly TransferProto proto;

        public TransferMessage(Transfer transfer, Wallet wallet, TransactionOption options)
        {
            this.wallet = wallet;
            this.options = options;
            
            TokenProto token = new TokenProto();
            token.Denom = transfer.Coin;
            token.Amount = StringDecimalToLong(transfer.Amount);

            InputOutputProto input = new InputOutputProto();
            input.Address = transfer.FromAddress;
            input.Coins.Add(token);

            InputOutputProto output = new InputOutputProto();
            output.Address = transfer.ToAddress;
            output.Coins.Add(token);

            this.proto = new TransferProto();
            this.proto.Inputs.Add(input);
            this.proto.Outputs.Add(output);
        }
        
        public override RequestBody ToRequest()
        {
            byte[] message = base.Encode<TransferProto>(proto);
            byte[] signature = base.GetSignatureBytes(proto, wallet, options);
            byte[] stdTx = base.GetStandardTxBytes(message, signature, options);

            return new RequestBody() { Data = stdTx };
        }
    }
}
