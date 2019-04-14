using BinanceChain.NET.WebSocket.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BinanceChain.NET.WebSocket.Streams
{
    public class BookDepthStream : WebSocketStream
    {
        private const string streamName = "marketDepth";

        public delegate void DataReceived(MarketDepthData message);
        public event DataReceived OnDataReceived;
        
        public BookDepthStream(string baseUrl) : base(baseUrl) { }

        public void Subscribe(List<string> symbols)
        {
            var message = new {
                method = "subscribe",
                topic = streamName,
                symbols = symbols
            };

            base.OnMessageReceived += Stream_OnMessageReceived;
            base.ConnectAndSend(ToJson(message));
        }
        
        private void Stream_OnMessageReceived(MessageReceivedEventArgs message)
        {
            StreamPayload payload = JsonConvert.DeserializeObject<StreamPayload>(message.Data);
            if(payload != null && 
                payload.Data != null && 
                payload.Stream == streamName)
            {
                MarketDepthData data = JsonConvert.DeserializeObject<MarketDepthData>(payload.Data.ToString());

                OnDataReceived?.Invoke(data);
            }
        }
    }
}
