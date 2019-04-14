using BinanceChain.NET.WebSocket.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BinanceChain.NET.WebSocket.Streams
{
    public class TransferStream : WebSocketStream
    {
        private const string streamName = "transfers";

        public delegate void DataReceived(TransferData message);
        public event DataReceived OnDataReceived;

        public TransferStream(string baseUrl) : base(baseUrl) { }

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
                TransferData data = JsonConvert.DeserializeObject<TransferData>(payload.Data.ToString());

                OnDataReceived?.Invoke(data);
            }
        }
    }
}
