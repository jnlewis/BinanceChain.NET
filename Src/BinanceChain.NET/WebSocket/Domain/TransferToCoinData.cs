using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    public class TransferToCoinData
    {
        [JsonProperty("a")]
        public string Asset { get; set; }

        [JsonProperty("A")]
        public string Amount { get; set; }
    }
}
