using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class DexFeeField : DomainEntity
    {
        [JsonProperty("fee_name")]
        public string FeeName { get; set; }

        [JsonProperty("fee_value")]
        public long FeeValue { get; set; }
    }
}
