using System;
using System.Threading.Tasks;
using BinanceChain.NET.NodeRPC.Domain;
using BinanceChain.NET.NodeRPC.Domain.Requests;
using BinanceChain.NET.Utility.Network;

namespace BinanceChain.NET.Api
{
    public class BinanceChainNodeClient : BinanceChainNodeBase, IBinanceChainNodeClient
    {
        private readonly string baseUrl;
        private readonly IHttpClient httpClient;

        public BinanceChainNodeClient(
            string baseUrl,
            IHttpClient httpClient)
        {
            this.baseUrl = baseUrl ?? throw new ArgumentNullException("environment");
            this.httpClient = httpClient ?? throw new ArgumentNullException("httpClient");
        }
        
        #region Requests (Async)
        
        public async Task<Infos> GetNodeStatusAsync()
        {
            return await this.GetAsync<Infos>($"{baseUrl}/status");
        }

        public async Task<ABCIInfo> GetABCIInfoAsync()
        {
            return await this.GetAsync<ABCIInfo>($"{baseUrl}/abci_info");
        }

        public async Task<ConsensusState> GetConsensusStateAsync()
        {
            return await this.GetAsync<ConsensusState>($"{baseUrl}/consensus_state");
        }

        public async Task<ConsensusState> GetDumpConsensusStateAsync()
        {
            return await this.GetAsync<ConsensusState>($"{baseUrl}/dump_consensus_state");
        }

        public async Task<NetInfo> GetNetInfoAsync()
        {
            return await this.GetAsync<NetInfo>($"{baseUrl}/net_info");
        }

        //public async Task<GenesisFile> GetGenesisFileAsync()
        //{
        //    return await this.GetAsync<GenesisFile>($"{baseUrl}/genesis");
        //}

        //public async Task<Void> GetHealthAsync()
        //{
        //    return await this.httpClient.GetAsync<Void>($"{baseUrl}/health");
        //}

        public async Task<UnconfirmedTxs> GetNumUnconfirmedTxsAsync()
        {
            return await this.GetAsync<UnconfirmedTxs>($"{baseUrl}/num_unconfirmed_txs");
        }

        public async Task<ABCIQuery> GetABCIQueryAsync(ABCIQueryRequest request)
        {
            return await this.httpClient.GetAsync<ABCIQuery>($"{baseUrl}/abci_query{Query(request)}");
        }

        #endregion

        #region Requests

        public Infos GetNodeStatus() => GetNodeStatusAsync().GetAwaiter().GetResult();

        public ABCIInfo GetABCIInfo() => GetABCIInfoAsync().GetAwaiter().GetResult();

        public ConsensusState GetConsensusState() => GetConsensusStateAsync().GetAwaiter().GetResult();

        public ConsensusState GetDumpConsensusState() => GetDumpConsensusStateAsync().GetAwaiter().GetResult();

        public NetInfo GetNetInfo() => GetNetInfoAsync().GetAwaiter().GetResult();

        public UnconfirmedTxs GetNumUnconfirmedTxs() => GetNumUnconfirmedTxsAsync().GetAwaiter().GetResult();

        public ABCIQuery GetABCIQuery(ABCIQueryRequest request) => GetABCIQueryAsync(request).GetAwaiter().GetResult();

        #endregion

        private async Task<T> GetAsync<T>(string url) where T : class
        {
            var response = await this.httpClient.GetAsync<JsonRPCResponse<T>>($"{baseUrl}/status");

            if (response.Error != null)
            {
                throw new Exception(response.Error.Code + ":" + response.Error.Message);
            }

            return response.Result as T;
        }

    }
}
