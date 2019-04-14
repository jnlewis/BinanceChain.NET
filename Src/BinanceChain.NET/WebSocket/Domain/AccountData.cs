using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    /*
     {
        "stream": "accounts",
        "data": [{
          "e": "outboundAccountInfo",   // Event type
          "E": 1499405658849,           // Event height
          "B": [                        // Balances array
            {
              "a": "LTC",               // Asset
              "f": "17366.18538083",    // Free amount
              "l": "0.00000000",        // Locked amount
              "r": "0.00000000"         // Frozen amount
            },
            {
              "a": "BTC",
              "f": "10537.85314051",
              "l": "2.19464093",
              "r": "0.00000000"
            },
            {
              "a": "ETH",
              "f": "17902.35190619",
              "l": "0.00000000",
              "r": "0.00000000"
            }
          ]
        }]
    }
    */

    public class AccountData
    {
        [JsonProperty("e")]
        public string EventType { get; set; }

        [JsonProperty("E")]
        public string EventHeight { get; set; }

        [JsonProperty("B")]
        public List<AccountBalanceData> Balances { get; set; }
    }
}
