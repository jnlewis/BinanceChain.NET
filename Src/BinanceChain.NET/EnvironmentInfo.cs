using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET
{
    public class EnvironmentInfo
    {
        public string Name { get; set; }
        public string ApiBaseUrl { get; set; }
        public string WebSockerBaseUrl { get; set; }
        public string Hrp { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public EnvironmentInfo()
        {
        }
        public EnvironmentInfo(string name, string apiBaseUrl, string webSockerBaseUrl, string hrp)
        {
            this.Name = name;
            this.ApiBaseUrl = apiBaseUrl;
            this.WebSockerBaseUrl = webSockerBaseUrl;
            this.Hrp = hrp;
        }

        public static EnvironmentInfo PROD
        {
            get
            {
                return new EnvironmentInfo()
                {
                    Name = "Binance Chain Live",
                    ApiBaseUrl = "https://dex.binance.org",
                    WebSockerBaseUrl = "wss://dex.binance.org/api/ws",
                    Hrp = "bnb"
                };
            }
        }

        public static EnvironmentInfo TESTNET
        {
            get
            {
                return new EnvironmentInfo()
                {
                    Name = "Binance Chain Testnet",
                    ApiBaseUrl = "https://testnet-dex.binance.org",
                    WebSockerBaseUrl = "wss://testnet-dex.binance.org/api/ws",
                    Hrp = "tbnb"
                };
            }
        }
        
    }
}
