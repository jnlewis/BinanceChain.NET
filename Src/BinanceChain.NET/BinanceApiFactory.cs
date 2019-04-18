using BinanceChain.NET.Api;
using BinanceChain.NET.Utility.Network;
using System;

namespace BinanceChain.NET
{
    public static class BinanceApiFactory
    {
        public static IBinanceChainApiClient CreateApiClient(EnvironmentInfo environment)
        {
            IHttpClient httpClient = new DefaultHttpClient();

            return new BinanceChainApiClient(environment.ApiBaseUrl, httpClient);
        }
    }
}
