using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain.Broadcast
{
    public class TokenUnfreeze : BroadcastEntity
    {
        public string Symbol { get; set; }
        public string Amount { get; set; }
    }
}
