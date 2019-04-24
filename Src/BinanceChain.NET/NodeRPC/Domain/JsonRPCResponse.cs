using Newtonsoft.Json;

namespace BinanceChain.NET.NodeRPC.Domain
{
    public class JsonRPCResponse<T> : DomainEntity
    {
        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("error")]
        public JsonRPCResponseError Error { get; set; }
    }

    public class JsonRPCResponseError
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
