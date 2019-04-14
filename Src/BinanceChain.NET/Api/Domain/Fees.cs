using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Domain
{
    public class Fees : DomainEntity
    {
        [JsonProperty("msg_type")]
        public string MsgType { get; set; }

        [JsonProperty("fee")]
        public long Fee { get; set; }

        [JsonProperty("fee_for")]
        public int FeeFor { get; set; }

        [JsonProperty("multi_transfer_fee")]
        public string MultiTransferFee { get; set; }

        [JsonProperty("lower_limit_as_multi")]
        public string LowerLimitAsMulti { get; set; }

        [JsonProperty("fixed_fee_params")]
        public FixedFeeParams FixedFeeParams { get; set; }

        [JsonProperty("dex_fee_fields")]
        public List<DexFeeField> DexFeeFields { get; set; }
    }
}
