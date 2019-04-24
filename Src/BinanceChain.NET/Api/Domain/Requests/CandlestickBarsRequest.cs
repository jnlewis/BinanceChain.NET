using BinanceChain.NET.Attributes;

namespace BinanceChain.NET.Api.Domain.Requests
{
    public class CandlestickBars : RequestEntity
    {
        [QueryString("symbol")]
        public string Symbol { get; set; }

        [QueryString("interval")]
        public string Interval { get; set; }

        [QueryString("limit")]
        public int? Limit { get; set; }

        [QueryString("startTime")]
        public int? StartTime { get; set; }

        [QueryString("endTime")]
        public int? EndTime { get; set; }
    }
}
