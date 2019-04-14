using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Balance : DomainEntity
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("free")]
        public string Free { get; set; }

        [JsonProperty("locked")]
        public string Locked { get; set; }

        [JsonProperty("frozen")]
        public string Frozen { get; set; }
    }
}
