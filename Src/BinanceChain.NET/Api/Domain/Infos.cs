using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Infos : DomainEntity
    {
        [JsonProperty("node_info")]
        public NodeInfo NodeInfo { get; set; }

        [JsonProperty("sync_info")]
        public SyncInfo SyncInfo { get; set; }

        [JsonProperty("validator_info")]
        public ValidatorInfo ValidatorInfo { get; set; }
    }
}
