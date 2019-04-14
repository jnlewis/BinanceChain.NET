using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    /*
     {
        "stream": "orders",
        "data": [{
            "e": "executionReport",        // Event type
            "E": 1499405658658,            // Event height
            "s": "ETH_BTC",                // Symbol
            "S": 1,                        // Side, 1 for Buy; 2 for Sell
            "o": 2,                        // Order type, 2 for LIMIT (only)
            "f": 1,                        // Time in force,  1 for Good Till Expire (GTE); 3 for Immediate Or Cancel (IOC)
            "q": "1.00000000",             // Order quantity
            "p": "0.10264410",             // Order price
            "x": "NEW",                    // Current execution type
            "X": "Ack",                    // Current order status, possible values Ack, Canceled, Expired, IocNoFill, PartialFill, FullyFill, FailedBlocking, FailedMatching, Unknown
            "i": "91D9...7E18-2317",       // Order ID
            "l": "0.00000000",             // Last executed quantity
            "z": "0.00000000",             // Cumulative filled quantity
            "L": "0.00000000",             // Last executed price
            "n": "10000BNB",               // Commission amount for all user trades within a given block. Fees will be displayed with each order but will be charged once.
                                           // Fee can be composed of a single symbol, ex: "10000BNB"
                                           // or multiple symbols if the available "BNB" balance is not enough to cover the whole fees, ex: "1.00000000BNB;0.00001000BTC;0.00050000ETH"
            "T": 1499405658657,            // Transaction time
            "t": "TRD1",                   // Trade ID
            "O": 1499405658657,            // Order creation time
        },
        {
            "e": "executionReport",        // Event type
            "E": 1499405658658,            // Event height
            "s": "ETH_BNB",                // Symbol
            "S": "BUY",                    // Side
            "o": "LIMIT",                  // Order type
            "f": "GTE",                    // Time in force
            "q": "1.00000000",             // Order quantity
            "p": "0.10264410",             // Order price
            "x": "NEW",                    // Current execution type
            "X": "Ack",                    // Current order status
            "i": 4293154,                  // Order ID
            "l": "0.00000000",             // Last executed quantity
            "z": "0.00000000",             // Cumulative filled quantity
            "L": "0.00000000",             // Last executed price
            "n": "10000BNB",               // Commission amount for all user trades within a given block. Fees will be displayed with each order but will be charged once.
                                            // Fee can be composed of a single symbol, ex: "10000BNB"
                                            // or multiple symbols if the available "BNB" balance is not enough to cover the whole fees, ex: "1.00000000BNB;0.00001000BTC;0.00050000ETH"
            "T": 1499405658657,            // Transaction time
            "t": "TRD2",                   // Trade ID
            "O": 1499405658657,            // Order creation time
          }]
      }
    */

    public class OrdersData
    {
        [JsonProperty("e")]
        public string EventType { get; set; }

        [JsonProperty("E")]
        public string EventHeight { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("S")]
        public string Side { get; set; }

        [JsonProperty("o")]
        public string OrderType { get; set; }

        [JsonProperty("f")]
        public string TimeInForce { get; set; }

        [JsonProperty("q")]
        public string OrderQuantity { get; set; }

        [JsonProperty("p")]
        public string OrderPrice { get; set; }

        [JsonProperty("x")]
        public string CurrentExecutionType { get; set; }

        [JsonProperty("X")]
        public string CurrentOrderStatus { get; set; }

        [JsonProperty("i")]
        public string OrderID { get; set; }

        [JsonProperty("l")]
        public string LastExecutedQuantity { get; set; }

        [JsonProperty("Z")]
        public string CumulativeFilledQuantity { get; set; }

        [JsonProperty("L")]
        public string LastExecutedPrice { get; set; }
        
        [JsonProperty("n")]
        public string Commission { get; set; }

        [JsonProperty("T")]
        public string TransactionTime { get; set; }

        [JsonProperty("t")]
        public string TradeID { get; set; }

        [JsonProperty("O")]
        public string OrderCreationTime { get; set; }
    }
}
