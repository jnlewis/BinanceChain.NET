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

        public void Subscribe(List<string> symbols, KlineIntervals interval)
        {
            var message = new {
                method = "subscribe",
                topic = streamName + "_" + GetKlineShortInterval(interval),
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

        private string GetKlineShortInterval(KlineIntervals interval)
        {
            return "1m";
        }

        public enum KlineIntervals
        {
            OneMinute,
            ThreeMinute,
            FiveMinute,
            FifteenMinute,
            ThirtyMinute,
            OneHour,
            TwoHour,
            FourHour,
            SixHour,
            EightHour,
            TwelveHour,
            OneDay,
            ThreeDays,
            OneWeek,
            OneMonth
        }
    }
}
