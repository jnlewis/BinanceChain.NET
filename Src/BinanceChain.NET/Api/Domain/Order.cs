using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Order : DomainEntity
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("cumulateQuantity")]
        public string CumulateQuantity { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("orderCreateTime")]
        public DateTime OrderCreateTime { get; set; }

        [JsonProperty("transactionTime")]
        public DateTime TransactionTime { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timeInForce")]
        public int TimeInForce { get; set; }

        [JsonProperty("side")]
        public int Side { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("tradeId")]
        public string TradeId { get; set; }

        [JsonProperty("lastExecutedPrice")]
        public string LastExecutedPrice { get; set; }

        [JsonProperty("lastExecutedQuantity")]
        public string LastExecutedQuantity { get; set; }

        [JsonProperty("transactionHash")]
        public string TransactionHash { get; set; }
    }
}
