using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Time : DomainEntity
    {
        [JsonProperty("ap_time")]
        public string ApTime { get; set; }

        [JsonProperty("block_time")]
        public string BlockTime { get; set; }
    }
}
