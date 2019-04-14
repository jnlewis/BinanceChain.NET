using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    /*
     {
        "stream": "marketDepth",
        "data": {
            "lastUpdateId": 160,    // Last update ID
            "symbol": "BNB_BTC",    // symbol
            "bids": [               // Bids to be updated
                [
                "0.0024",           // Price level to be updated
                "10"                // Quantity
                ]
            ],
            "asks": [               // Asks to be updated
                [
                "0.0026",           // Price level to be updated
                "100"               // Quantity
                ]
            ]
        }
    }
    */

    public class MarketDepthData
    {
        [JsonProperty("lastUpdateId")]
        public string LastUpdateId { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("bids")]
        public List<List<string>> BidsToBeUpdated { get; set; }
        [JsonProperty("asks")]
        public List<List<string>> AsksToBeUpdated { get; set; }
    }
}
