using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Validator : DomainEntity
    {
        [JsonProperty("block_height")]
        public long BlockHeight { get; set; }

        [JsonProperty("validators")]
        public List<ValidatorInfo> Validators { get; set; }
    }
}
