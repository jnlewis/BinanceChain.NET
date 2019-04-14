using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Candlestick : DomainEntity
    {
        [JsonProperty("openTime")]
        public long OpenTime { get; set; }

        [JsonProperty("open")]
        public string Open { get; set; }

        [JsonProperty("high")]
        public string High { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }

        [JsonProperty("close")]
        public string Close { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("closeTime")]
        public long CloseTime { get; set; }

        [JsonProperty("quoteAssetVolume")]
        public string QuoteAssetVolume { get; set; }

        [JsonProperty("numberOfTrades")]
        public long NumberOfTrades { get; set; }
    }
}
