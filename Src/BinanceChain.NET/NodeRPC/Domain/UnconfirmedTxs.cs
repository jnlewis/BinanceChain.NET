using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.NodeRPC.Domain
{
    public class UnconfirmedTxs : DomainEntity
    {
        [JsonProperty("n_txs")]
        public int TxsCount { get; set; }

        [JsonProperty("txs")]
        public List<string> Txs { get; set; }
    }
}
