using Newtonsoft.Json;
using System;
using WebSocketSharp;

namespace BinanceChain.NET.WebSocket.Streams
{
    public abstract class WebSocketStream
    {
        protected delegate void MessageReceived(MessageReceivedEventArgs message);
        protected event MessageReceived OnMessageReceived;

        private readonly string socketUrl;
        private WebSocketSharp.WebSocket webSocket;
        
        public bool IsConnected { get; private set; }

        internal WebSocketStream(string socketUrl)
        {
            this.IsConnected = false;
            this.socketUrl = socketUrl;
        }
        
        protected void ConnectAndSend(string message)
        {
            // Disconnect from existing connection if already connected
            Disconnect();

            // Connect to web socket
            this.webSocket = new WebSocketSharp.WebSocket(this.socketUrl);
            this.webSocket.EmitOnPing = true;
            this.webSocket.OnOpen += (object sender, EventArgs e) =>
            {
                this.webSocket.Send(message);
                this.IsConnected = true;
            };
            this.webSocket.OnMessage += WebSocket_OnMessage;
            this.webSocket.Connect();
        }
        
        private void WebSocket_OnMessage(object sender, MessageEventArgs e)
        {
            OnMessageReceived?.Invoke(
                new MessageReceivedEventArgs(
                    e.Data, 
                    e.RawData, 
                    e.IsBinary, 
                    e.IsText, 
                    e.IsPing));
        }
        
        public virtual void Disconnect()
        {
            if (this.webSocket != null)
            {
                this.webSocket.Close();
            }

            this.IsConnected = false;
        }

        protected string ToJson(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }

    public class MessageReceivedEventArgs
    {
        public string Data { get; private set; }
        public byte[] RawData { get; private set; }
        public bool IsBinary { get; private set; }
        public bool IsText { get; private set; }
        public bool IsPing { get; private set; }

        public MessageReceivedEventArgs(string data, byte[] rawData, bool isBinary, bool isText, bool isPing)
        {
            this.Data = data;
            this.RawData = rawData;
            this.IsBinary = isBinary;
            this.IsText = isText;
            this.IsPing = isPing;
        }
    }

}
