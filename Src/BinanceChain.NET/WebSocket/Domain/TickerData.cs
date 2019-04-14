using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    /*
     {
      "stream": "ticker",
      "data": {
        "e": "24hrTicker",  // Event type
        "E": 123456789,     // Event time
        "s": "BNBBTC",      // Symbol
        "p": "0.0015",      // Price change
        "P": "250.00",      // Price change percent
        "w": "0.0018",      // Weighted average price
        "x": "0.0009",      // Previous day's close price
        "c": "0.0025",      // Current day's close price
        "Q": "10",          // Close trade's quantity
        "b": "0.0024",      // Best bid price
        "B": "10",          // Best bid quantity
        "a": "0.0026",      // Best ask price
        "A": "100",         // Best ask quantity
        "o": "0.0010",      // Open price
        "h": "0.0025",      // High price
        "l": "0.0010",      // Low price
        "v": "10000",       // Total traded base asset volume
        "q": "18",          // Total traded quote asset volume
        "O": 0,             // Statistics open time
        "C": 86400000,      // Statistics close time
        "F": "0",           // First trade ID
        "L": "18150",       // Last trade Id
        "n": 18151          // Total number of trades
      }
    }
    */

    public class TickerData
    {
        [JsonProperty("e")]
        public string EventType { get; set; }

        [JsonProperty("E")]
        public string EventHeight { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("p")]
        public string PriceChange { get; set; }
    
        [JsonProperty("P")]
        public string PriceChangePercent { get; set; }

        [JsonProperty("w")]
        public string WeightedAveragePrice { get; set; }

        [JsonProperty("x")]
        public string PreviousDaysClosePrice { get; set; }

        [JsonProperty("c")]
        public string CurrentDaysClosePrice { get; set; }

        [JsonProperty("Q")]
        public string CloseTradesQuantity { get; set; }
        
        [JsonProperty("b")]
        public string BestBidPrice { get; set; }

        [JsonProperty("B")]
        public string BestBidQuantity { get; set; }

        [JsonProperty("a")]
        public string BestAskPrice { get; set; }

        [JsonProperty("A")]
        public string BestAskQuantity { get; set; }
        
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

        [JsonProperty("O")]
        public string StatisticsOpenTime { get; set; }

        [JsonProperty("C")]
        public string StatisticsCloseTime { get; set; }

        [JsonProperty("F")]
        public string FirstTradeID { get; set; }

        [JsonProperty("L")]
        public string LastTradeId { get; set; }

        [JsonProperty("n")]
        public string TotalNumberOfTrades { get; set; }
    }
}
