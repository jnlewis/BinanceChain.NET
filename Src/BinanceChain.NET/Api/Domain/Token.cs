using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Token : DomainEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("original_symbol")]
        public string OriginalSymbol { get; set; }

        [JsonProperty("total_supply")]
        public string TotalSupply { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("mintable")]
        public string Mintable { get; set; }
    }
}
