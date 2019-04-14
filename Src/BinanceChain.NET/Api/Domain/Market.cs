using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Market : DomainEntity
    {
        [JsonProperty("baseAssetSymbol")]
        public string BaseAssetSymbol { get; set; }

        [JsonProperty("quoteAssetSymbol")]
        public string QuoteAssetSymbol { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("tickSize")]
        public string TickSize { get; set; }

        [JsonProperty("lotSize")]
        public string LotSize { get; set; }
    }
}
