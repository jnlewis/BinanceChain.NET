using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    /*
     {
        "stream": "marketDiff",
        "data": {
            "e": "depthUpdate",   // Event type
            "E": 123456789,       // Event time
            "s": "BNB_BTC",       // Symbol
            "b": [                // Bids to be updated
                [
                "0.0024",         // Price level to be updated
                "10"              // Quantity
                ]
            ],
            "a": [                // Asks to be updated
                [
                "0.0026",         // Price level to be updated
                "100"             // Quantity
                ]
            ]
        }
    }
    */

    public class MarketDiffData
    {
        [JsonProperty("e")]
        public string EventType { get; set; }

        [JsonProperty("E")]
        public string EventHeight { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("b")]
        public List<List<string>> BidsToBeUpdated { get; set; }
        [JsonProperty("a")]
        public List<List<string>> AsksToBeUpdated { get; set; }
    }
}
