using BinanceChain.NET.Attributes;

namespace BinanceChain.NET.NodeRPC.Domain.Requests
{
    public class ABCIQueryRequest : RequestEntity
    {
        [QueryString("path")]
        public string Path { get; set; }

        [QueryString("data")]
        public string Data { get; set; }
    }
}
