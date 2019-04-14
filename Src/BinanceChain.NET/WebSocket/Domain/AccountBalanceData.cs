using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    public class AccountBalanceData
    {
        [JsonProperty("a")]
        public string Asset { get; set; }

        [JsonProperty("f")]
        public string FreeAmount { get; set; }

        [JsonProperty("l")]
        public string LockedAmount { get; set; }

        [JsonProperty("r")]
        public string FrozenAmount { get; set; }
    }
}
