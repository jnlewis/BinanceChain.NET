using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    public class KlineDetailsData
    {
        [JsonProperty("t")]
        public string KlineStartTime { get; set; }

        [JsonProperty("T")]
        public string KlineCloseTime { get; set; }
        
        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("i")]
        public string Interval { get; set; }

        [JsonProperty("f")]
        public string FirstTradeID { get; set; }
        
        [JsonProperty("L")]
        public string LastTradeID { get; set; }

        [JsonProperty("o")]
        public string OpenPrice { get; set; }

        [JsonProperty("c")]
        public string ClosePrice { get; set; }

        [JsonProperty("h")]
        public string HighPrice { get; set; }

        [JsonProperty("l")]
        public string LowPrice { get; set; }

        [JsonProperty("v")]
        public string BaseAssetVolume { get; set; }

        [JsonProperty("n")]
        public string NumberOfTrades { get; set; }

        [JsonProperty("x")]
        public string IsClosed { get; set; }

        [JsonProperty("q")]
        public string QuoteAssetVolume { get; set; }
    }
}
