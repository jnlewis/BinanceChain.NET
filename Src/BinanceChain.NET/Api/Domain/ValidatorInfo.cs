using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class ValidatorInfo : DomainEntity
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("pubKey")]
        public List<int> PubKey { get; set; }

        [JsonProperty("voting_power")]
        public long VotingPower { get; set; }
    }
}
