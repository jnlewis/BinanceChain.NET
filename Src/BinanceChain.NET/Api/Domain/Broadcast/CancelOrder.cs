using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain.Broadcast
{
    public class CancelOrder : BroadcastEntity
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("refId")]
        public string RefId { get; set; }
    }
}
