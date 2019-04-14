using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Trade : DomainEntity
    {
        [JsonProperty("baseAsset")]
        public string BaseAsset;

        [JsonProperty("blockHeight")]
        public long BlockHeight;

        [JsonProperty("buyFee")]
        public string BuyFee;

        [JsonProperty("buyerId")]
        public string BuyerId;

        [JsonProperty("buyerOrderId")]
        public string BuyerOrderId;

        [JsonProperty("price")]
        public string Price;

        [JsonProperty("quantity")]
        public string Quantity;

        [JsonProperty("quoteAsset")]
        public string QuoteAsset;

        [JsonProperty("sellFee")]
        public string SellFee;

        [JsonProperty("sellerId")]
        public string SellerId;

        [JsonProperty("sellerOrderId")]
        public string SellerOrderId;

        [JsonProperty("symbol")]
        public string Symbol;

        [JsonProperty("time")]
        public long Time;

        [JsonProperty("tradeId")]
        public string TradeId;
    }
}
