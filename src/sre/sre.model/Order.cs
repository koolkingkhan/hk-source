using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Ubs.Collateral.Sre.Common.Utility;

namespace sre.model
{
    public class Order
    {
        private double? _bid;
        private double? _offer;
        private decimal? _totalQuantity;
        private decimal? _contractPrice;
        private double? _minFee;
        private double? _cashRate;
        private decimal? _calculatedUsdValue;
        private const string FormatMask = "{0:0.00}";

        private OrderState? _orderState;

        [XmlIgnore]
        public OrderState OrderState
        {
            get
            {
                if (_orderState == null)
                {
                    _orderState = !string.IsNullOrWhiteSpace(OrderStateDisplayText)
                                      ? MfcEnumUtility.ParseByDescription<OrderState>(OrderStateDisplayText)
                                      : OrderState.Default;
                }
                return _orderState.GetValueOrDefault();
            }
            set
            {
                _orderState = value;
                OrderStateDisplayText = _orderState.Description();
            }
        }

        [XmlAttribute(AttributeName = "orderState", DataType = "string")]
        public string OrderStateDisplayText { get; set; }

        [XmlIgnore]
        public bool OrderStateDisplayTextSpecified
        {
            get
            {
                return OrderState.Default != OrderState;
            }
        }

        [XmlAttribute(AttributeName = "bid")]
        public string BidDisplayText { get; set; }

        [XmlIgnore]
        public double? Bid
        {
            get
            {
                return _bid.GetValueOrDefault();
            }
            set
            {
                _bid = value;
                BidDisplayText = string.Format(FormatMask, _bid);
            }
        }

        [XmlIgnore]
        public bool BidDisplayTextSpecified
        {
            get { return !String.IsNullOrWhiteSpace(BidDisplayText); }
        }

        [XmlAttribute(AttributeName = "offer")]
        public string OfferDisplayText { get; set; }

        [XmlIgnore]
        public double? Offer
        {
            get
            {
                return _offer.GetValueOrDefault();
            }
            set
            {
                _offer = value;
                OfferDisplayText = string.Format(FormatMask, _offer);
            }
        }

        [XmlIgnore]
        public bool OfferDisplayTextSpecified
        {
            get { return !String.IsNullOrWhiteSpace(OfferDisplayText); }
        }

        //Total Quantity = Filled Amount
        //Requested Quantity = Maximum Quantity
        [XmlAttribute(AttributeName = "totalQuantity")]
        public string TotalQuantityDisplayText { get; set; }

        [XmlIgnore]
        public decimal? TotalQuantity
        {
            get
            {
                return _totalQuantity.GetValueOrDefault();
            }
            set
            {
                _totalQuantity = value;
                TotalQuantityDisplayText = string.Format(FormatMask, _totalQuantity);
            }
        }

        [XmlIgnore]
        public bool TotalQuantityDisplayTextSpecified
        {
            get
            {
                return TotalQuantity.HasValue && !string.IsNullOrWhiteSpace(TotalQuantityDisplayText);
            }
        }

        [XmlAttribute(AttributeName = "price")]
        public string ContractPriceDisplayText { get; set; }

        [XmlIgnore]
        public decimal? ContractPrice
        {
            get
            {
                return _contractPrice.GetValueOrDefault();
            }
            set
            {
                _contractPrice = value;
                ContractPriceDisplayText = string.Format(FormatMask, _contractPrice);
            }
        }

        [XmlIgnore]
        public bool ContractPriceDisplayTextSpecified
        {
            get { return !string.IsNullOrWhiteSpace(ContractPriceDisplayText); }
        }

        [XmlAttribute(AttributeName = "minFee")]
        public string MinFeeDisplayText { get; set; }

        [XmlIgnore]
        public double? MinFee
        {
            get
            {
                return _minFee.GetValueOrDefault();
            }
            set
            {
                _minFee = value;
                MinFeeDisplayText = string.Format(FormatMask, _minFee);
            }
        }

        [XmlIgnore]
        public bool MinFeeDisplayTextSpecified
        {
            get { return _minFee.HasValue; }
        }

        [XmlAttribute(AttributeName = "cashRate")]
        public string CashRateDisplayText { get; set; }

        [XmlIgnore]
        public double? CashRate
        {
            get
            {
                return _cashRate.GetValueOrDefault();
            }
            set
            {
                _cashRate = value;
                CashRateDisplayText = string.Format(FormatMask, _cashRate);
            }
        }

        [XmlIgnore]
        public bool CashRateDisplayTextSpecified
        {
            get { return !String.IsNullOrWhiteSpace(CashRateDisplayText); }
        }

        [XmlAttribute(AttributeName = "termType")]
        public string TermType { get; set; }

        [XmlAttribute(AttributeName = "sMode")]
        public string SettlementModeDisplayText { get; set; }

        [XmlIgnore]
        public bool SettlementModeDisplayTextSpecified
        {
            get { return !String.IsNullOrWhiteSpace(SettlementModeDisplayText); }
        }

        [XmlAttribute(AttributeName = "billCCY")]
        public string BillingCcy { get; set; }

        [XmlIgnore]
        public bool BillingCcySpecified
        {
            get { return !String.IsNullOrWhiteSpace(SettlementModeDisplayText); }
        }

        [XmlAttribute(AttributeName = "usdValue")]
        public string UsdValue { get; set; }

        [XmlIgnore]
        public bool UsdValueSpecified
        {
            get
            {
                bool b = TotalQuantityDisplayTextSpecified && ContractPriceDisplayTextSpecified;
                if (b && String.IsNullOrWhiteSpace(UsdValue))
                {
                    UsdValue = String.Format(FormatMask, GetUsdValue());
                }
                return b;
            }
        }

        [XmlAttribute(AttributeName = "requestedValue")]
        public string RequestedValue { get; set; }

        [XmlIgnore]
        public bool RequestedValueSpecified
        {
            get
            {
                bool b = TotalQuantityDisplayTextSpecified && ContractPriceDisplayTextSpecified;
                if (b && String.IsNullOrWhiteSpace(RequestedValue))
                {
                    RequestedValue = String.Format(FormatMask, GetUsdValue());
                }
                return b;
            }
        }

        private readonly Dictionary<string, decimal> _fxrates = new Dictionary<string, decimal>
            {
                {"AUD", (decimal) 0.8963},
                {"CAD", (decimal) 0.9128},
                {"CHF", (decimal) 1.0676},
                {"EUR", (decimal) 1.289},
                {"GBP", (decimal) 1.6387},
                {"JPY", (decimal) 0.009193}                
            };

        private decimal GetUsdValue()
        {
            if (!_calculatedUsdValue.HasValue)
            {
                decimal fxrate;
                decimal rate = _fxrates.TryGetValue(BillingCcy, out fxrate) ? fxrate : 1;
                _calculatedUsdValue = TotalQuantity.HasValue && ContractPrice.HasValue ?
                    TotalQuantity.Value * (ContractPrice.Value * rate) : 0;
            }

            return _calculatedUsdValue.Value;
        }
    }
}
