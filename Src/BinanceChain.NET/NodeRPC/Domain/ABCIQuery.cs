using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.NodeRPC.Domain
{
    public class ABCIQuery : DomainEntity
    {
        [JsonProperty("response")]
        private ABCIResponse Response { get; set; }
    }

    public class ABCIQueryResponse : DomainEntity
    {
        [JsonProperty("code")]
        private uint Code { get; set; }

        [JsonProperty("log")]
        private string Log { get; set; }

        [JsonProperty("info")]
        private string Info { get; set; }

        [JsonProperty("index")]
        private long Index { get; set; }

        [JsonProperty("key")]
        private byte[] Key { get; set; }

        [JsonProperty("value")]
        private byte[] Value { get; set; }

        [JsonProperty("height")]
        private long Height { get; set; }

        [JsonProperty("codespace")]
        private string Codespace { get; set; }
    }
}
