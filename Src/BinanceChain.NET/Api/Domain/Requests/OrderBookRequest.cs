using BinanceChain.NET.Api.Attributes;

namespace BinanceChain.NET.Api.Domain.Requests
{
    public class OrderBookRequest : RequestEntity
    {
        [QueryString("symbol")]
        public string Symbol { get; set; }

        [QueryString("limit")]
        public int? Limit { get; set; }
    }
}
