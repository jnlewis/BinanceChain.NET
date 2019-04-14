using BinanceChain.NET.WebSocket.Streams;
using System;

namespace BinanceChain.NET
{
    public static class BinanceWebSocketFactory
    {
        public static OrdersStream CreateOrdersStream(EnvironmentInfo environment) => new OrdersStream(environment.WebSockerBaseUrl);

        public static AccountStream CreateAccountStream(EnvironmentInfo environment) => new AccountStream(environment.WebSockerBaseUrl);

        public static TransferStream CreateTransferStream(EnvironmentInfo environment) => new TransferStream(environment.WebSockerBaseUrl);

        public static TradesStream CreateTradesStream(EnvironmentInfo environment) => new TradesStream(environment.WebSockerBaseUrl);

        public static DiffDepthStream CreateDiffDepthStream(EnvironmentInfo environment) => new DiffDepthStream(environment.WebSockerBaseUrl);

        public static BookDepthStream CreateBookDepthStream(EnvironmentInfo environment) => new BookDepthStream(environment.WebSockerBaseUrl);

        public static CandlestickStream CreateCandlestickStream(EnvironmentInfo environment) => new CandlestickStream(environment.WebSockerBaseUrl);

        public static TickerStream CreateTickerStream(EnvironmentInfo environment) => new TickerStream(environment.WebSockerBaseUrl);

        public static AllSymbolsTickerStream CreateAllSymbolsTickerStream(EnvironmentInfo environment) => new AllSymbolsTickerStream(environment.WebSockerBaseUrl);

        public static MiniTickerStream CreateMiniTickerStream(EnvironmentInfo environment) => new MiniTickerStream(environment.WebSockerBaseUrl);

        public static AllSymbolsMiniTickerStream CreateAllSymbolsMiniTickerStream(EnvironmentInfo environment) => new AllSymbolsMiniTickerStream(environment.WebSockerBaseUrl);

        public static BlockheightStream CreateBlockheightStream(EnvironmentInfo environment) => new BlockheightStream(environment.WebSockerBaseUrl);
    }
}
