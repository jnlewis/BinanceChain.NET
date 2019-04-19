# BinanceChain .NET/C# SDK Documentation

## Contents
* [Getting Started](#getting-started)
* [Configuring Environment](#configuring-environment)
* [HTTP API Requests](#http-api-requests)
    * [NodeInfo](#node-info)
    * [Validators](#validators)
    * [Peers](#peers)
    * [Fees](#fees)
    * [Account](#account)
    * [AccountSequence](#account-sequence)
    * [TransactionMetadata](#transaction-metadata)
    * [Tokens](#tokens)
    * [Markets](#markets)
    * [OrderBook](#order-book)
    * [CandlestickBars](#candlestick-bars)
    * [OpenOrders](#open-orders)
    * [ClosedOrders](#closed-orders)
    * [Order](#order)
    * [24HrPriceStatistics](#24hr-price-statistics)
    * [Trades](#trades)
    * [Transactions](#transactions)
* [Web Sockets Streams](#web-socket-streams)
    * [OrdersStream](#ordersstream)
    * [AccountStream](#accountstream)
    * [TransferStream](#transferstream)
    * [TradesStream](#tradesstream)
    * [DiffDepthStream](#diffdepthstream)
    * [BookDepthStream](#bookdepthstream)
    * [CandlestickStream](#candlestickstream)
    * [TickerStream](#ticketstream)
    * [AllSymbolsTickerStream](#allsymbolstickerstream)
    * [MiniTickerStream](#minitickerstream)
    * [AllSymbolsMiniTickerStream](#all-symbols-mini-ticker-stream)
* [Wallet Management](#wallet)
    * [Creating a New Wallet](#creating-a-new-wallet)
    * [Opening a Wallet](#opening-a-wallet)
* [Transaction Broadcast](#transaction-broadcast)
    * [NewOrder](#neworder)
    * [Vote](#vote)
    * [CancelOrder](#cancelorder)
    * [Transfer](#transfer)
    * [Freeze](#freeze)
    * [Unfreeze](#unfreeze)
    
## Getting Started
BinanceChain .NET is available on NuGet. To install, go to Visual Studio > Tools > NuGet Package Manager > Package Manager Console.
```
PM> Install-Package BinanceChain.NET
```

## Configuring Environment

Binance Chain .NET includes two build in environments by default - TestNet and MainNet. If you would like to configure your own environment, you can do so as follow.

```c#
// MainNet
EnvironmentInfo mainnetEnv = EnvironmentInfo.PROD;
var mainnetAPI = BinanceApiFactory.CreateApiClient(mainnetEnv);
```
```c#
// TestNet
EnvironmentInfo testnetEnv = EnvironmentInfo.TESTNET;
var testnetAPI = BinanceApiFactory.CreateApiClient(testnetEnv);
```
```c#
// Custom
EnvironmentInfo customEnv = new EnvironmentInfo("Local", "http://localhost/api", "ws://localhost/api", "cbnb");
var customAPI = BinanceApiFactory.CreateApiClient(customEnv);
```

## HTTP API Requests
To interact with the Binance Chain HTTP API, include the BinanceChain .NET API namespaces in your class.
```c#
using BinanceChain.NET.Api;
using BinanceChain.NET.Api.Domain.Requests;
```
Official HTTP Api documentation: https://docs.binance.org/api-reference/dex-api/paths.html

#### NodeInfo
```c#
var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetNodeInfo();
```

#### Validators
```c#
var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetValidators();
```

#### Peers
```c#
var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetPeers();
```

#### Fees
```c#
var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetFees();
```

#### Account
```c#
string address = "{address}";
var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetAccount(address);
```

#### Account Sequence
```c#
string address = "{address}";
var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetAccountSequence(address);
```

#### Transaction Metadata
```c#
string hash = "E81BAB8E555819E4211D62E2E536B6D5812D3D91C105F998F5C6EB3AB8136482";
var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetTransactionMetadata(hash);
```

#### Tokens
```c#
var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetNodeInfo();
```

#### Markets
```c#
MarketRequest request = new MarketRequest()
{
    Limit = null,
    Offset = null
};

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetMarkets(request);
```

#### Order Book
```c#
OrderBookRequest request = new OrderBookRequest()
{
    Symbol = "NNB-0AD_BNB",
    Limit = null
};

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetOrderBook(request);
```

#### Candlestick Bars
```c#
CandlestickBars request = new CandlestickBars()
{
    Symbol = "NNB-338_BNB",
    Interval = Api.Domain.Intervals.FiveMinute,
    Limit = null,
    StartTime = null,
    EndTime = null
};

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetCandlestickBars(request);
```

#### Open Orders
```c#
OpenOrdersRequest request = new OpenOrdersRequest()
{
    Address = "{address}",
    Limit = null,
    Offset = null,
    Symbol = null,
    Total = null
};

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetOpenOrders(request);
```

#### Closed Orders
```c#
ClosedOrdersRequest request = new ClosedOrdersRequest()
{
    Address = "{address}",
    End = null,
    Limit = null,
    Offset = null,
    Side = null,
    Start = null,
    Symbol = null,
    Total = null
};
request.Status.Add(Api.Domain.OrderStatuses.Canceled);

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetClosedOrders(request);
```

#### Order
```c#
var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetOrder("{orderid}");
```

#### 24Hr Price Statistics
```c#
var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.Get24HrPriceStatistics();
```

#### Trades
```c#
var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetTrades();
```

#### Transactions
```c#
TransactionsRequest request = new TransactionsRequest()
{
    Address = "{address}",
    BlockHeight = null,
    EndTime = null,
    Limit = null,
    Offset = null,
    Side = null,
    StartTime = null,
    TxAsset = null,
    TxType = Api.Domain.TransactionTypes.TRANSFER
};

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.GetTransactions(request);
```

## Web Socket Streams

#### OrdersStream
```c#
string address = "{address}";

var stream = BinanceWebSocketFactory.CreateOrdersStream(EnvironmentInfo.TESTNET);
stream.Subscribe(address);
stream.OnDataReceived += (List<WebSocket.Domain.OrdersData> message) =>
{
    Console.WriteLine(message);
};
```

#### AccountStream
```c#
string address = "{address}";

var stream = BinanceWebSocketFactory.CreateAccountStream(EnvironmentInfo.TESTNET);
stream.Subscribe(address);
stream.OnDataReceived += (List<WebSocket.Domain.AccountData> message) =>
{
    Console.WriteLine(message);
};
```

#### TransferStream
```c#
string address = "{address}";

var stream = BinanceWebSocketFactory.CreateTransferStream(EnvironmentInfo.TESTNET);
stream.Subscribe(address);
stream.OnDataReceived += (WebSocket.Domain.TransferData message) =>
{
    Console.WriteLine(message);
};
```

#### TradesStream
```c#
string address = "{address}";

var stream = BinanceWebSocketFactory.CreateTradesStream(EnvironmentInfo.TESTNET);
stream.Subscribe(address);
stream.OnDataReceived += (List<WebSocket.Domain.TradesData> message) =>
{
    Console.WriteLine(message);
};
```

#### DiffDepthStream
```c#
List<string> symbols = new List<string>();
symbols.Add("BNB_BTC");

var stream = BinanceWebSocketFactory.CreateDiffDepthStream(EnvironmentInfo.TESTNET);
stream.Subscribe(symbols);
stream.OnDataReceived += (WebSocket.Domain.MarketDiffData message) =>
{
    Console.WriteLine(message);
};
```

#### BookDepthStream
```c#
List<string> symbols = new List<string>();
symbols.Add("BNB_BTC");

var stream = BinanceWebSocketFactory.CreateBookDepthStream(EnvironmentInfo.TESTNET);
stream.Subscribe(symbols);
stream.OnDataReceived += (WebSocket.Domain.MarketDepthData message) =>
{
    Console.WriteLine(message);
};
```

#### CandlestickStream
```c#
List<string> symbols = new List<string>();
symbols.Add("BNB_BTC");

var stream = BinanceWebSocketFactory.CreateCandlestickStream(EnvironmentInfo.TESTNET);
stream.Subscribe(symbols, WebSocket.Streams.CandlestickStream.KlineIntervals.FiveMinute);
stream.OnDataReceived += (List<WebSocket.Domain.TradesData> message) =>
{
    Console.WriteLine(message);
};
```

#### TickerStream
```c#
List<string> symbols = new List<string>();
symbols.Add("BNB_BTC");

var stream = BinanceWebSocketFactory.CreateTickerStream(EnvironmentInfo.TESTNET);
stream.Subscribe(symbols);
stream.OnDataReceived += (WebSocket.Domain.TickerData message) =>
{
    Console.WriteLine(message);
};
```

#### AllSymbolsTickerStream
```c#
var stream = BinanceWebSocketFactory.CreateAllSymbolsTickerStream(EnvironmentInfo.TESTNET);
stream.Subscribe();
stream.OnDataReceived += (List<WebSocket.Domain.TickerData> message) =>
{
    Console.WriteLine(message);
};
```

#### MiniTickerStream
```c#
List<string> symbols = new List<string>();
symbols.Add("BNB_BTC");

var stream = BinanceWebSocketFactory.CreateMiniTickerStream(EnvironmentInfo.TESTNET);
stream.Subscribe(symbols);
stream.OnDataReceived += (WebSocket.Domain.MiniTickerData message) =>
{
    Console.WriteLine(message);
};
```

#### AllSymbolsMiniTickerStream
```c#
var stream = BinanceWebSocketFactory.CreateAllSymbolsMiniTickerStream(EnvironmentInfo.TESTNET);
stream.Subscribe();
stream.OnDataReceived += (List<WebSocket.Domain.MiniTickerData> message) =>
{
    Console.WriteLine(message);
};
```

## Wallet

#### Creating a New Wallet
```c#
Wallet wallet = Wallet.NewWallet("testpassword", EnvironmentInfo.TESTNET);
```

#### Opening a Wallet
```c#
Wallet wallet = Wallet.Open("{privateKey}", EnvironmentInfo.TESTNET);
```

## Transaction Broadcast

All transactions are signed with your wallet upon broadcast.
To broadcast transactions, include the following namespaces in your class.
```c#
using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
```

#### NewOrder
```c#
Wallet wallet = Wallet.Open("{privateKey}", EnvironmentInfo.TESTNET);

NewOrder newOrder = new NewOrder()
{
    Symbol = "BNB_BTC",
    OrderType = OrderTypes.LimitOrder,
    Side  = OrderSides.Buy,
    Price  = "10",
    Quantity = "1",
    TimeInForce = TimeInForce.GoodTillExpire
};

TransactionOption option = new TransactionOption()
{
    Memo = null,
    Source = 1,
    Data = null
};

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.NewOrder(newOrder, wallet, option);
```

#### Vote
```c#
Wallet wallet = Wallet.Open("{privateKey}", EnvironmentInfo.TESTNET);

Vote vote = new Vote()
{
    ProposalId = 1,
    Option = 1
};

TransactionOption option = new TransactionOption()
{
    Memo = null,
    Source = 1,
    Data = null
};

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.Vote(vote, wallet, option);
```

#### CancelOrder
```c#
Wallet wallet = Wallet.Open("{privateKey}", EnvironmentInfo.TESTNET);

CancelOrder cancelOrder = new CancelOrder()
{
    Symbol = null,
    RefId = null
};

TransactionOption option = new TransactionOption()
{
    Memo = null,
    Source = 1,
    Data = null
};

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.CancelOrder(cancelOrder, wallet, option);
```

#### Transfer
```c#
Wallet wallet = Wallet.Open("{privateKey}", EnvironmentInfo.TESTNET);

Transfer transfer = new Transfer()
{
    FromAddress = null,
    ToAddress = null,
    Coin = null,
    Amount = null
};

TransactionOption option = new TransactionOption()
{
    Memo = null,
    Source = 1,
    Data = null
};

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.Transfer(transfer, wallet, option);
```

#### Freeze
```c#
Wallet wallet = Wallet.Open("{privateKey}", EnvironmentInfo.TESTNET);

TokenFreeze tokenFreeze = new TokenFreeze()
{
    Symbol = null,
    Amount = null
};

TransactionOption option = new TransactionOption()
{
    Memo = null,
    Source = 1,
    Data = null
};

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.Freeze(tokenFreeze, wallet, option);
```

#### Unfreeze
```c#
Wallet wallet = Wallet.Open("{privateKey}", EnvironmentInfo.TESTNET);

TokenUnfreeze tokenUnfreeze = new TokenUnfreeze()
{
    Symbol = null,
    Amount = null
};

TransactionOption option = new TransactionOption()
{
    Memo = null,
    Source = 1,
    Data = null
};

var api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
var result = api.Unfreeze(tokenUnfreeze, wallet, option);
```
