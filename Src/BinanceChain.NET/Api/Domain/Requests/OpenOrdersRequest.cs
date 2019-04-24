using BinanceChain.NET.Attributes;

namespace BinanceChain.NET.Api.Domain.Requests
{
    public class OpenOrdersRequest : RequestEntity
    {
        [QueryString("address")]
        public string Address { get; set; }

        [QueryString("limit")]
        public int? Limit { get; set; }

        [QueryString("offset")]
        public int? Offset { get; set; }

        [QueryString("symbol")]
        public string Symbol { get; set; }

        [QueryString("total")]
        public int? Total { get; set; }
    }
}
