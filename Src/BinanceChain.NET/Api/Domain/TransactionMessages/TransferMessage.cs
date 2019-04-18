using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    internal class TransferMessage : TransactionMessage
    {
        private readonly Wallet wallet;
        private readonly TransactionOption options;
        private readonly TransferProto message;

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

            this.message = new TransferProto();
            this.message.Inputs.Add(input);
            this.message.Outputs.Add(output);
        }
        
        public override string BuildMessageBody()
        {
            this.wallet.EnsureWalletIsReady();
            
            byte[] encodedMessage = base.EncodeMessage<TransferProto>(message, MessagePrefixes.Transfer);
            byte[] signedBytes = base.Sign(message, wallet, options);
            byte[] signature = base.EncodeSignature(signedBytes, wallet, options);
            byte[] stdTx = base.EncodeStandardTx(encodedMessage, signature, options);

            this.wallet.IncrementSequence();

            return base.BytesToHex(stdTx);
        }
    }
}
