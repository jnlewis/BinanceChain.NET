using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class RequestBody : DomainEntity
    {
        public byte[] Data { get; set; }
    }
}
