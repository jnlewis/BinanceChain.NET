using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Utility.Network;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.Requests;
using BinanceChain.NET.Api.Domain.TransactionMessages;

namespace BinanceChain.NET.Api
{
    public class BinanceChainApiClient : BinanceChainApiBase, IBinanceChainApiClient
    {
        private readonly string baseUrl;
        private readonly IHttpClient httpClient;

        public BinanceChainApiClient(
            string baseUrl,
            IHttpClient httpClient)
        {
            this.baseUrl = baseUrl ?? throw new ArgumentNullException("environment");
            this.httpClient = httpClient ?? throw new ArgumentNullException("httpClient");
        }


        #region Requests (Async)

        public async Task<Time> GetTimeAsync()
        {
            return await this.httpClient.GetAsync<Time>($"{baseUrl}/api/v1/time");
        }

        public async Task<Infos> GetNodeInfoAsync()
        {
            return await this.httpClient.GetAsync<Infos>($"{baseUrl}/api/v1/node-info");
        }

        public async Task<Validator> GetValidatorsAsync()
        {
            return await this.httpClient.GetAsync<Validator>($"{baseUrl}/api/v1/validators");
        }

        public async Task<List<Peer>> GetPeersAsync()
        {
            return await this.httpClient.GetAsync<List<Peer>>($"{baseUrl}/api/v1/peers");
        }

        public async Task<List<Fees>> GetFeesAsync()
        {
            return await this.httpClient.GetAsync<List<Fees>>($"{baseUrl}/api/v1/fees");
        }

        public async Task<Account> GetAccountAsync(string address)
        {
            return await this.httpClient.GetAsync<Account>($"{baseUrl}/api/v1/account/{Path(address)}");
        }

        public async Task<AccountSequence> GetAccountSequenceAsync(string address)
        {
            return await this.httpClient.GetAsync<AccountSequence>($"{baseUrl}/api/v1/account/{Path(address)}/sequence");
        }

        public async Task<TransactionMetadata> GetTransactionMetadataAsync(string hash)
        {
            return await this.httpClient.GetAsync<TransactionMetadata>($"{baseUrl}/api/v1/tx/{Path(hash)}");
        }

        public async Task<List<Token>> GetTokensAsync(TokenRequest request)
        {
            return await this.httpClient.GetAsync<List<Token>>($"{baseUrl}/api/v1/tokens{Query(request)}");
        }

        public async Task<List<Market>> GetMarketsAsync(MarketRequest request)
        {
            return await this.httpClient.GetAsync<List<Market>>($"{baseUrl}/api/v1/markets{Query(request)}");
        }

        public async Task<OrderBook> GetOrderBookAsync(OrderBookRequest request)
        {
            return await this.httpClient.GetAsync<OrderBook>($"{baseUrl}/api/v1/depth{Query(request)}");
        }

        public async Task<List<Candlestick>> GetCandlestickBarsAsync(CandlestickBars request)
        {
            return await this.httpClient.GetAsync<List<Candlestick>>($"{baseUrl}/api/v1/klines{Query(request)}");
        }

        public async Task<OrderList> GetOpenOrdersAsync(OpenOrdersRequest request)
        {
            return await this.httpClient.GetAsync<OrderList>($"{baseUrl}/api/v1/orders/open{Query(request)}");
        }

        public async Task<OrderList> GetClosedOrdersAsync(ClosedOrdersRequest request)
        {
            return await this.httpClient.GetAsync<OrderList>($"{baseUrl}/api/v1/orders/closed{Query(request)}");
        }

        public async Task<Order> GetOrderAsync(string id)
        {
            return await this.httpClient.GetAsync<Order>($"{baseUrl}/api/v1/orders/{Path(id)}");
        }

        public async Task<List<TickerStatistics>> Get24HrPriceStatisticsAsync()
        {
            return await this.httpClient.GetAsync<List<TickerStatistics>>($"{baseUrl}/api/v1/ticker/24hr");
        }

        public async Task<TradePage> GetTradesAsync(TradesRequest request)
        {
            return await this.httpClient.GetAsync<TradePage>($"{baseUrl}/api/v1/trades{Query(request)}");
        }

        public async Task<TransactionPage> GetTransactionsAsync(TransactionsRequest request)
        {
            return await this.httpClient.GetAsync<TransactionPage>($"{baseUrl}/api/v1/transactions{Query(request)}");
        }

        public async Task<OrderList> GetOpenOrdersAsync(string address)
        {
            return await GetOpenOrdersAsync(new OpenOrdersRequest() { Address = address });
        }

        public async Task<OrderList> GetClosedOrdersAsync(string address)
        {
            return await GetClosedOrdersAsync(new ClosedOrdersRequest() { Address = address });
        }

        public async Task<TradePage> GetTradesAsync()
        {
            return await GetTradesAsync(new TradesRequest());
        }

        public async Task<TransactionPage> GetTransactionsAsync(string address)
        {
            return await GetTransactionsAsync(new TransactionsRequest() { Address = address });
        }

        #endregion

        #region Broadcast (Async)

        public async Task<List<TransactionMetadata>> BroadcastAsync(string transaction, bool sync = true)
        {
            return await this.httpClient.PostAsync<List<TransactionMetadata>>($"{baseUrl}/api/v1/broadcast", transaction, System.Text.Encoding.UTF8, "text/plain");
        }

        public Task<List<TransactionMetadata>> NewOrderAsync(NewOrder newOrder, Wallet wallet, TransactionOption options, bool sync = true)
        {
            TransactionMessage message = new NewOrderMessage(newOrder, wallet, options);
            return BroadcastAsync(message.BuildMessageBody());
        }
        public Task<List<TransactionMetadata>> VoteAsync(Vote vote, Wallet wallet, TransactionOption options, bool sync = true)
        {
            TransactionMessage message = new VoteMessage(vote, wallet, options);
            return BroadcastAsync(message.BuildMessageBody());
        }
        public Task<List<TransactionMetadata>> CancelOrderAsync(CancelOrder cancelOrder, Wallet wallet, TransactionOption options, bool sync = true)
        {
            TransactionMessage message = new CancelOrderMessage(cancelOrder, wallet, options);
            return BroadcastAsync(message.BuildMessageBody());
        }
        public Task<List<TransactionMetadata>> TransferAsync(Transfer transfer, Wallet wallet, TransactionOption options, bool sync = true)
        {
            TransactionMessage message = new TransferMessage(transfer, wallet, options);
            return BroadcastAsync(message.BuildMessageBody());
        }
        //TODO:
        //public Task<List<TransactionMetadata>> MultiTransferAsync(MultiTransfer multiTransfer, Wallet wallet, TransactionOption options, bool sync = true)
        //{
        //    TransactionMessage message = new MultiTransferMessage(multiTransfer, wallet, options);
        //    return BroadcastAsync(sync, message.BuildMessageBody());
        //}
        public Task<List<TransactionMetadata>> FreezeAsync(TokenFreeze tokenFreeze, Wallet wallet, TransactionOption options, bool sync = true)
        {
            TransactionMessage message = new TokenFreezeMessage(tokenFreeze, wallet, options);
            return BroadcastAsync(message.BuildMessageBody());
        }
        public Task<List<TransactionMetadata>> UnfreezeAsync(TokenUnfreeze tokenUnfreeze, Wallet wallet, TransactionOption options, bool sync = true)
        {
            TransactionMessage message = new TokenUnfreezeMessage(tokenUnfreeze, wallet, options);
            return BroadcastAsync(message.BuildMessageBody());
        }

        #endregion

        #region Requests

        public Time GetTime() => GetTimeAsync().GetAwaiter().GetResult();
        public Infos GetNodeInfo() => GetNodeInfoAsync().GetAwaiter().GetResult();
        public Validator GetValidators() => GetValidatorsAsync().GetAwaiter().GetResult();
        public List<Peer> GetPeers() => GetPeersAsync().GetAwaiter().GetResult();
        public List<Fees> GetFees() => GetFeesAsync().GetAwaiter().GetResult();
        public Account GetAccount(string address) => GetAccountAsync(address).GetAwaiter().GetResult();
        public AccountSequence GetAccountSequence(string address) => GetAccountSequenceAsync(address).GetAwaiter().GetResult();
        public TransactionMetadata GetTransactionMetadata(string hash) => GetTransactionMetadataAsync(hash).GetAwaiter().GetResult();
        public List<Token> GetTokens(TokenRequest request) => GetTokensAsync(request).GetAwaiter().GetResult();
        public List<Market> GetMarkets(MarketRequest request) => GetMarketsAsync(request).GetAwaiter().GetResult();
        public OrderBook GetOrderBook(OrderBookRequest request) => GetOrderBookAsync(request).GetAwaiter().GetResult();
        public List<Candlestick> GetCandlestickBars(CandlestickBars request) => GetCandlestickBarsAsync(request).GetAwaiter().GetResult();
        public OrderList GetOpenOrders(OpenOrdersRequest request) => GetOpenOrdersAsync(request).GetAwaiter().GetResult();
        public OrderList GetClosedOrders(ClosedOrdersRequest request) => GetClosedOrdersAsync(request).GetAwaiter().GetResult();
        public Order GetOrder(string id) => GetOrderAsync(id).GetAwaiter().GetResult();
        public List<TickerStatistics> Get24HrPriceStatistics() => Get24HrPriceStatisticsAsync().GetAwaiter().GetResult();
        public TradePage GetTrades(TradesRequest request) => GetTradesAsync(request).GetAwaiter().GetResult();
        public TransactionPage GetTransactions(TransactionsRequest request) => GetTransactionsAsync(request).GetAwaiter().GetResult();
        public OrderList GetOpenOrders(string address) => GetOpenOrdersAsync(address).GetAwaiter().GetResult();
        public OrderList GetClosedOrders(string address) => GetClosedOrdersAsync(address).GetAwaiter().GetResult();
        public TradePage GetTrades() => GetTradesAsync().GetAwaiter().GetResult();
        public TransactionPage GetTransactions(string address) => GetTransactionsAsync(address).GetAwaiter().GetResult();

        #endregion

        #region Broadcasts

        public List<TransactionMetadata> Broadcast(string transaction, bool sync = true) => 
            BroadcastAsync(transaction, sync).GetAwaiter().GetResult();

        public List<TransactionMetadata> NewOrder(NewOrder newOrder, Wallet wallet, TransactionOption options, bool sync = true) => 
            NewOrderAsync(newOrder, wallet, options, sync).GetAwaiter().GetResult();

        public List<TransactionMetadata> Vote(Vote vote, Wallet wallet, TransactionOption options, bool sync = true) => 
            VoteAsync(vote, wallet, options, sync).GetAwaiter().GetResult();

        public List<TransactionMetadata> CancelOrder(CancelOrder cancelOrder, Wallet wallet, TransactionOption options, bool sync = true) => 
            CancelOrderAsync(cancelOrder, wallet, options, sync).GetAwaiter().GetResult();

        public List<TransactionMetadata> Transfer(Transfer transfer, Wallet wallet, TransactionOption options, bool sync = true) => 
            TransferAsync(transfer, wallet, options, sync).GetAwaiter().GetResult();

        public List<TransactionMetadata> Freeze(TokenFreeze tokenFreeze, Wallet wallet, TransactionOption options, bool sync = true) => 
            FreezeAsync(tokenFreeze, wallet, options, sync).GetAwaiter().GetResult();

        public List<TransactionMetadata> Unfreeze(TokenUnfreeze tokenUnfreeze, Wallet wallet, TransactionOption options, bool sync = true) => 
            UnfreezeAsync(tokenUnfreeze, wallet, options, sync).GetAwaiter().GetResult();

        #endregion
    }
}
