using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class TransactionMetadata : DomainEntity
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("log")]
        public string Log { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("ok")]
        public bool IsOk { get; set; }
    }
}
