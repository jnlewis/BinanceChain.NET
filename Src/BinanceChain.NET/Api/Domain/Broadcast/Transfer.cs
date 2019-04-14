using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain.Broadcast
{
    public class Transfer : BroadcastEntity
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Coin { get; set; }
        public string Amount { get; set; }
    }
}
