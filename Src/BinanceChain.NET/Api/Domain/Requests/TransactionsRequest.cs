using BinanceChain.NET.Api.Attributes;

namespace BinanceChain.NET.Api.Domain.Requests
{
    public class TransactionsRequest : RequestEntity
    {
        [QueryString("address")]
        public string Address { get; set; }

        [QueryString("blockHeight")]
        public long BlockHeight { get; set; }

        [QueryString("endTime")]
        public long EndTime { get; set; }

        [QueryString("limit")]
        public int Limit { get; set; }

        [QueryString("offset")]
        public int Offset { get; set; }

        [QueryString("side")]
        public string Side { get; set; }

        [QueryString("startTime")]
        public long StartTime { get; set; }

        [QueryString("txAsset")]
        public string TxAsset { get; set; }

        [QueryString("txType")]
        public TransactionTypes TxType { get; set; }
    }
}
