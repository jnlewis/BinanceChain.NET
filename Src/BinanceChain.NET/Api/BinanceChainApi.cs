using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using BinanceChain.NET.Api.Domain.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BinanceChain.NET.Api
{
    public interface BinanceChainApi
    {

        #region Requests (Async)

        Task<Time> GetTimeAsync();
        Task<Infos> GetNodeInfoAsync();
        Task<Validator> GetValidatorsAsync();
        Task<List<Peer>> GetPeersAsync();
        Task<List<Fees>> GetFeesAsync();
        Task<Account> GetAccountAsync(string address);
        Task<AccountSequence> GetAccountSequenceAsync(string address);
        Task<TransactionMetadata> GetTransactionMetadataAsync(string hash);
        Task<List<Token>> GetTokensAsync(TokenRequest request);
        Task<List<Market>> GetMarketsAsync(MarketRequest request);
        Task<OrderBook> GetOrderBookAsync(OrderBookRequest request);
        Task<List<Candlestick>> GetCandlestickBarsAsync(CandlestickBars request);
        Task<OrderList> GetOpenOrdersAsync(OpenOrdersRequest request);
        Task<OrderList> GetClosedOrdersAsync(ClosedOrdersRequest request);
        Task<Order> GetOrderAsync(string id);
        Task<List<TickerStatistics>> Get24HrPriceStatisticsAsync();
        Task<TradePage> GetTradesAsync(TradesRequest request);
        Task<TransactionPage> GetTransactionsAsync(TransactionsRequest request);
        Task<OrderList> GetOpenOrdersAsync(string address);
        Task<OrderList> GetClosedOrdersAsync(string address);
        Task<TradePage> GetTradesAsync();
        Task<TransactionPage> GetTransactionsAsync(string address);

        #endregion

        #region Broadcast (Async)

        Task<List<TransactionMetadata>> BroadcastAsync(bool sync, RequestBody transaction);
        Task<List<TransactionMetadata>> NewOrderAsync(NewOrder newOrder, Wallet wallet, TransactionOption options, bool sync);
        Task<List<TransactionMetadata>> VoteAsync(Vote vote, Wallet wallet, TransactionOption options, bool sync);
        Task<List<TransactionMetadata>> CancelOrderAsync(CancelOrder cancelOrder, Wallet wallet, TransactionOption options, bool sync);
        Task<List<TransactionMetadata>> TransferAsync(Transfer transfer, Wallet wallet, TransactionOption options, bool sync);
        Task<List<TransactionMetadata>> FreezeAsync(TokenFreeze tokenFreeze, Wallet wallet, TransactionOption options, bool sync);
        Task<List<TransactionMetadata>> UnfreezeAsync(TokenUnfreeze tokenUnfreeze, Wallet wallet, TransactionOption options, bool sync);

        #endregion

        #region Requests

        Time GetTime();
        Infos GetNodeInfo();
        Validator GetValidators();
        List<Peer> GetPeers();
        List<Fees> GetFees();
        Account GetAccount(string address);
        AccountSequence GetAccountSequence(string address);
        TransactionMetadata GetTransactionMetadata(string hash);
        List<Token> GetTokens(TokenRequest request);
        List<Market> GetMarkets(MarketRequest request);
        OrderBook GetOrderBook(OrderBookRequest request);
        List<Candlestick> GetCandlestickBars(CandlestickBars request);
        OrderList GetOpenOrders(OpenOrdersRequest request);
        OrderList GetClosedOrders(ClosedOrdersRequest request);
        Order GetOrder(string id);
        List<TickerStatistics> Get24HrPriceStatistics();
        TradePage GetTrades(TradesRequest request);
        TransactionPage GetTransactions(TransactionsRequest request);
        OrderList GetOpenOrders(string address);
        OrderList GetClosedOrders(string address);
        TradePage GetTrades();
        TransactionPage GetTransactions(string address);

        #endregion

        #region Broadcasts

        List<TransactionMetadata> Broadcast(bool sync, RequestBody transaction);
        List<TransactionMetadata> NewOrder(NewOrder newOrder, Wallet wallet, TransactionOption options, bool sync);
        List<TransactionMetadata> Vote(Vote vote, Wallet wallet, TransactionOption options, bool sync);
        List<TransactionMetadata> CancelOrder(CancelOrder cancelOrder, Wallet wallet, TransactionOption options, bool sync);
        List<TransactionMetadata> Transfer(Transfer transfer, Wallet wallet, TransactionOption options, bool sync);
        List<TransactionMetadata> Freeze(TokenFreeze tokenFreeze, Wallet wallet, TransactionOption options, bool sync);
        List<TransactionMetadata> Unfreeze(TokenUnfreeze tokenUnfreeze, Wallet wallet, TransactionOption options, bool sync);

        #endregion

    }
}
