using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.NodeRPC.Domain
{
    public class SyncInfo : DomainEntity
    {
        [JsonProperty("latest_block_hash")]
        private string LatestBlockHash { get; set; }

        [JsonProperty("latest_app_hash")]
        private string LatestAppHash { get; set; }

        [JsonProperty("latest_block_height")]
        private long LatestBlockHeight { get; set; }

        [JsonProperty("latest_block_time")]
        private DateTime LatestBlockTime { get; set; }

        [JsonProperty("catching_up")]
        private bool CatchingUp { get; set; }
    }
}
