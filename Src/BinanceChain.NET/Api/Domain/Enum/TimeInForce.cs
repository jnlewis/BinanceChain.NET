using System;

namespace BinanceChain.NET.Api.Domain
{
    public static class TimeInForce
    {
        public static int GoodTillExpire { get { return 1; } }
        public static int ImmediateOrCancel { get { return 3; } }
    }
}
