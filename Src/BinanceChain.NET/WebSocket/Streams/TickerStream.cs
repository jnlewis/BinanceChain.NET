using BinanceChain.NET.WebSocket.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BinanceChain.NET.WebSocket.Streams
{
    public class TickerStream : WebSocketStream
    {
        private const string streamName = "ticker";

        public delegate void DataReceived(TickerData message);
        public event DataReceived OnDataReceived;
        
        public TickerStream(string baseUrl) : base(baseUrl) { }

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
                TickerData data = JsonConvert.DeserializeObject<TickerData>(payload.Data.ToString());

                OnDataReceived?.Invoke(data);
            }
        }
    }
}
