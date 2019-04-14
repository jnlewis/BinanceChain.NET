using BinanceChain.NET.Api.Domain.TransactionMessages.Proto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain.TransactionMessages
{
    internal class SignData
    {
        [JsonProperty("chain_id")]
        public string ChainId { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("sequence")]
        public string Sequence { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("msgs")]
        public List<ProtoMessage> Msgs { get; set; }

        [JsonProperty("source")]
        public long Source { get; set; }

        [JsonProperty("data")]
        public byte[] Data { get; set; }
    }
}
