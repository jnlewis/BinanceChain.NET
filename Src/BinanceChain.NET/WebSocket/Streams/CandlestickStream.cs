using BinanceChain.NET.WebSocket.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BinanceChain.NET.WebSocket.Streams
{
    public class CandlestickStream : WebSocketStream
    {
        private const string streamName = "kline";

        public delegate void DataReceived(List<TradesData> message);
        public event DataReceived OnDataReceived;

        public CandlestickStream(string baseUrl) : base(baseUrl) { }

        public void Subscribe(List<string> symbols, string interval)
        {
            var message = new {
                method = "subscribe",
                topic = streamName + "_" + interval,
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
                List<TradesData> data = JsonConvert.DeserializeObject<List<TradesData>>(payload.Data.ToString());

                OnDataReceived?.Invoke(data);
            }
        }

        public static class KlineIntervals
        {
            public static string OneMinute { get { return "1m"; } }
            public static string ThreeMinute { get { return "3m"; } }
            public static string FiveMinute { get { return "5m"; } }
            public static string FifteenMinute { get { return "15m"; } }
            public static string ThirtyMinute { get { return "30m"; } }
            public static string OneHour { get { return "1h"; } }
            public static string TwoHour { get { return "2h"; } }
            public static string FourHour { get { return "4h"; } }
            public static string SixHour { get { return "6h"; } }
            public static string EightHour { get { return "8h"; } }
            public static string TwelveHour { get { return "12h"; } }
            public static string OneDay { get { return "1d"; } }
            public static string ThreeDays { get { return "3d"; } }
            public static string OneWeek { get { return "1w"; } }
            public static string OneMonth { get { return "1M"; } }
        }
    }
}
