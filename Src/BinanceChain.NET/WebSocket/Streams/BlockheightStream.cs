using BinanceChain.NET.WebSocket.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BinanceChain.NET.WebSocket.Streams
{
    public class BlockheightStream : WebSocketStream
    {
        private const string streamName = "blockheight";

        public delegate void DataReceived(BlockheightData message);
        public event DataReceived OnDataReceived;

        public BlockheightStream(string baseUrl) : base(baseUrl) { }

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
                BlockheightData data = JsonConvert.DeserializeObject<BlockheightData>(payload.Data.ToString());

                OnDataReceived?.Invoke(data);
            }
        }
    }
}
