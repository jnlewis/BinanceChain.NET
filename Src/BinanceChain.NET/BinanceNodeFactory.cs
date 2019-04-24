using BinanceChain.NET.Api;
using BinanceChain.NET.Utility.Network;
using System;

namespace BinanceChain.NET
{
    public static class BinanceNodeFactory
    {
        public static IBinanceChainNodeClient CreateNodeClient(EnvironmentInfo environment)
        {
            IHttpClient httpClient = new JsonHttpClient();

            return new BinanceChainNodeClient(environment.ApiBaseUrl, httpClient);
        }
    }
}
