using System;

namespace BinanceChain.NET.Api.Domain
{
    public enum TransactionTypes
    {
        NEW_ORDER,
        ISSUE_TOKEN,
        BURN_TOKEN,
        LIST_TOKEN,
        CANCEL_ORDER,
        FREEZE_TOKEN,
        UN_FREEZE_TOKEN,
        TRANSFER,
        PROPOSAL,
        VOTE
    }
}
