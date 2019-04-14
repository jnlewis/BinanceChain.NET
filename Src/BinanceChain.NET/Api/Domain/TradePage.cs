using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class TradePage : DomainEntity
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("trade")]
        public List<Trade> Trade { get; set; }
    }
}
