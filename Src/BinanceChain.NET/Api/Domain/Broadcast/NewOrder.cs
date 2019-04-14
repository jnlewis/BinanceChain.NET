using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain.Broadcast
{
    public class NewOrder : BroadcastEntity
    {
        public string Symbol { get; set; }
        public int OrderType { get; set; }
        public int Side { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public int TimeInForce { get; set; }
    }
}
