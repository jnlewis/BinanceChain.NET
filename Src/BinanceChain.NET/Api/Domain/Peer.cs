using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Peer : DomainEntity
    {
        [JsonProperty("accelerated")]
        public string Accelerated { get; set; }

        [JsonProperty("access_addr")]
        public string AccessAddress { get; set; }

        [JsonProperty("capabilities")]
        public List<string> Capabilities { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("listen_addr")]
        public string ListenAddress { get; set; }

        [JsonProperty("moniker")]
        public string Moniker { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("stream_addr")]
        public string StreamAddress { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
