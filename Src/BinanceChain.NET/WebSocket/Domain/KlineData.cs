using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    /*
     {
      "stream": "kline_1m",
      "data": {
        "e": "kline",         // Event type
        "E": 123456789,       // Event time
        "s": "BNBBTC",        // Symbol
        "k": {
          "t": 123400000,     // Kline start time
          "T": 123460000,     // Kline close time
          "s": "BNBBTC",      // Symbol
          "i": "1m",          // Interval
          "f": "100",         // First trade ID
          "L": "200",         // Last trade ID
          "o": "0.0010",      // Open price
          "c": "0.0020",      // Close price
          "h": "0.0025",      // High price
          "l": "0.0015",      // Low price
          "v": "1000",        // Base asset volume
          "n": 100,           // Number of trades
          "x": false,         // Is this kline closed?
          "q": "1.0000",      // Quote asset volume
        }
      }
    }
    */

    public class KlineData
    {
        [JsonProperty("e")]
        public string EventType { get; set; }

        [JsonProperty("E")]
        public string EventHeight { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("k")]
        public KlineDetailsData Kline { get; set; }
    }
}
