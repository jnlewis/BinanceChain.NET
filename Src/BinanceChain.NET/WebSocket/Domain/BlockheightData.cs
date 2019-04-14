using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.WebSocket.Domain
{
    /*
     {
      "stream": "blockheight",
      "data": {
        "h": 123456789,     // Block height
      }
    }
    */

    public class BlockheightData
    {
        [JsonProperty("h")]
        public string BlockHeight { get; set; }
    }
}
