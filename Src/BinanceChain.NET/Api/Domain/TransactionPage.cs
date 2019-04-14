using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class TransactionPage : DomainEntity
    {
        [JsonProperty("total")]
        public long Total;

        [JsonProperty("Transaction")]
        public List<Transaction> Tx;
    }
}
