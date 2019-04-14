using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    public class StreamPayload
    {
        [JsonProperty("stream")]
        public string Stream { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}
