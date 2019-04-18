using BinanceChain.NET.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinanceChain.NET.Tests
{
    [TestClass]
    public class BinanceApiTests
    {
        [TestMethod]
        public void GetNodeInfo_Test()
        {
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetNodeInfo();

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetValidators_Test()
        {
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetValidators();

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetPeers_Test()
        {
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetPeers();

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetFees_Test()
        {
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetFees();

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetAccount_Test()
        {
            string address = "tbnb1ypgjxvscw2cezmd6slguyjk95yrnuahp4c4kd7";
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetAccount(address);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetAccountSequence_Test()
        {
            string address = "tbnb1ypgjxvscw2cezmd6slguyjk95yrnuahp4c4kd7";
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetAccountSequence(address);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetTransactionMetadata_Test()
        {
            string hash = "E81BAB8E555819E4211D62E2E536B6D5812D3D91C105F998F5C6EB3AB8136482";
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetTransactionMetadata(hash);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetTokens_Test()
        {
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetNodeInfo();

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetMarkets_Test()
        {
            Api.Domain.Requests.MarketRequest request = new Api.Domain.Requests.MarketRequest()
            {
                Limit = null,
                Offset = null
            };

            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetMarkets(request);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetOrderBook_Test()
        {
            Api.Domain.Requests.OrderBookRequest request = new Api.Domain.Requests.OrderBookRequest()
            {
                Symbol = "NNB-0AD_BNB",
                Limit = null
            };

            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetOrderBook(request);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetCandlestickBars_Test()
        { 
            Api.Domain.Requests.CandlestickBars request = new Api.Domain.Requests.CandlestickBars()
            {
                Symbol = "NNB-338_BNB",
                Interval = Api.Domain.Intervals.FiveMinute,
                Limit = null,
                StartTime = null,
                EndTime = null
            };

            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetCandlestickBars(request);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetOpenOrders_Test()
        {
            Api.Domain.Requests.OpenOrdersRequest request = new Api.Domain.Requests.OpenOrdersRequest()
            {
                Address = "tbnb1ypgjxvscw2cezmd6slguyjk95yrnuahp4c4kd7",
                Limit = null,
                Offset = null,
                Symbol = null,
                Total = null
            };
            
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetOpenOrders(request);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetClosedOrders_Test()
        {
            Api.Domain.Requests.ClosedOrdersRequest request = new Api.Domain.Requests.ClosedOrdersRequest()
            {
                Address = "tbnb1ypgjxvscw2cezmd6slguyjk95yrnuahp4c4kd7",
                End = null,
                Limit = null,
                Offset = null,
                Side = null,
                Start = null,
                Symbol = null,
                Total = null
            };
            request.Status.Add(Api.Domain.OrderStatuses.Canceled);

            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetClosedOrders(request);

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetOrder_Test()
        {
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetOrder("{orderid}");

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Get24HrPriceStatistics_Test()
        {
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.Get24HrPriceStatistics();

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetTrades_Test()
        {
            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetTrades();

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetTransactions_Test()
        {
            Api.Domain.Requests.TransactionsRequest request = new Api.Domain.Requests.TransactionsRequest()
            {
                Address = "tbnb1ypgjxvscw2cezmd6slguyjk95yrnuahp4c4kd7",
                BlockHeight = null,
                EndTime = null,
                Limit = null,
                Offset = null,
                Side = null,
                StartTime = null,
                TxAsset = null,
                TxType = Api.Domain.TransactionTypes.TRANSFER
            };

            IBinanceChainApiClient api = BinanceApiFactory.CreateApiClient(EnvironmentInfo.TESTNET);
            var result = api.GetTransactions(request);

            Assert.IsTrue(result != null);
        }
    }
}
