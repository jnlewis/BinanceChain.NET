using BinanceChain.NET.NodeRPC.Domain;
using BinanceChain.NET.NodeRPC.Domain.Requests;
using System.Threading.Tasks;

namespace BinanceChain.NET.Api
{
    public interface IBinanceChainNodeClient
    {

        #region Requests (Async)
        
        Task<Infos> GetNodeStatusAsync();
        Task<ABCIInfo> GetABCIInfoAsync();
        Task<ConsensusState> GetConsensusStateAsync();
        Task<ConsensusState> GetDumpConsensusStateAsync();
        Task<NetInfo> GetNetInfoAsync();
        //Task<GenesisFile> GetGenesisFileAsync();
        //Task<Void> GetHealthAsync;
        Task<UnconfirmedTxs> GetNumUnconfirmedTxsAsync();
        Task<ABCIQuery> GetABCIQueryAsync(ABCIQueryRequest request);

        #endregion

        #region Requests

        Infos GetNodeStatus();
        ABCIInfo GetABCIInfo();
        ConsensusState GetConsensusState();
        ConsensusState GetDumpConsensusState();
        NetInfo GetNetInfo();
        //GenesisFile GetGenesisFile();
        //Void GetHealthAsync;
        UnconfirmedTxs GetNumUnconfirmedTxs();
        ABCIQuery GetABCIQuery(ABCIQueryRequest request);

        #endregion

    }
}
