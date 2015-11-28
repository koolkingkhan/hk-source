using System;
using System.Xml.Serialization;

namespace hk.Common
{
    [XmlRoot(ElementName = "settings", IsNullable = false)]
    public class Settings
    {
        [XmlElement("singularRule")]
        public Rule[] SingularRule { get; set; }


        [XmlElement("table")]
        public Table[] Table { get; set; }
    }

    [Serializable]
    public class Rule
    {
        private ArgumentType[] _argument;

        private string _description;

        private bool _enabled;

        private bool _enabledSpecified;

        private string _name;

        private int _ruleGroupId;

        private bool _ruleGroupIdSpecified;

        private RuleGroups _ruleGroupName;

        private bool _ruleGroupNameSpecified;

        private int _ruleId;

        private bool _toggleable;

        private bool _toggleableSpecified;

        [XmlElement("argument")]
        public ArgumentType[] Argument
        {
            get { return _argument; }
            set { _argument = value; }
        }

        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlAttribute("description")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        [XmlAttribute("enabled")]
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }


        [XmlIgnore]
        public bool EnabledSpecified
        {
            get { return _enabledSpecified; }
            set { _enabledSpecified = value; }
        }


        [XmlAttribute("ruleGroupId")]
        public int RuleGroupId
        {
            get { return _ruleGroupId; }
            set { _ruleGroupId = value; }
        }


        [XmlIgnore]
        public bool RuleGroupIdSpecified
        {
            get { return _ruleGroupIdSpecified; }
            set { _ruleGroupIdSpecified = value; }
        }


        [XmlAttribute("ruleGroupName")]
        public RuleGroups RuleGroupName
        {
            get { return _ruleGroupName; }
            set { _ruleGroupName = value; }
        }


        [XmlIgnore]
        public bool RuleGroupNameSpecified
        {
            get { return _ruleGroupNameSpecified; }
            set { _ruleGroupNameSpecified = value; }
        }


        [XmlAttribute("ruleId")]
        public int RuleId
        {
            get { return _ruleId; }
            set { _ruleId = value; }
        }


        [XmlAttribute("toggleable")]
        public bool Toggleable
        {
            get { return _toggleable; }
            set { _toggleable = value; }
        }


        [XmlIgnore]
        public bool ToggleableSpecified
        {
            get { return _toggleableSpecified; }
            set { _toggleableSpecified = value; }
        }
    }


    [Serializable]
    public class ArgumentType
    {
        private Keys _id;

        private bool _idSpecified;

        private Types _type;

        private bool _typeSpecified;

        private string _value;

        [XmlAttribute("id")]
        public Keys Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [XmlIgnore]
        public bool IdSpecified
        {
            get { return _idSpecified; }
            set { _idSpecified = value; }
        }

        [XmlAttribute("type")]
        public Types Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [XmlIgnore]
        public bool TypeSpecified
        {
            get { return _typeSpecified; }
            set { _typeSpecified = value; }
        }

        [XmlText]
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    [Serializable]
    public enum Keys
    {
        [XmlEnum("ruleGroupName")] RuleGroupName,

        [XmlEnum("softRejectCountToHardReject")] SoftRejectCountToHardReject,

        [XmlEnum("checkBidEconomics")] CheckBidEconomics,

        [XmlEnum("bidEconThreshold")] BidEconThreshold,

        [XmlEnum("cptyGroupName")] CptyGroupName,

        [XmlEnum("minFee")] MinFee,

        [XmlEnum("minFeeUSD")] MinFeeUsd,

        [XmlEnum("kipCodes")] KipCodes,

        [XmlEnum("externalSystems")] ExternalSystems,

        [XmlEnum("reasonCodes")] ReasonCodes,

        [XmlEnum("counterparties")] Counterparties,

        [XmlEnum("counterpartyExceptions")] CounterpartyExceptions,

        [XmlEnum("productTypes")] ProductTypes,

        [XmlEnum("assetClass")] AssetClass,

        [XmlEnum("quotationCountries")] QuotationCountries,

        [XmlEnum("quotationCountryExceptions")] QuotationCountryExceptions,

        [XmlEnum("isins")] Isins,

        [XmlEnum("isSpecialSecurity")] IsSpecialSecurity,

        [XmlEnum("businessState")] BusinessState,

        [XmlEnum("straightToFirm")] StraightToFirm,

        [XmlEnum("straightToDI")] StraightToDi,

        [XmlEnum("usdValue")] UsdValue,

        [XmlEnum("requestedUsdValue")] RequestedUsdValue,

        [XmlEnum("bid")] Bid,

        [XmlEnum("offer")] Offer,

        [XmlEnum("feeDifferentFromSoft")] FeeDifferentFromSoft,

        [XmlEnum("allocatedQtyDifferentFromSoft")] AllocatedQtyDifferentFromSoft,

        [XmlEnum("bidOfferRange")] BidOfferRange,

        [XmlEnum("currency")] Currency,

        [XmlEnum("totalAvailable")] TotalAvailable,

        [XmlEnum("valueToGo")] ValueToGo,

        [XmlEnum("daysToRecordDate")] DaysToRecordDate,

        [XmlEnum("daysToMaturity")] DaysToMaturity,

        [XmlEnum("daysToExDividendDate")] DaysToExDividendDate,

        [XmlEnum("totalAvailMinusDCCAlloc")] TotalAvailMinusDccAlloc,

        [XmlEnum("DCCAlloc")] DccAlloc,

        [XmlEnum("totalClientsHolding")] TotalClientsHolding,

        [XmlEnum("totalAllocationValue")] TotalAllocationValue,

        [XmlEnum("checkBilateralReceivedGreaterThanDCCAlloc")] CheckBilateralReceivedGreaterThanDccAlloc,

        [XmlEnum("totalRestricted")] TotalRestricted,

        [XmlEnum("percentageAllocated")] PercentageAllocated,

        [XmlEnum("dividendRate")] DividendRate,

        [XmlEnum("setNextRuleGroup")] SetNextRuleGroup,

        [XmlEnum("outcome")] Outcome,

        [XmlEnum("linkedOutcome")] LinkedOutcome,

        [XmlEnum("kipCode")] KipCode,

        [XmlEnum("checkIfBidLessThanOffer")] CheckIfBidLessThanOffer,

        [XmlEnum("checkIfBidGreaterThanOffer")] CheckIfBidGreaterThanOffer,

        [XmlEnum("amendOfferToMatchBid")] AmendOfferToMatchBid,

        [XmlEnum("setOffer")] SetOffer,

        [XmlEnum("applyDefaultMinFeeForCCY")] ApplyDefaultMinFeeForCcy,

        [XmlEnum("setMinFee")] SetMinFee
    }


    [Serializable]
    public enum Types
    {
        [XmlEnum("boolean")] Boolean,

        [XmlEnum("string")] String,

        [XmlEnum("integer")] Integer,

        [XmlEnum("decimal")] Decimal,

        [XmlEnum("originating_systems")] OriginatingSystems,

        [XmlEnum("counterparties")] Counterparties,

        [XmlEnum("product_types")] ProductTypes,

        [XmlEnum("securities")] Securities,

        [XmlEnum("security_classifications")] SecurityClassifications,

        [XmlEnum("countries")] Countries,

        [XmlEnum("business_states")] BusinessStates,

        [XmlEnum("kip_codes")] KipCodes,

        [XmlEnum("reason_codes")] ReasonCodes,

        [XmlEnum("outcome")] Outcome
    }

    [Serializable]
    public enum RuleGroups
    {
        [XmlEnum("")] None,

        [XmlEnum("Setup")] Setup,

        [XmlEnum("Emergency Switch")] EmergencySwitch,

        [XmlEnum("Health Check")] HealthCheck,

        [XmlEnum("EQ - Reference Data Check")] EqReferenceDataCheck,

        [XmlEnum("FI - Reference Data Check")] FiReferenceDataCheck,

        [XmlEnum("EQ - Availability Restrictions")] EqAvailabilityRestrictions,

        [XmlEnum("FI - Availability Restrictions")] FiAvailabilityRestrictions,

        [XmlEnum("EQ - Instrument Restrictions")] EqInstrumentRestrictions,

        [XmlEnum("FI - Instrument Restrictions")] FiInstrumentRestrictions,

        [XmlEnum("Common Order Checks")] CommonOrderChecks,

        [XmlEnum("EQ - Warms Trades")] EqWarmsTrades,

        [XmlEnum("EQ - Big Tickets")] EqBigTickets,

        [XmlEnum("EQ - Small Tickets")] EqSmallTickets,

        [XmlEnum("EQ - General Tickets")] EqGeneralTickets,

        [XmlEnum("Offer Restrictions")] OfferRestrictions,

        [XmlEnum("EQ - Counterparty Restrictions")] EqCounterpartyRestrictions,

        [XmlEnum("FI - Counterparty Restrictions")] FiCounterpartyRestrictions,

        [XmlEnum("EquiLend Order Checks")] EquiLendOrderChecks,

        [XmlEnum("BondLend Order Checks")] BondLendOrderChecks,

        [XmlEnum("EQ - Maelstrom Order Checks")] EqMaelstromOrderChecks,

        [XmlEnum("FI - Maelstrom Order Checks")] FiMaelstromOrderChecks,

        [XmlEnum("Highlight")] Highlight,

        [XmlEnum("Final Decisions")] FinalDecisions
    }


    [Serializable]
    public class Table
    {
        private string _description;

        private string _name;

        private int _ruleGroupId;

        private RuleGroups _ruleGroupName;

        private bool _ruleGroupNameSpecified;
        private Rule[] _tabularRules;

        private int _templateId;

        private bool _templateIdSpecified;

        [XmlElement("tabularRule")]
        public Rule[] TabularRule
        {
            get { return _tabularRules; }
            set { _tabularRules = value; }
        }

        [XmlAttribute("description")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlAttribute("ruleGroupId")]
        public int RuleGroupId
        {
            get { return _ruleGroupId; }
            set { _ruleGroupId = value; }
        }

        [XmlAttribute("ruleGroupName")]
        public RuleGroups RuleGroupName
        {
            get { return _ruleGroupName; }
            set { _ruleGroupName = value; }
        }

        [XmlIgnore]
        public bool RuleGroupNameSpecified
        {
            get { return _ruleGroupNameSpecified; }
            set { _ruleGroupNameSpecified = value; }
        }

        [XmlAttribute("templateId")]
        public int TemplateId
        {
            get { return _templateId; }
            set { _templateId = value; }
        }

        [XmlIgnore]
        public bool TemplateIdSpecified
        {
            get { return _templateIdSpecified; }
            set { _templateIdSpecified = value; }
        }
    }
}