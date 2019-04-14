using BinanceChain.NET.WebSocket.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BinanceChain.NET.WebSocket.Streams
{
    public class AllSymbolsTickerStream : WebSocketStream
    {
        private const string streamName = "allTickers";

        public delegate void DataReceived(List<TickerData> message);
        public event DataReceived OnDataReceived;

        public AllSymbolsTickerStream(string baseUrl) : base(baseUrl) { }

        public void Subscribe()
        {
            var message = new {
                method = "subscribe",
                topic = streamName,
                symbols = new List<string>() { "$all" }
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
                List<TickerData> data = JsonConvert.DeserializeObject<List<TickerData>>(payload.Data.ToString());

                OnDataReceived?.Invoke(data);
            }
        }
    }
}
