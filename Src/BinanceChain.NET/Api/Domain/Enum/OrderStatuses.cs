using System;

namespace BinanceChain.NET.Api.Domain
{
    public enum OrderStatuses
    {
        Ack,
        PartialFill,
        IocNoFill,
        FullyFill,
        Canceled,
        Expired,
        FailedBlocking,
        FailedMatching
    }
}
