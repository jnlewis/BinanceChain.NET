using BinanceChain.NET.Api.Domain;
using BinanceChain.NET.Api.Domain.Broadcast;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinanceChain.NET.Tests
{
    [TestClass]
    public class BinanceApiTransactionTests
    {
        [TestMethod]
        public void NewOrder_Test()
        {
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

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Vote_Test()
        {
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

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void CancelOrder_Test()
        {
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

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Transfer_Test()
        {
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

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Freeze_Test()
        {
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

            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Unfreeze_Test()
        {
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

            Assert.IsTrue(result != null);
        }
    }
}
