using BinanceChain.NET.Utility.Network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BinanceChain.NET.Tests.Mocks
{
    public class MockHttpClient : IHttpClient
    {
        //TODO: implement mocked responses

        public async Task<T> GetAsync<T>(string requestUrl)
        {
            return JsonConvert.DeserializeObject<T>(null);
        }

        public async Task<T> GetAsync<T>(Uri requestUrl)
        {
            return JsonConvert.DeserializeObject<T>(null);
        }

        public async Task<T> PostAsync<T>(string requestUrl, object content)
        {
            return JsonConvert.DeserializeObject<T>(null);
        }

        public async Task<T> PostAsync<T>(Uri requestUrl, object content)
        {
            return JsonConvert.DeserializeObject<T>(null);
        }
    }
}
