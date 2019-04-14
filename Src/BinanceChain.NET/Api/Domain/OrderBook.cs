using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class OrderBook : DomainEntity
    {
        [JsonProperty("asks")]
        public List<OrderBookEntry> Asks { get; set; }

        [JsonProperty("bids")]
        public List<OrderBookEntry> Bids { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }
}
