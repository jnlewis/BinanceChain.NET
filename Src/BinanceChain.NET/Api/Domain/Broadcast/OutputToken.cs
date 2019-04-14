using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain.Broadcast
{
    public class OutputToken : BroadcastEntity
    {
        public string Coin { get; set; }
        public string Amount { get; set; }
    }
}
