using System;

namespace BinanceChain.NET.Api.Domain
{
    public abstract class BroadcastEntity
    {
        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
