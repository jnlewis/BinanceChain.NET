using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class OrderList : DomainEntity
    {
        [JsonProperty("order")]
        public List<Order> Orders { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}
