using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class AccountSequence : DomainEntity
    {
        [JsonProperty("sequence")]
        public long Sequence { get; set; }
    }
}
