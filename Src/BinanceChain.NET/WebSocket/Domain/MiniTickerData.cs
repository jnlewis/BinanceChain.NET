using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    /*
     {
      "stream": "miniTicker",
      "data": {
        "e": "24hrMiniTicker",    // Event type
        "E": 123456789,           // Event time
        "s": "BNBBTC",            // Symbol
        "c": "0.0025",            // Current day's close price
        "o": "0.0010",            // Open price
        "h": "0.0025",            // High price
        "l": "0.0010",            // Low price
        "v": "10000",             // Total traded base asset volume
        "q": "18",                // Total traded quote asset volume
      }
    }
    */

    public class MiniTickerData
    {
        [JsonProperty("e")]
        public string EventType { get; set; }

        [JsonProperty("E")]
        public string EventHeight { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; }
        
        [JsonProperty("c")]
        public string CurrentDaysClosePrice { get; set; }

        [JsonProperty("o")]
        public string OpenPrice { get; set; }

        [JsonProperty("h")]
        public string HighPrice { get; set; }

        [JsonProperty("l")]
        public string LowPrice { get; set; }

        [JsonProperty("v")]
        public string TotalTradedBaseAssetVolume { get; set; }
    
        [JsonProperty("q")]
        public string TotalTradedQuoteAssetVolume { get; set; }
    }
}
