using BinanceChain.NET.Attributes;
using System.Collections.Generic;

namespace BinanceChain.NET.Api.Domain.Requests
{
    public class ClosedOrdersRequest : RequestEntity
    {
        public ClosedOrdersRequest()
        {
            Status = new List<OrderStatuses>();
        }

        [QueryString("address")]
        public string Address { get; set; }

        [QueryString("end")]
        public long? End { get; set; }

        [QueryString("limit")]
        public int? Limit { get; set; }

        [QueryString("offset")]
        public int? Offset { get; set; }

        [QueryString("side")]
        public string Side { get; set; }

        [QueryString("start")]
        public long? Start { get; set; }

        [QueryString("status")]
        public List<OrderStatuses> Status { get; private set; }

        [QueryString("symbol")]
        public string Symbol { get; set; }

        [QueryString("total")]
        public int? Total { get; set; }
    }
}
