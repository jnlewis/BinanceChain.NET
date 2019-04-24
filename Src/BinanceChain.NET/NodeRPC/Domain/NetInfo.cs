using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.NodeRPC.Domain
{
    public class NetInfo : DomainEntity
    {
        [JsonProperty("listening")]
        public bool listening { get; set; }

        [JsonProperty("listeners")]
        public List<string> listeners { get; set; }

        [JsonProperty("n_peers")]
        public int n_peers { get; set; }

        [JsonProperty("peers")]
        public List<Peer> peers { get; set; }

        /*
         {
            "node_info": {
              "protocol_version": {
                "p2p": "7",
                "block": "10",
                "app": "0"
              },
              "id": "9612b570bffebecca4776cb4512d08e252119005",
              "listen_addr": "a0b88b324243a11e994280efee3352a7-96b6996626c6481d.elb.ap-northeast-1.amazonaws.com:27146",
              "network": "Binance-Chain-Nile",
              "version": "0.30.1",
              "channels": "354020212223303800",
              "moniker": "data-seed-0",
              "other": {
                "tx_index": "on",
                "rpc_address": "tcp://0.0.0.0:27147"
              }
            },
            "is_outbound": false,
            "connection_status": {
              "Duration": "188759697464282",
              "SendMonitor": {
                "Active": true,
                "Start": "2019-04-10T06:57:12.6Z",
                "Duration": "188759640000000",
                "Idle": "20000000",
                "Bytes": "3117641165",
                "Samples": "1219583",
                "InstRate": "1945",
                "CurRate": "13732",
                "AvgRate": "16516",
                "PeakRate": "111020",
                "BytesRem": "0",
                "TimeRem": "0",
                "Progress": 0
              },
              "RecvMonitor": {
                "Active": true,
                "Start": "2019-04-10T06:57:12.6Z",
                "Duration": "188759640000000",
                "Idle": "0",
                "Bytes": "3009295340",
                "Samples": "1210143",
                "InstRate": "4819",
                "CurRate": "16115",
                "AvgRate": "15942",
                "PeakRate": "142490",
                "BytesRem": "0",
                "TimeRem": "0",
                "Progress": 0
              },
              "Channels": [
                {
                  "ID": 48,
                  "SendQueueCapacity": "1",
                  "SendQueueSize": "0",
                  "Priority": "5",
                  "RecentlySent": "0"
                }
              ]
            },
            "remote_ip": "10.201.41.12"
          }
         */
    }
}
