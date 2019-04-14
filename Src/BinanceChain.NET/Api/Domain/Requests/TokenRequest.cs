using BinanceChain.NET.Api.Attributes;

namespace BinanceChain.NET.Api.Domain.Requests
{
    public class TokenRequest : RequestEntity
    {
        [QueryString("limit")]
        public int? Limit { get; set; }

        [QueryString("offset")]
        public int? Offset { get; set; }
    }
}
