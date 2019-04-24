using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.NodeRPC.Domain
{
    public class ABCIInfo : DomainEntity
    {
        [JsonProperty("response")]
        private ABCIResponse Response { get; set; }
    }

    public class ABCIResponse : DomainEntity
    {
        [JsonProperty("data")]
        private string Data { get; set; }

        [JsonProperty("last_block_height")]
        private long LastBlockHeight { get; set; }

        [JsonProperty("last_block_app_hash")]
        private byte[] LastBlockAppHash { get; set; }
    }
}
