using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    /*
     {
        "stream": "trades",
        "data": [{
            "e": "trade",       // Event type
            "E": 123456789,     // Event height
            "s": "BNB_BTC",     // Symbol
            "t": "12345",       // Trade ID
            "p": "0.001",       // Price
            "q": "100",         // Quantity
            "b": "88",          // Buyer order ID
            "a": "50",          // Seller order ID
            "T": 123456785,     // Trade time
            "sa": "bnb1me5u083m2spzt8pw8vunprnctc8syy64hegrcp", // SellerAddress
            "ba": "bnb1kdr00ydr8xj3ydcd3a8ej2xxn8lkuja7mdunr5" // BuyerAddress
        },
        {
            "e": "trade",       // Event type
            "E": 123456795,     // Event time
            "s": "BNB_BTC",     // Symbol
            "t": "12348",       // Trade ID
            "p": "0.001",       // Price
            "q": "100",         // Quantity
            "b": "88",          // Buyer order ID
            "a": "52",          // Seller order ID
            "T": 123456795,     // Trade time
            "sa": "bnb1me5u083m2spzt8pw8vunprnctc8syy64hegrcp", // SellerAddress
            "ba": "bnb1kdr00ydr8xj3ydcd3a8ej2xxn8lkuja7mdunr5" // BuyerAddress
        }]
    }
    */

    public class TradesData
    {
        [JsonProperty("e")]
        public string EventType { get; set; }

        [JsonProperty("E")]
        public string EventHeight { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("t")]
        public string TradeID { get; set; }

        [JsonProperty("p")]
        public string Price { get; set; }

        [JsonProperty("q")]
        public string Quantity { get; set; }

        [JsonProperty("b")]
        public string BuyerOrderID { get; set; }

        [JsonProperty("a")]
        public string SellerOrderID { get; set; }

        [JsonProperty("T")]
        public string TradeTime { get; set; }

        [JsonProperty("sa")]
        public string SellerAddress { get; set; }

        [JsonProperty("ba")]
        public string BuyerAddress { get; set; }
    }
}
