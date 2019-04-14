using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class NodeInfo : DomainEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("listen_addr")]
        public string ListenAddr { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("channels")]
        public string Channels { get; set; }

        [JsonProperty("moniker")]
        public string Moniker { get; set; }

        [JsonProperty("other")]
        public Dictionary<string, object> Other { get; set; }
    }
}
