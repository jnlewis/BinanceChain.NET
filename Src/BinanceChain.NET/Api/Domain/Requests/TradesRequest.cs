using BinanceChain.NET.Api.Attributes;

namespace BinanceChain.NET.Api.Domain.Requests
{
    public class TradesRequest : RequestEntity
    {
        [QueryString("address")]
        public string Address { get; set; }

        [QueryString("buyerOrderId")]
        public string BuyerOrderId { get; set; }

        [QueryString("end")]
        public long? End { get; set; }

        [QueryString("height")]
        public long? Height { get; set; }

        [QueryString("limit")]
        public int? Limit { get; set; }

        [QueryString("offset")]
        public int? Offset { get; set; }

        [QueryString("quoteAsset")]
        public string QuoteAsset { get; set; }

        [QueryString("sellerOrderId")]
        public string SellerOrderId { get; set; }

        [QueryString("side")]
        public string Side { get; set; }

        [QueryString("start")]
        public long? Start { get; set; }

        [QueryString("symbol")]
        public string Symbol { get; set; }

        [QueryString("total")]
        public int? Total { get; set; }
    }
}
