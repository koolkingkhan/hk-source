using System;
using System.Xml.Serialization;
using Ubs.Collateral.Sre.Common.Utility;

namespace sre.model
{
    
    public class Negotiation
    {
        private double? _existingRuleRank;
        private bool? _straightToDi;
        private const string NidFormatMask = "{0:##}";
        private const string RuleRankFormatMask = "{0:##}";

        [XmlAttribute(AttributeName = "nid", DataType = "decimal")]
        public decimal NegotiationId { get; set; }

        private OriginatingSystem? _originatingSystem;

        [XmlIgnore]
        public OriginatingSystem OriginatingSystem
        {
            get
            {
                if (_originatingSystem == null)
                {
                    _originatingSystem = !string.IsNullOrWhiteSpace(OriginatingSystemDisplayText)
                         ? MfcEnumUtility.ParseByDescription<OriginatingSystem>(OriginatingSystemDisplayText)
                         : OriginatingSystem.Default;
                }
                return _originatingSystem.GetValueOrDefault();
            }
            set
            {
                _originatingSystem = value;
                OriginatingSystemDisplayText = _originatingSystem.Description();
            }
        }


        [XmlAttribute(AttributeName = "originatingSystem", DataType = "string")]
        public string OriginatingSystemDisplayText { get; set; }

        [XmlIgnore]
        public Security Security { get; set; }

        [XmlAttribute(AttributeName = "secCode", DataType = "string")]
        public string SecurityCode
        {
            get { return Security.SecurityCode; }
            set { Security.SecurityCode = value; }
        }

        [XmlAttribute(AttributeName = "secType", DataType = "string")]
        public string SecurityTypeDisplayText
        {
            get { return Security.SecurityTypeDisplayText; }
            set { Security.SecurityTypeDisplayText = value; }
        }

        [XmlAttribute(AttributeName = "special", DataType = "boolean")]
        public bool IsSpecial
        {
            get { return Security.IsSpecial; }
            set { Security.IsSpecial = value; }
        }

        [XmlAttribute(AttributeName = "straightToDI", DataType = "boolean")]
        public bool StraightToDi
        {
            get { return _straightToDi.GetValueOrDefault(); }
            set { _straightToDi = value; }
        }

        [XmlIgnore]
        public bool StraightToDiSpecified
        {
            get
            {
                return _straightToDi.HasValue;
            }
        }

        [XmlAttribute(AttributeName = "quotationCountry", DataType = "string")]
        public string QuotationCountryDisplayText
        {
            get { return Security.CountryCode; }
            set { Security.CountryCode = value; }
        }

        [XmlIgnore]
        public bool QuotationCountryDisplayTextSpecified
        {
            get { return !String.IsNullOrWhiteSpace(QuotationCountryDisplayText); }
        }

        [XmlAttribute(AttributeName = "quotationCurrency", DataType = "string")]
        public string QuotationCurrencyDisplayText { get; set; }

        [XmlIgnore]
        public bool QuotationCurrencyDisplayTextSpecified
        {
            get { return !String.IsNullOrWhiteSpace(QuotationCurrencyDisplayText); }
        }

        //[XmlIgnore]
        //public ProductType ProductType
        //{
        //    get
        //    {
        //        return !string.IsNullOrWhiteSpace(ProductTypeDisplayText)
        //                 ? MfcEnumUtility.ParseByDescription<ProductType>(ProductTypeDisplayText)
        //                 : ProductType.Default;
        //    }
        //    set { ProductTypeDisplayText = MfcEnumUtility.Description(value); }
        //}


        [XmlAttribute(AttributeName = "productType", DataType = "string")]
        public string ProductTypeDisplayText { get; set; }

        [XmlAttribute(AttributeName = "cpty", DataType = "string")]
        public string CounterpartyName { get; set; }

        private AssetClass? _assetClass;

        [XmlIgnore]
        public AssetClass AssetClass
        {
            get
            {
                if (_assetClass == null)
                {
                    _assetClass = !string.IsNullOrWhiteSpace(AssetClassDisplayText)
                        ? MfcEnumUtility.ParseByDescription<AssetClass>(AssetClassDisplayText)
                        : AssetClass.Default;
                }
                return _assetClass.GetValueOrDefault();
            }
            set
            {
                _assetClass = value;
                AssetClassDisplayText = _assetClass.Description();
            }
        }

        [XmlAttribute(AttributeName = "assetClass", DataType = "string")]
        public string AssetClassDisplayText { get; set; }

        [XmlIgnore]
        public bool AssetClassDisplayTextSpecified
        {
            get
            {
                return AssetClass.Default != AssetClass;
            }
        }                

        [XmlAttribute(AttributeName = "reasonCodes", DataType = "string")]
        public string ReasonCodes { get; set; }

        [XmlIgnore]
        public bool ReasonCodesSpecified
        {
            get { return !String.IsNullOrWhiteSpace(ReasonCodes); }
        }

        [XmlAttribute(AttributeName = "averageTradeDuration", DataType = "double")]
        public double AverageTradeDuration { get; set; }

        [XmlAttribute(AttributeName = "existingStpAction", DataType = "string")]
        public string ExistingStpAction { get; set; }

        [XmlIgnore]
        public bool ExistingStpActionSpecified
        {
            get { return !string.IsNullOrWhiteSpace(ExistingStpAction); }
        }

        [XmlAttribute(AttributeName = "existingRuleRank", DataType = "string")]
        public string ExistingRuleRankDisplayText { get; set; }

        [XmlIgnore]
        public double? ExistingRuleRank
        {
            get { return _existingRuleRank; }
            set
            {
                _existingRuleRank = value;
                ExistingRuleRankDisplayText = string.Format(RuleRankFormatMask, _existingRuleRank);
            }
        }

        [XmlIgnore]
        public bool ExistingRuleRankDisplayTextSpecified
        {
            get { return ExistingRuleRank.HasValue; }
        }

        [XmlAttribute(AttributeName = "existingRuleName", DataType = "string")]
        public string ExistingRuleName { get; set; }

        [XmlIgnore]
        public bool ExistingRuleNameSpecified
        {
            get { return !string.IsNullOrWhiteSpace(ExistingRuleName); }
        }

        [XmlElement(ElementName = "currentOrder")]
        public Order CurrentOrder { get; set; }

        [XmlElement(ElementName = "previousOrder")]
        public Order PreviousOrder { get; set; }
    }
}