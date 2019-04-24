using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.NodeRPC.Domain
{
    public class Peer : DomainEntity
    {
        [JsonProperty("node_info")]
        public NodeInfo NodeInfo { get; set; }

        [JsonProperty("is_outbound")]
        public bool IsOutbound { get; set; }

        //[JsonProperty("connection_status")]
        //public ConnectionStatus ConnectionStatus { get; set; }

        [JsonProperty("remote_ip")]
        public string RemoteIP { get; set; }
    }
}
