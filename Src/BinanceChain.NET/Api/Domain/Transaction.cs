using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Transaction : DomainEntity
    {
        [JsonProperty("blockHeight")]
        public long BlockHeight { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("confirmBlocks")]
        public long ConfirmBlocks { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("fromAddr")]
        public string FromAddr { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("toAddr")]
        public string ToAddr { get; set; }

        [JsonProperty("txAge")]
        public long TxAge { get; set; }
        
        [JsonProperty("txAsset")]
        public string TxAsset { get; set; }

        [JsonProperty("txFee")]
        public string TxFee { get; set; }

        [JsonProperty("txHash")]
        public string TxHash { get; set; }

        [JsonProperty("txType")]
        public string TxType { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
