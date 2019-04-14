using BinanceChain.NET.WebSocket.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BinanceChain.NET.WebSocket.Streams
{
    public class TradesStream : WebSocketStream
    {
        private const string streamName = "trades";

        public delegate void DataReceived(List<TradesData> message);
        public event DataReceived OnDataReceived;

        public TradesStream(string baseUrl) : base(baseUrl) { }

        public void Subscribe(string userAddress)
        {
            var message = new {
                method = "subscribe",
                topic = streamName,
                userAddress = userAddress
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
                List<TradesData> data = JsonConvert.DeserializeObject<List<TradesData>>(payload.Data.ToString());

                OnDataReceived?.Invoke(data);
            }
        }
    }
}
