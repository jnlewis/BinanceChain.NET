using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class TickerStatistics : DomainEntity
    {
        [JsonProperty("accountNumber")]
        public int AccountNumber { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("balances")]
        public List<Balance> Balances { get; set; }

        [JsonProperty("public_key")]
        public List<int> PublicKey { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }
    }
}
