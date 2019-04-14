using System;
using System.Threading.Tasks;

namespace BinanceChain.NET.Utility.Network
{
    public interface IHttpClient
    {
        Task<T> GetAsync<T>(string uri);
        Task<T> GetAsync<T>(Uri uri);
        Task<T> PostAsync<T>(string requestUrl, object content);
        Task<T> PostAsync<T>(Uri requestUrl, object content);
    }
}
