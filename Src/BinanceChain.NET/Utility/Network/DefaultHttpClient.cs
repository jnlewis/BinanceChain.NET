using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BinanceChain.NET.Utility.Network
{
    internal class DefaultHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public DefaultHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string requestUrl)
        {
            return await GetAsync<T>(new Uri(requestUrl));
        }

        public async Task<T> GetAsync<T>(Uri requestUrl)
        {
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(data);
        }

        public async Task<T> PostAsync<T>(string requestUrl, object content)
        {
            return await PostAsync<T>(new Uri(requestUrl), content);
        }

        public async Task<T> PostAsync<T>(Uri requestUrl, object content)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync(requestUrl, stringContent);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(data);
        }

        public async Task<T> PostAsync<T>(string requestUrl, object content, Encoding encoding, string mediaType)
        {
            return await PostAsync<T>(new Uri(requestUrl), content, encoding, mediaType);
        }

        public async Task<T> PostAsync<T>(Uri requestUrl, object content, Encoding encoding, string mediaType)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(content), encoding, mediaType);

            var response = await _httpClient.PostAsync(requestUrl, stringContent);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
