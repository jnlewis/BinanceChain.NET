using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class FixedFeeParams : DomainEntity
    {
        [JsonProperty("msg_type")]
        public string MsgType { get; set; }

        [JsonProperty("fee")]
        public long Fee { get; set; }

        [JsonProperty("fee_for")]
        public int FeeFor { get; set; }
    }
}
