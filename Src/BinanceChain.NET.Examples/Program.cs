using System;
using System.Collections.Generic;
using BinanceChain.NET.Api;
using Newtonsoft.Json;

namespace BinanceChain.NET.AppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateWalletExample();

            //ApiRequestExample();

            //WebSocketBlockheightExample();

            Console.ReadLine();
        }

        static void CreateWalletExample()
        {
            // Creating new wallet
            Wallet wallet = Wallet.Create("newpass", EnvironmentInfo.TESTNET);

            Console.WriteLine("WalletExample");
            Console.WriteLine(wallet);

            // Save wallet file

            // Opening existing wallet
        }

        static void ApiRequestExample()
        {
            // #Interacting with Binance Chain on HTTP API
            
            BinanceChainApi api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);

            // Getting node info
            var nodeInfo = api.GetNodeInfo();
            Console.WriteLine("ApiRequestExample:GetNodeInfo");
            Console.WriteLine(nodeInfo);

            //// Getting orders
            //var ordersBNBBTC = api.GetOrderBook(new Api.Domain.Requests.OrderBookRequest() { Symbol = "xxx-000_BNB" });
            //Console.WriteLine(ordersBNBBTC);

            // Asynchronous calls
            // All API methods support both Synchronous and Asynchronous calls.
            // Asynchronous calls has a method suffix of "Async".

            // Placing an order
        }

        static void CustomEnvironmentExample()
        {
            // Connecting to different environments
            EnvironmentInfo env = new EnvironmentInfo("Local", "http://localhost/api", "ws://localhost/api", "bnb");
            BinanceChainApi localApi = BinanceApiFactory.CreateApiClient(env);
        }

        static void WebSocketBlockheightExample()
        {
            // Subscribing to blockheight web socket
            var stream = BinanceWebSocketFactory.CreateBlockheightStream(EnvironmentInfo.TESTNET);
            stream.Subscribe();
            stream.OnDataReceived += (WebSocket.Domain.BlockheightData message) =>
            {
                Console.WriteLine("WebSocketBlockheightExample:Receive message");
                Console.WriteLine(JsonConvert.SerializeObject(message));
            };

            // Disconnecting from web socket
            //stream.Disconnect();
        }

        static void WebSocketExample()
        {
            // #Subscribing to Binance Chain Web Socket

            Wallet wallet = Wallet.Create("newpass", EnvironmentInfo.TESTNET);

            // Subscribing to orders web socket
            var ordersStream = BinanceWebSocketFactory.CreateOrdersStream(EnvironmentInfo.TESTNET);
            ordersStream.Subscribe(wallet.Address);
            ordersStream.OnDataReceived += (List<WebSocket.Domain.OrdersData> message) =>
            {
                Console.WriteLine(JsonConvert.SerializeObject(message));
            };

            // Disconnecting from web socket
            ordersStream.Disconnect();
        }

    }
}
