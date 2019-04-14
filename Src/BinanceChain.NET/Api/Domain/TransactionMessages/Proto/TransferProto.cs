using ProtoBuf;
using System.Collections.Generic;

namespace BinanceChain.NET.Api.Domain.TransactionMessages.Proto
{
    internal class TransferProto : ProtoMessage
    {
        public TransferProto()
        {
            Inputs = new List<InputOutputProto>();
            Outputs = new List<InputOutputProto>();
        }

        [ProtoMember(1)]
        public List<InputOutputProto> Inputs { get; private set; }

        [ProtoMember(2)]
        public List<InputOutputProto> Outputs { get; private set; }
    }
}
