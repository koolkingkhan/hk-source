using System;

namespace sre.model
{
    public class AverageMisData : IEquatable<AverageMisData>
    {
        public string CounterpartyId { get; set; }
        public string SettlementMode { get; set; }
        public string TradeCategory { get; set; }
        public double AverageTradeDuration { get; set; }
        public double AverageSettlement { get; set; }
        public double AverageSettlementFeeUsd { get; set; }
        public double AverageInitialLnvalUsd { get; set; }
        public double AverageEarningAfterSettlementCost { get; set; }


        public bool Equals(AverageMisData other)
        {
            return other.CounterpartyId.Equals(CounterpartyId, StringComparison.OrdinalIgnoreCase) &&
                   other.SettlementMode.Equals(SettlementMode, StringComparison.OrdinalIgnoreCase) &&
                   other.TradeCategory.Equals(TradeCategory, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is AverageMisData))
            {
                return false;
            }
            AverageMisData other = (AverageMisData)obj;
            return other.CounterpartyId.Equals(CounterpartyId, StringComparison.OrdinalIgnoreCase) &&
                   other.SettlementMode.Equals(SettlementMode, StringComparison.OrdinalIgnoreCase) &&
                   other.TradeCategory.Equals(TradeCategory, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            int hash = 19;
            hash = hash * 29 + CounterpartyId.GetHashCode();
            hash = hash * 29 + SettlementMode.GetHashCode();
            hash = hash * 29 + TradeCategory.GetHashCode();
            return hash;
        }
    }
}
