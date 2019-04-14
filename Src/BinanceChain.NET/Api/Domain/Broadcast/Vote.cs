using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain.Broadcast
{
    public class Vote : BroadcastEntity
    {
        public long ProposalId { get; set; }
        public int Option { get; set; }
    }
}
