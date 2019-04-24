using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.NodeRPC.Domain
{
    public class ConsensusState : DomainEntity
    {
        [JsonProperty("round_state")]
        public string RoundState { get; set; }
    }
}
