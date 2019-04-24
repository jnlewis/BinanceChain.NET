using System;

namespace BinanceChain.NET.NodeRPC.Domain
{
    public abstract class DomainEntity
    {
        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
