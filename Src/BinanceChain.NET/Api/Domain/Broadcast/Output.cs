using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain.Broadcast
{
    public class Output : BroadcastEntity
    {
        public Output()
        {
            Tokens = new List<OutputToken>();
        }

        public string Address { get; set; }
        public List<OutputToken> Tokens { get; private set; }
    }
}
