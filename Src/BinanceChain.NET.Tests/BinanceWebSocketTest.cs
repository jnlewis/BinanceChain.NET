using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BinanceChain.NET.Tests
{
    [TestClass]
    public class BinanceWebSocketTest
    {
        [TestMethod]
        public void OrdersStream_Test()
        {
            string address = "tbnb1ypgjxvscw2cezmd6slguyjk95yrnuahp4c4kd7";

            var stream = BinanceWebSocketFactory.CreateOrdersStream(EnvironmentInfo.TESTNET);
            stream.Subscribe(address);
            stream.OnDataReceived += (List<WebSocket.Domain.OrdersData> message) =>
            {
                stream.Disconnect();
                Assert.IsTrue(true);
            };
        }

        [TestMethod]
        public void AccountStream_Test()
        {
            string address = "tbnb1ypgjxvscw2cezmd6slguyjk95yrnuahp4c4kd7";

            var stream = BinanceWebSocketFactory.CreateAccountStream(EnvironmentInfo.TESTNET);
            stream.Subscribe(address);
            stream.OnDataReceived += (List<WebSocket.Domain.AccountData> message) =>
            {
                stream.Disconnect();
                Assert.IsTrue(true);
            };
        }

        [TestMethod]
        public void TransferStream_Test()
        {
            string address = "tbnb1ypgjxvscw2cezmd6slguyjk95yrnuahp4c4kd7";

            var stream = BinanceWebSocketFactory.CreateTransferStream(EnvironmentInfo.TESTNET);
            stream.Subscribe(address);
            stream.OnDataReceived += (WebSocket.Domain.TransferData message) =>
            {
                stream.Disconnect();
                Assert.IsTrue(true);
            };
        }

        [TestMethod]
        public void TradesStream_Test()
        {
            string address = "tbnb1ypgjxvscw2cezmd6slguyjk95yrnuahp4c4kd7";

            var stream = BinanceWebSocketFactory.CreateTradesStream(EnvironmentInfo.TESTNET);
            stream.Subscribe(address);
            stream.OnDataReceived += (List<WebSocket.Domain.TradesData> message) =>
            {
                stream.Disconnect();
                Assert.IsTrue(true);
            };
        }

        [TestMethod]
        public void DiffDepthStream_Test()
        {
            List<string> symbols = new List<string>();
            symbols.Add("BNB_BTC");

            var stream = BinanceWebSocketFactory.CreateDiffDepthStream(EnvironmentInfo.TESTNET);
            stream.Subscribe(symbols);
            stream.OnDataReceived += (WebSocket.Domain.MarketDiffData message) =>
            {
                stream.Disconnect();
                Assert.IsTrue(true);
            };
        }
        
        [TestMethod]
        public void BookDepthStream_Test()
        {
            List<string> symbols = new List<string>();
            symbols.Add("BNB_BTC");

            var stream = BinanceWebSocketFactory.CreateBookDepthStream(EnvironmentInfo.TESTNET);
            stream.Subscribe(symbols);
            stream.OnDataReceived += (WebSocket.Domain.MarketDepthData message) =>
            {
                stream.Disconnect();
                Assert.IsTrue(true);
            };
        }

        [TestMethod]
        public void CandlestickStream_Test()
        {
            List<string> symbols = new List<string>();
            symbols.Add("BNB_BTC");

            var stream = BinanceWebSocketFactory.CreateCandlestickStream(EnvironmentInfo.TESTNET);
            stream.Subscribe(symbols, WebSocket.Streams.CandlestickStream.KlineIntervals.FiveMinute);
            stream.OnDataReceived += (List<WebSocket.Domain.TradesData> message) =>
            {
                stream.Disconnect();
                Assert.IsTrue(true);
            };
        }

        [TestMethod]
        public void TickerStream_Test()
        {
            List<string> symbols = new List<string>();
            symbols.Add("BNB_BTC");

            var stream = BinanceWebSocketFactory.CreateTickerStream(EnvironmentInfo.TESTNET);
            stream.Subscribe(symbols);
            stream.OnDataReceived += (WebSocket.Domain.TickerData message) =>
            {
                stream.Disconnect();
                Assert.IsTrue(true);
            };
        }

        [TestMethod]
        public void AllSymbolsTickerStream_Test()
        {
            var stream = BinanceWebSocketFactory.CreateAllSymbolsTickerStream(EnvironmentInfo.TESTNET);
            stream.Subscribe();
            stream.OnDataReceived += (List<WebSocket.Domain.TickerData> message) =>
            {
                stream.Disconnect();
                Assert.IsTrue(true);
            };
        }

        [TestMethod]
        public void MiniTickerStream_Test()
        {
            List<string> symbols = new List<string>();
            symbols.Add("BNB_BTC");

            var stream = BinanceWebSocketFactory.CreateMiniTickerStream(EnvironmentInfo.TESTNET);
            stream.Subscribe(symbols);
            stream.OnDataReceived += (WebSocket.Domain.MiniTickerData message) =>
            {
                stream.Disconnect();
                Assert.IsTrue(true);
            };
        }

        [TestMethod]
        public void AllSymbolsMiniTickerStream_Test()
        {
            var stream = BinanceWebSocketFactory.CreateAllSymbolsMiniTickerStream(EnvironmentInfo.TESTNET);
            stream.Subscribe();
            stream.OnDataReceived += (List<WebSocket.Domain.MiniTickerData> message) =>
            {
                stream.Disconnect();
                Assert.IsTrue(true);
            };
        }
    }
}
