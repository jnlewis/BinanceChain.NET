using ProtoBuf;

namespace BinanceChain.NET.Api.Domain.TransactionMessages.Proto
{
    //message StdSignature
    //{
    //    // please note there is no type prefix for StdSignature
    //    message PubKey
    //    {
    //        //        0xEB5AE987 // hardcoded, object type prefix in 4 bytes
    //        //        bytes // no name or field id, just encode the bytes
    //    }
    //    bytes pub_key = 1; // public key bytes of the signer address
    //    bytes signature = 2; // signature bytes, please check chain access section for signature generation
    //    int64 account_number = 3; // another identifier of signer, which can be read from chain by account REST API or RPC
    //    int64 sequence = 4; // sequence number for the next transaction of the client, which can be read fro chain by account REST API or RPC. please check chain acces section for details.
    //}
    internal class StdSignatureProto : ProtoMessage
    {
        [ProtoMember(1)]
        public byte[] PubKey { get; set; }

        [ProtoMember(2)]
        public byte[] Signature { get; set; }

        [ProtoMember(3)]
        public long AccountNumber { get; set; }

        [ProtoMember(4)]
        public long Sequence { get; set; }
    }
}
