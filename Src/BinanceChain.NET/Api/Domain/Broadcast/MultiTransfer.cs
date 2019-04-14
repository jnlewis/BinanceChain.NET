using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain.Broadcast
{
    public class MultiTransfer : BroadcastEntity
    {
        public MultiTransfer()
        {
            Outputs = new List<Output>();
        }

        [JsonProperty("fromAddress")]
        public string FromAddress { get; set; }

        [JsonProperty("outputs")]
        public List<Output> Outputs { get; private set; }
    }
}
