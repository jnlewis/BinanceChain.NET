using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain.Broadcast
{
    public class TransactionOption : BroadcastEntity
    {
        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("source")]
        public long Source { get; set; }

        [JsonProperty("data")]
        public byte[] Data { get; set; }
    }
}
