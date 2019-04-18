using System;
using System.Collections.Generic;
using BinanceChain.NET.Api;
using Newtonsoft.Json;

namespace BinanceChain.NET.AppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
        
        static void CustomEnvironmentExample()
        {
            // Connecting to different environments
            EnvironmentInfo env = new EnvironmentInfo("Local", "http://localhost/api", "ws://localhost/api", "cbnb");
            IBinanceChainApiClient localApi = BinanceApiFactory.CreateApiClient(env);
        }
    }
}
